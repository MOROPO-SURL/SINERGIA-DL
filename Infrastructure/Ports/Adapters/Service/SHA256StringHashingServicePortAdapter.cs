using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Service;

internal class SHA256StringHashingServicePortAdapter : IStringHashingServicePort
{
    public string GetHashed(string source)
    {
        byte[] originalBytes = System.Text.Encoding.ASCII.GetBytes(source);

        byte[] encodedBytes = System.Security.Cryptography.SHA256.HashData(originalBytes);

        return BitConverter.ToString(encodedBytes).Replace("-", string.Empty).ToLower();
    }
}
