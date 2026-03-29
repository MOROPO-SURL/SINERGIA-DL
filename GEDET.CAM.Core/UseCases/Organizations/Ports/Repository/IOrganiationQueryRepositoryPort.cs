using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Organizations.Ports.Repository;

public interface IOrganiationQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<Organization, OrganizationId>
{
}
