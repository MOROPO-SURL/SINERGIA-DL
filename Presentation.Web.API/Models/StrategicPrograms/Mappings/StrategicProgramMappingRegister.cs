using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.StrategicPrograms.Mappings;

public class StrategicProgramMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StrategicProgramCreateRequestModel, StrategicProgramCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest, src => src);
    }
}
