using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Create;

internal sealed class ClassificationCreateCommandHandler :
    AbstractCreateCommandHandler<Classification, ClassificationId, Guid, ClassificationCreateCommand, ClassificationDetailDto>,
    IRequestHandler<ClassificationCreateCommand, ClassificationDetailDto>
{
    public ClassificationCreateCommandHandler(IClassificationCommandRepositoryPort entityCommandRepository, IClassificationQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}