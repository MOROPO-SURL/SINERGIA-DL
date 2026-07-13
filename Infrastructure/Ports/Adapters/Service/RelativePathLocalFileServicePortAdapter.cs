using Microsoft.AspNetCore.Hosting;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Service;

internal sealed class RelativePathLocalFileServicePortAdapter : IFileStoreServicePort
{
    private const string MEDIA_ROOT_DIRECTORY_NAME = "media";

    private readonly IWebHostEnvironment env;

    public RelativePathLocalFileServicePortAdapter(IWebHostEnvironment env)
    {
        this.env = env;
    }

    public void DeleteFile(string name, string contentType, string? category = null)
    {
        File.Delete(GetAbsoluteFilePath(category ?? contentType.ToDefaultFileStorageCategory(), $"{name}{MimeTypes.MimeTypeMap.GetExtension(contentType)}"));
    }

    public void SaveFile(string name, string contentType, byte[] content, string? category = null)
    {
        File.WriteAllBytes(GetAbsoluteFilePath(category ?? contentType.ToDefaultFileStorageCategory(), $"{name}{MimeTypes.MimeTypeMap.GetExtension(contentType)}"), content);
    }

    public Task SaveFileAsync(string name, string contentType, byte[] content, string? category = null)
    {
        return File.WriteAllBytesAsync(GetAbsoluteFilePath(category ?? contentType.ToDefaultFileStorageCategory(), $"{name}{MimeTypes.MimeTypeMap.GetExtension(contentType)}"), content);
    }

    private string GetAbsoluteFilePath(string category, string key) => Path.Combine(env.WebRootPath, MEDIA_ROOT_DIRECTORY_NAME, category, key);
}