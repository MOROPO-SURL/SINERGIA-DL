using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Query.Detail;

public record UserDetailQuery(string Id) : IDetailQuery<UserId, string, DTOs.UserDetailDto>;