using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Update;

internal sealed class MacroprogramUpdateCommandHandler: AbstractUpdateCommandHandler<Macroprogram, MacroprogramId, Guid, MacroprogramUpdateCommand, MacroprogramDetailDto>,
    IRequestHandler<MacroprogramUpdateCommand, MacroprogramDetailDto>
{
    public MacroprogramUpdateCommandHandler(IMacroprogramCommandRepositoryPort entityCommandRepository, IMacroprogramQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
