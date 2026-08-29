using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Create;

internal sealed class FeatureKindCreateCommandHandler :
    AbstractCreateCommandHandler<FeatureKind, FeatureKindId, Guid, FeatureKindCreateCommand, FeatureKindDetailDto>,
    IRequestHandler<FeatureKindCreateCommand, FeatureKindDetailDto>
{
    private readonly IDataIntegrityServicePort dataIntegrityService;

    public FeatureKindCreateCommandHandler(IFeatureKindCommandRepositoryPort entityCommandRepository, IFeatureKindQueryRepositoryPort entityQueryRepository, IMapper mapper, IDataIntegrityServicePort dataIntegrityService)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.dataIntegrityService = dataIntegrityService;
    }
}