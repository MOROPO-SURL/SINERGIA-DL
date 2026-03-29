using MediatR;
using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;

public record RolePaginateQuery(int Page, int Limit) : IRequest<PaginateQueryResultModel<RoleEssentialDto>>;