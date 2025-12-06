namespace Olbrasoft.Blog.Business;
public interface IFileExtensionProvider
{
    bool TryGetExtension(string contentType, out string extension);

    bool TryGetContentType(string extension, out string contentType);

}
