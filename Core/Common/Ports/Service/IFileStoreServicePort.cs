namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;

public interface IFileStoreServicePort
{
    public void DeleteFile(string name, string contentType, string? category = null);

    public void SaveFile(string name, string contentType, byte[] content, string? category = null);

    public Task SaveFileAsync(string name, string contentType, byte[] content, string? category = null);
}
