using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.Mappings;

internal sealed class StrategicProjectIdeaEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, StrategicProjectIdeaId>().MapWith(src => new StrategicProjectIdeaId(src));

        config.NewConfig<StrategicProjectIdeaId, Guid>().MapWith(src => src.Value);

        config.NewConfig<StrategicProjectIdeaCreateCommand, StrategicProjectIdea>()
            .Map(dest => dest.Id, src => new StrategicProjectIdeaId(Guid.NewGuid()))
            .Map(dest => dest, src => src);
    }
}