namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Configurations;

public sealed class JWTConfiguration
{
    public string Issuer { get; set; } = null!;

    public string JwtSecretKey { get; set; } = null!;

    public int ExpiresInSecond { get; set; }
}
