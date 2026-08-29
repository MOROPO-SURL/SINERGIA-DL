using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;

public interface IDetailQuery<TId, TIdValue, TDetailDto> : MediatR.IRequest<TDetailDto>
    where TId : IId<TIdValue>
{
    public TIdValue Id { get; }
}