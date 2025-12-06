# CI/CD Pipeline Setup for NuGet Packages

## Checklist for New Projects

Before starting work on any .NET NuGet project, verify:
- [ ] `.github/workflows/build.yml` exists
- [ ] `.github/workflows/publish-nuget.yml` exists
- [ ] GitHub Secret `NUGET_API_KEY` set
- [ ] README has CI/CD badges

**If missing → implement per this guide.**

## NuGet API Key

**Location:** `~/Dokumenty/Keys/nuget-key.txt`

Add to GitHub: `Settings` → `Secrets` → `Actions` → `NUGET_API_KEY`

## build.yml

```yaml
name: Build
on:
  push:
    branches: [main, develop]
  pull_request:
    branches: [main]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v4
    - uses: actions/setup-dotnet@v4
      with:
        dotnet-version: |
          6.0.x
          8.0.x
          10.0.x
    - run: dotnet restore
    - run: dotnet build -c Release --no-restore
    - run: dotnet test -c Release --no-build
```

## publish-nuget.yml

```yaml
name: Publish NuGet
on:
  push:
    branches: [main]
    tags: ['v*']

jobs:
  publish:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v4
    - uses: actions/setup-dotnet@v4
      with:
        dotnet-version: |
          6.0.x
          8.0.x
          10.0.x
    - run: dotnet restore
    - run: dotnet build -c Release --no-restore
    - run: dotnet test -c Release --no-build
    - run: dotnet pack -c Release --no-build -o ./artifacts
    - run: dotnet nuget push ./artifacts/*.nupkg --source https://api.nuget.org/v3/index.json --api-key ${{ secrets.NUGET_API_KEY }} --skip-duplicate
```

## .csproj Metadata

```xml
<PropertyGroup>
  <TargetFrameworks>netstandard2.1;net6.0;net8.0;net10.0</TargetFrameworks>
  <PackageId>Olbrasoft.ProjectName</PackageId>
  <Version>1.0.0</Version>
  <Authors>Olbrasoft</Authors>
  <PackageLicenseExpression>MIT</PackageLicenseExpression>
</PropertyGroup>
```

## Publishing Rules

Publishes to NuGet.org when:
1. All tests pass
2. Push to `main` OR tag `v*`

## Common Errors

| Error | Solution |
|-------|----------|
| 403 Permission denied | Add `permissions:` block |
| 409 Version exists | Bump version or use `--skip-duplicate` |
| API key error | Check `NUGET_API_KEY` secret |
