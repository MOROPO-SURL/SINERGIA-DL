using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using System.Security.Claims;

namespace MOROPO.GEDET.CAM.Core.UseCases.Authentication.DTOs;

public record AuthenticationIdentityDto(ClaimsIdentity Identity, UserBasicDto UserDetail);
