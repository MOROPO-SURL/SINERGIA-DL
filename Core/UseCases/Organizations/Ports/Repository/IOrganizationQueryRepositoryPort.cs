using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.Ports.Repository;

public interface IOrganizationQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<Organization, OrganizationId, Guid>
{
}
