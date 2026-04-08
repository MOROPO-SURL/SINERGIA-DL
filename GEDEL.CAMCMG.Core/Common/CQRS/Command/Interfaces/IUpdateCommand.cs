namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

public interface IUpdateCommand<TIdValue, TDetailDto> : MediatR.IRequest<TDetailDto>
{
    public TIdValue Id { get; }
}