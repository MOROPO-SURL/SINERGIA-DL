using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Command.Create;

internal sealed class MacroprogramCreateCommandHandler: AbstractCreateCommandHandler<Macroprogram, MacroprogramId, Guid, MacroprogramCreateCommand, MacroprogramDetailDto>, IRequestHandler<MacroprogramCreateCommand, MacroprogramDetailDto>
{
    public MacroprogramCreateCommandHandler(IMacroprogramCommandRepositoryPort entityCommandRepository, IMacroprogramQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
