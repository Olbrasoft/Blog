using System.Collections.Generic;

namespace Olbrasoft.Blog.Business;
public class ImageExtensionProvider : IFileExtensionProvider
{
    /// <summary>
    /// The cross reference table of file extensions and content-types.
    /// </summary>
    public static IDictionary<string, string> ContentTypeToExtensionMap => new Dictionary<string, string>
    {
            { "image/bmp", ".bmp" },
            { "image/x-windows-bmp", ".bmp" },
            { "image/x-ms-bmp", ".bmp" },
            { "image/jpeg", ".jpg" },
            { "image/pjpeg", ".jpg" },
            { "image/png", ".png" },
            { "image/vnd.wap.wbmp", ".wbmp" },
    };

    public static IDictionary<string, string> ExtensionToContentTypeMap => new Dictionary<string, string>
    {
            { ".bmp", "image/bmp" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".png", "image/png" },
            { ".wbmp", "image/vnd.wap.wbmp" },
    };

    public bool TryGetContentType(string extension, out string contentType)
    {
        if (ExtensionToContentTypeMap.TryGetValue(extension, out var mappedContentType))
        {
            contentType = mappedContentType;
            return true;
        }

        contentType = string.Empty;
        return false;

    }

    public bool TryGetExtension(string contentType, out string extension)
    {
        if (ContentTypeToExtensionMap.TryGetValue(contentType, out var mappedExtension))
        {
            extension = mappedExtension;
            return true;
        }

        extension = string.Empty;
        return false;

    }
}
