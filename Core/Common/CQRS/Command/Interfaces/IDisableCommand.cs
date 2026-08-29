namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

public interface IDisableCommand<TIdValue> : MediatR.IRequest
{
    public TIdValue Id { get; }
}
