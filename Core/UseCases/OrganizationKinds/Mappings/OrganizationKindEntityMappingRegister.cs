using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Mappings;

internal sealed class OrganizationKindEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, OrganizationKindId>()
            .MapWith(src => new OrganizationKindId(src));

        config.NewConfig<OrganizationKind, OrganizationKindBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<OrganizationKind, OrganizationKindDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<OrganizationKindDetailQuery, OrganizationKindId>()
            .MapWith(src => new OrganizationKindId(src.Id));

        config.NewConfig<OrganizationKindCreateCommand, OrganizationKind>()
            .MapWith(src => new(
                new OrganizationKindId(Guid.NewGuid()),
                src.IsEnabled,
                src.Priority,
                src.Name,
                src.DevelopmentActorProfileKind,
                src.Description
            ));

        config.NewConfig<OrganizationKindUpdateCommand, OrganizationKind>()
            .Map(dest => dest.Id, src => new OrganizationKindId(src.Id))
            .Map(dest => dest, src => src);
    }
}
