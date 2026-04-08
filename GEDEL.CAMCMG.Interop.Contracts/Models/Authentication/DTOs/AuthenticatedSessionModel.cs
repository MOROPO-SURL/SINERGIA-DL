namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Authentication.DTOs;

public record AuthenticatedSessionModel(string AuthenticationType, string AuthorizationToken, int SessionExpirationInSecond, User.DTOs.UserBasicModel User, bool HasFullAccess, string[] Permissions);
