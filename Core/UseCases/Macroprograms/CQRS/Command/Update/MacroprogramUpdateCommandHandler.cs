using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Command.Update;

internal sealed class MacroprogramUpdateCommandHandler: AbstractUpdateCommandHandler<Macroprogram, MacroprogramId, Guid, MacroprogramUpdateCommand, MacroprogramDetailDto>,
    IRequestHandler<MacroprogramUpdateCommand, MacroprogramDetailDto>
{
    public MacroprogramUpdateCommandHandler(IMacroprogramCommandRepositoryPort entityCommandRepository, IMacroprogramQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
