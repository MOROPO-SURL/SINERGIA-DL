using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Create;

internal sealed class MacroprogramCreateCommandHandler: AbstractCreateCommandHandler<Macroprogram, MacroprogramId, Guid, MacroprogramCreateCommand, MacroprogramDetailDto>, IRequestHandler<MacroprogramCreateCommand, MacroprogramDetailDto>
{
    public MacroprogramCreateCommandHandler(IMacroprogramCommandRepositoryPort entityCommandRepository, IMacroprogramQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
