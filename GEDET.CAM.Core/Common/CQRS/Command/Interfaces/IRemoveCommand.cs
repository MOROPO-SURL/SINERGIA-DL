namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Remove;

public interface IRemoveCommand<TIdValue> : MediatR.IRequest
{
    public TIdValue Id { get; }
}