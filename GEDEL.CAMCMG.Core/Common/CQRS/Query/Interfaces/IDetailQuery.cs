using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;

public interface IDetailQuery<TId, TIdValue, TDetailDto> : MediatR.IRequest<TDetailDto>
    where TId : IId<TIdValue>
{
    public TIdValue Id { get; }
}