namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

public interface IUpdateCommand<TIdValue, TDetailDto> : MediatR.IRequest<TDetailDto>
{
    public TIdValue Id { get; }
}