using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Remove;

internal sealed class MacroprogramRemoveCommandHandler: AbstractRemoveCommandHandler<Macroprogram, MacroprogramId, Guid, MacroprogramRemoveCommand>, IRequestHandler<MacroprogramRemoveCommand>
{
    public MacroprogramRemoveCommandHandler(IMacroprogramCommandRepositoryPort entityCommandRepository, IMacroprogramQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
