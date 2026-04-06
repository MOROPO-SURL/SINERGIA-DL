using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;

public interface IDetailQuery<TId, TIdValue, TDetailDto> : MediatR.IRequest<TDetailDto>
    where TId : IId<TIdValue>
{
    public TIdValue Id { get; }
}