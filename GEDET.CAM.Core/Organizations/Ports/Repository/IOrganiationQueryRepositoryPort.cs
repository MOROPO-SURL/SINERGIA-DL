using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.Organizations.Ports.Repository;

public interface IOrganiationQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<Organization, OrganizationId>
{
}
