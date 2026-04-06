namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;

public record RoleDetailQuery(Guid Id) : MediatR.IRequest<DTOs.RoleDetailDto>;
