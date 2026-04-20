namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

public interface IArchiveCommand<TIdValue> : MediatR.IRequest
{
    public TIdValue Id { get; }
}
