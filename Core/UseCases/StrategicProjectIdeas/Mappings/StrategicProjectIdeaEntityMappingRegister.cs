using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Mappings;

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