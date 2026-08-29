namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

public interface IRemoveCommand<TIdValue> : MediatR.IRequest
{
    public TIdValue Id { get; }
}