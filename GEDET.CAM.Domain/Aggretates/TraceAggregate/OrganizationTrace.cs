using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate;

public class OrganizationTrace : Abstractions.AbstractTrace<OrganizationAggregate.Organization, OrganizationAggregate.OrganizationId>
{
    public OrganizationTrace(IDataIntegrityServicePort dataIntegrityService, TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, OrganizationAggregate.Organization organization, OrganizationAggregate.OrganizationId organizationId, string? beforeData, string? afterData) : base(dataIntegrityService, id, kind, author, createAt, organization, organizationId, beforeData, afterData)
    {
    }
}