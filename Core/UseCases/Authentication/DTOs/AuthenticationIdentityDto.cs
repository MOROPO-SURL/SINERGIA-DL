using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;
using System.Security.Claims;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.DTOs;

public record AuthenticationIdentityDto(ClaimsIdentity Identity, UserDetailDto UserDetail);
