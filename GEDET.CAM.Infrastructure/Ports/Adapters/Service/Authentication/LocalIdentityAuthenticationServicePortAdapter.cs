using MapsterMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MOROPO.GEDET.CAM.Core.Common.Ports.Service;
using MOROPO.GEDET.CAM.Core.UseCases.Authentication.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Authentication.Ports.Service;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;
using MOROPO.GEDET.CAM.Infrastructure.Configurations;
using MOROPO.GEDET.CAM.Infrastructure.Constants;
using System.Security.Claims;

namespace MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Service.Authentication;

internal class LocalIdentityAuthenticationServicePortAdapter : IIdentityAuthenticationServicePort
{
    private readonly IOptions<AuthenticationConfiguration> authenticationConfigurationOptions;
    private readonly IUserQueryRepositoryPort userQueryRepository;
    private readonly IUserCommandRepositoryPort userCommandRepository;
    private readonly IDataIntegrityServicePort serviceIntegrityService;
    private readonly IStringHashingServicePort stringHashingService;
    private readonly ILogger<LocalIdentityAuthenticationServicePortAdapter> logger;
    private readonly IMapper mapper;

    public LocalIdentityAuthenticationServicePortAdapter(
        IOptions<AuthenticationConfiguration> identityAuthenticationOptions,
        IUserQueryRepositoryPort userQueryRepository,
        IUserCommandRepositoryPort userCommandRepository,
        IDataIntegrityServicePort serviceIntegrityService,
        IStringHashingServicePort stringHashingService,
        ILogger<LocalIdentityAuthenticationServicePortAdapter> logger,
        IMapper mapper)
    {
        authenticationConfigurationOptions = identityAuthenticationOptions;
        this.userQueryRepository = userQueryRepository;
        this.userCommandRepository = userCommandRepository;
        this.serviceIntegrityService = serviceIntegrityService;
        this.stringHashingService = stringHashingService;
        this.logger = logger;
        this.mapper = mapper;
    }

    public async Task<AuthenticationIdentityDto> AuthenticateIdentityAsync(string username, string password, string authenticationType)
    {
        var userId = new UserId(username);

        User? user = await userQueryRepository.FindOneByAsync(entity => entity.Id == userId);

        if (user == null)
        {
            // User not found!!
            throw new ArgumentOutOfRangeException();
        }

        if (!user.Signature.Equals(await serviceIntegrityService.GetEntitySignatureAsync(user)))
        {
            // User signature validation fail!!
            throw new InvalidDataException();
        }

        if (!user.IsEnabled)
        {
            // User disabled!!
            throw new InvalidOperationException();
        }

        if (!user.Password.Equals(stringHashingService.GetHashed(password)))
        {
            user.FailAuthenticationCount++;

            if (user.FailAuthenticationCount > authenticationConfigurationOptions.Value.MaxFailCount)
            {
                user.FailAuthenticationCount = 0;
                user.IsEnabled = false;
                user.Signature = await serviceIntegrityService.GetEntitySignatureAsync(user);

                await userCommandRepository.UpdateAsync(user);

                logger.LogInformation("User '{0}' reach fail authentication count limit ({1}) and was authomatically disabled.", username, authenticationConfigurationOptions.Value.MaxFailCount);

                // Max authentication failure reached!!
                throw new AccessViolationException();
            }

            await userCommandRepository.UpdateAsync(user);

            // Credentials missmatch!!  
            throw new UnauthorizedAccessException();
        }

        List<Claim> claims = [];

        if (user.IsEnabled)
        {
            user.FailAuthenticationCount = 0;
            user.LastSessionDate = DateTime.Now;

            await userCommandRepository.UpdateAsync(user);
        }

        claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.Value));

        if (user.HasFullAccess)
        {
            claims.Add(new Claim(AuthorizationConstants.ClaimTypes.FULL_ACCESS, true.ToString(), typeof(bool).ToString()));
        }

        if (user.IsPasswordChangeRequired)
        {
            claims.Add(new Claim(AuthorizationConstants.ClaimTypes.CHANGE_PASSWORD_REQUIRED, true.ToString(), typeof(bool).ToString()));
        }

        foreach (var bridge in user.RoleBridges)
        {
            var signature = await serviceIntegrityService.GetEntitySignatureAsync(bridge);

            if (!bridge.Signature.Equals(signature)) continue;

            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, bridge.LinkedId.ToString()));
        }

        return new AuthenticationIdentityDto(new ClaimsIdentity(claims, authenticationType), mapper.Map<UserBasicDto>(user));
    }
}