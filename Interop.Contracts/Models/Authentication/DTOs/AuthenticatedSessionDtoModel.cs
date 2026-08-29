namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Authentication.DTOs;

public record AuthenticatedSessionDtoModel(string AuthenticationType, string AuthorizationToken, int SessionExpirationInSecond, User.DTOs.UserBasicDtoModel User, bool HasFullAccess, string[] Permissions);
