namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

public interface IUnarchiveCommand<TIdValue> : MediatR.IRequest
{
    public TIdValue Id { get; }
}
