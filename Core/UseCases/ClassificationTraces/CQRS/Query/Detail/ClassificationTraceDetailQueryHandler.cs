using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ClassificationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Query.Detail;

internal sealed class ClassificationTraceDetailQueryHandler :
    AbstractDetailQueryHandler<ClassificationTrace, TraceId, long, ClassificationTraceDetailQuery, ClassificationTraceDetailDto>,
    IRequestHandler<ClassificationTraceDetailQuery, ClassificationTraceDetailDto>
{
    public ClassificationTraceDetailQueryHandler(IClassificationTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}