using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Mappings;

internal sealed class TerritoryPotentialEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, TerritoryPotentialId>()
            .MapWith(src => new TerritoryPotentialId(src));

        config.NewConfig<TerritoryPotential, TerritoryPotentialBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<TerritoryPotential, TerritoryPotentialDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<TerritoryPotentialDetailQuery, TerritoryPotentialId>()
            .MapWith(src => new TerritoryPotentialId(src.Id));

        config.NewConfig<TerritoryPotentialCreateCommand, TerritoryPotential>()
            .MapWith(src => new(
                new TerritoryPotentialId(Guid.NewGuid()),
                false,
                src.Title,
                src.Description
            ));

        config.NewConfig<TerritoryPotentialUpdateCommand, TerritoryPotential>()
            .Map(dest => dest.Id, src => new TerritoryPotentialId(src.Id))
            .Map(dest => dest, src => src);
    }
}