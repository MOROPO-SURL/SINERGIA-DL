namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;

public interface IUpdateCommand<TIdValue, TDetailDto> : MediatR.IRequest<TDetailDto>
{
    public TIdValue Id { get; }
}