using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Create;

internal sealed class StrategicProjectKindCreateCommandHandler :
    AbstractCreateCommandHandler<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindCreateCommand, StrategicProjectKindDetailDto>,
    IRequestHandler<StrategicProjectKindCreateCommand, StrategicProjectKindDetailDto>
{
    private readonly IDataIntegrityServicePort dataIntegrityService;

    public StrategicProjectKindCreateCommandHandler(IStrategicProjectKindCommandRepositoryPort entityCommandRepository, IStrategicProjectKindQueryRepositoryPort entityQueryRepository, IMapper mapper, IDataIntegrityServicePort dataIntegrityService)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.dataIntegrityService = dataIntegrityService;
    }
}