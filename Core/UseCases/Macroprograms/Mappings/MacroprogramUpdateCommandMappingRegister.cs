using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Mappings;

internal sealed class MacroprogramUpdateCommandMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MacroprogramUpdateCommand, Macroprogram>()
            .Map(dest => dest.Id, src => new MacroprogramId(src.Id))
            .Map(dest => dest, src => src);
    }
}
