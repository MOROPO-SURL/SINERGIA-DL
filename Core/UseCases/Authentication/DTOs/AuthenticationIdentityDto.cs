using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using System.Security.Claims;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.DTOs;

public record AuthenticationIdentityDto(ClaimsIdentity Identity, UserDetailDto UserDetail);
