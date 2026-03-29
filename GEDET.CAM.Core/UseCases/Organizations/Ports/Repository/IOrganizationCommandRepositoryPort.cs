using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Organizations.Ports.Repository;

public interface IOrganizationCommandRepositoryPort : Common.Ports.Repository.IEntityCommandRepositoryPort<Organization, OrganizationId>
{
}