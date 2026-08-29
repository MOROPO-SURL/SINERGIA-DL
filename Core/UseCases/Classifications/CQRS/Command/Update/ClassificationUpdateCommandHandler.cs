using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Update;

internal sealed class ClassificationUpdateCommandHandler :
    AbstractUpdateCommandHandler<Classification, ClassificationId, Guid, ClassificationUpdateCommand, ClassificationDetailDto>,
    IRequestHandler<ClassificationUpdateCommand, ClassificationDetailDto>
{
    public ClassificationUpdateCommandHandler(IClassificationQueryRepositoryPort entityQueryRepository, IClassificationCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}