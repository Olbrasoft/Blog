# GitHub Copilot Instructions for `Olbrasoft/Blog`

These instructions guide AI coding agents working in this repository.

## Project Overview & Architecture
- **Solution layout**: Main solution is `Blog.sln` with projects:
  - `src/Olbrasoft.Blog.AspNetCore.Mvc` – ASP.NET Core MVC web app (UI, controllers, views, DI wiring).
  - `src/Olbrasoft.Blog.Business` – business services and abstractions (`ICategoryService`, `IPostService`, etc.).
  - `src/Olbrasoft.Blog.Data.EntityFrameworkCore` – EF Core-based data access (`BlogDbContext`, EF CQRS handlers).
  - `src/Olbrasoft.Blog.Data.FreeSql` – FreeSql-based data access (`BlogFreeSqlDbContext`, FreeSql CQRS handlers).
  - `test/Olbrasoft.Blog.AspNetCore.Mvc.Tests` – xUnit tests for the MVC project.
- **Startup flow**: `Program.cs` creates a `WebApplicationBuilder` and calls the extension method `builder.BuildServices()` defined in `WebApplicationBuilderExtensions`. That method is the central place for **service registration, ORM selection, and infrastructure configuration**.
- **ORM selection**: The app can run either with **Entity Framework Core** or **FreeSql** based on configuration key `UseOrm` in `appsettings*.json`:
  - `"UseOrm": "EntityFramework"` → `BlogDbContext` + EF-based CQRS in `Olbrasoft.Blog.Data.EntityFrameworkCore`.
  - `"UseOrm": "FreeSql"` → `BlogFreeSqlDbContext` + FreeSql-based CQRS in `Olbrasoft.Blog.Data.FreeSql`.
  - Any other/missing value throws `ArgumentNullException` in `BuildServices`.

## Key Patterns & Conventions
- **Dependency injection**:
  - All app services are registered inside `WebApplicationBuilderExtensions.BuildServices(WebApplicationBuilder builder)`.
  - Identity is configured via `AddIdentity<BlogUser, BlogRole>()` then extended with `.AddEntityFrameworkStores<BlogDbContext>()` or `.AddFreeSqlStores<BlogFreeSqlDbContext>()` depending on the ORM.
  - Business services live in `src/Olbrasoft.Blog.Business/Services` and are registered as `Scoped` in `BuildServices` (e.g. `CategoryService`, `TagService`, `PostService`, `CommentService`). When adding a new business service:
    - Define the interface in `Olbrasoft.Blog.Business`.
    - Implement it under `Services/`.
    - Register it in `WebApplicationBuilderExtensions.BuildServices` with an appropriate lifetime.
- **CQRS & mapping**:
  - Data projects use `Olbrasoft.Data.Cqrs` with dedicated command/query handlers in their `CommandHandlers/` and `QueryHandlers/` folders.
  - EF Core uses `Olbrasoft.Data.Cqrs.EntityFrameworkCore`; FreeSql uses `Olbrasoft.Data.Cqrs.FreeSql`.
  - Object mapping uses `Olbrasoft.Mapping` + Mapster registration. New DTO mappings should be added in mapping register classes (see `Olbrasoft.Blog.Data.FreeSql/Configurations` and `Olbrasoft.Blog.Data.EntityFrameworkCore/Configurations`) and registered via `builder.Services.AddMapping(typeof(PostToPostEditDtoRegister).Assembly)`.
- **Localization**:
  - Localization is enabled in `BuildServices` using `AddLocalization` with `ResourcesPath = "Resources"` and `AddViewLocalization` / `AddDataAnnotationsLocalization` for MVC.
  - `SharedResources` type and `.resx` files in `src/Olbrasoft.Blog.AspNetCore.Mvc/Resources` provide shared strings. New localized strings should follow the existing folder / naming structure.
  - `Program.cs` configures request localization with supported cultures `"en"` and `"cs"` and sets `DefaultRequestCulture("en")`.
- **Storage & markdown**:
  - Blob storage is configured with `FluentStorage` using the `Blob` connection string; this is used for blog images and other blobs.
  - Markdown transformation uses `builder.Services.AddTextTransformationMarkdown()` (from `Olbrasoft.Text.Transformation.Markdown`); use this service for rendering markdown to HTML instead of ad-hoc converters.

## Routing & MVC
- **Routing configuration** is in `Program.cs`:
  - Area route: `"Administration"` area mapped via `MapAreaControllerRoute` with pattern `Administration/{controller=Home}/{action=Index}/{id?}`.
  - Image route: `"Images/{postId}/{imageFileNameAndExtension}"` mapped to `HomeController.GetDefaultImages`.
  - Default route: `{controller=Home}/{action=Index}/{id?}`.
- **Views & resources**:
  - Standard MVC views live under `Views/` with `_ViewImports.cshtml` and `_ViewStart.cshtml` configured.
  - Keep new controllers and views consistent with these route patterns and folder naming.

## Build, Run, and Test
- **Build solution** (VS Code task): use the `build` task which runs:
  - `dotnet build Blog.sln /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary;ForceNoAlign`
- **Run web app**:
  - Preferred: use the `watch` task to run `dotnet watch run --project src/Olbrasoft.Blog.AspNetCore.Mvc/Olbrasoft.Blog.AspNetCore.Mvc.csproj` for hot reload.
- **Publish**:
  - Use the `publish` task which runs `dotnet publish Blog.sln` with similar logger options.
- **Tests**:
  - Unit tests are in `test/Olbrasoft.Blog.AspNetCore.Mvc.Tests` using xUnit + FluentAssertions + Moq.
  - `WebApplicationBuilderExtensionsTests` contains conventions such as ensuring `WebApplicationBuilderExtensions` stays `public static` and throws `ArgumentNullException` when invoked with `null`. When modifying `BuildServices`, preserve these behaviors or update tests accordingly.

## When Modifying or Adding Code
- Prefer updating DI registrations in `WebApplicationBuilderExtensions.BuildServices` rather than directly in `Program.cs`.
- When integrating new persistence logic, choose the right data project (EF vs FreeSql) and follow existing patterns in `CommandHandlers/`, `QueryHandlers/`, and configuration classes.
- When adding user-facing strings or labels, use the localization system (`Resources/` and `SharedResources`) instead of hard-coded text where practical.
- Keep configuration-driven decisions (such as ORM selection, connection strings, blob storage) behind `appsettings*.json` keys and avoid hardcoding environment-specific values.
