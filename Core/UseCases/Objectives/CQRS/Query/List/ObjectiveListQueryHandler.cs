using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Query.List;

internal sealed class ObjectiveListQueryHandler :
    AbstractListQueryHandler<Objective, ObjectiveId, Guid, ObjectiveDetailDto, ObjectiveListQuery>,
    IRequestHandler<ObjectiveListQuery, ObjectiveDetailDto[]>
{
    public ObjectiveListQueryHandler(IObjectiveQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}