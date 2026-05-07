using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ClassificationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Query.Detail;

internal sealed class ClassificationTraceDetailQueryHandler :
    AbstractDetailQueryHandler<ClassificationTrace, TraceId, long, ClassificationTraceDetailQuery, ClassificationTraceDetailDto>,
    IRequestHandler<ClassificationTraceDetailQuery, ClassificationTraceDetailDto>
{
    public ClassificationTraceDetailQueryHandler(IClassificationTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}