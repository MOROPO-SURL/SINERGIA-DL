namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

public interface IEnableCommand<TIdValue> : MediatR.IRequest
{
    public TIdValue Id { get; }
}
