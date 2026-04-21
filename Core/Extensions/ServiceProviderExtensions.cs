using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Mappings;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Mappings;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Extensions;

public static class ServiceProviderExtensions
{
    public static void ApplyCoreMappings(this IServiceProvider provider)
    {
        IStringHashingServicePort stringHashingService = provider.GetService<IStringHashingServicePort>()!;

        TypeAdapterConfig.GlobalSettings.Apply(
            new UserDetailDtoMappingRegister(),
            new UserBasicDtoMappingRegister(provider.GetRequiredService<IDataIntegrityServicePort>()),
            new UserDetailQueryMappingRegister(),
            new UserCreateCommandMappingRegister(stringHashingService),
            new UserUpdateCommandMappingRegister(),
            new PasswordUserUpdateCommandMappingRegister(stringHashingService),
            new UserCreateCommandMappingRegister(stringHashingService),
            new PrimitivesUserMappingRegister(),

            new RoleBasicDtoMappingRegister(),
            new RoleDetailDtoMappingRegister(),
            new RoleCreateCommandMappingRegister(),

            new ApiKeyBasicDtoMappingRegister(),
            new ApiKeyDetailDtoMappingRegister(),
            new ApiKeyDetailQueryMappingRegister(),
            new ApiKeyCreateCommandMappingRegister(stringHashingService),
            new ApiKeyUpdateCommandMappingRegister(),
            new PrimitivesApiKeyMappingRegister(),

            new ObjectiveEntityMappingRegister(),

            new PermissionDetailDtoMappingRegister(),

            new PrimitivesUnitMeasurementMappingRegister(),
            new UnitMeasurementBasicDtoMappingRegister(),
            new UnitMeasurementCreateCommandMappingRegister(),
            new UnitMeasurementDetailDtoMappingRegister(),
            new UnitMeasurementDetailQueryMappingRegister(),
            new UnitMeasurementUpdateCommandMappingRegister(),

            new PrimitivesInterestAreaMappingRegister(),
            new InterestAreaBasicDtoMappingRegister(),
            new InterestAreaCreateCommandMappingRegister(),
            new InterestAreaDetailDtoMappingRegister(),
            new InterestAreaDetailQueryMappingRegister(),
            new InterestAreaUpdateCommandMappingRegister(),

            new PrimitivesMacroprogramMappingRegister(),
            new MacroprogramBasicDtoMappingRegister(),
            new MacroprogramCreateCommandMappingRegister(),
            new MacroprogramDetailDtoMappingRegister(),
            new MacroprogramDetailQueryMappingRegister(),
            new MacroprogramUpdateCommandMappingRegister(),

            new PrimitivesPublicPolicyMappingRegister(),
            new PublicPolicyBasicDtoMappingRegister(),
            new PublicPolicyCreateCommandMappingRegister(),
            new PublicPolicyDetailDtoMappingRegister(),
            new PublicPolicyDetailQueryMappingRegister(),
            new PublicPolicyUpdateCommandMappingRegister()
        );
    }
}
