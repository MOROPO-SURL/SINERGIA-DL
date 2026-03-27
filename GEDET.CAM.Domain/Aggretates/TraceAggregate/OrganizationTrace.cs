using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate;

public class OrganizationTrace : Abstractions.AbstractTrace<OrganizationAggregate.Organization, OrganizationId>
{
    public OrganizationTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, OrganizationAggregate.Organization organization, OrganizationId organizationId, string? beforeData, string? afterData) : base(id, kind, author, createAt, organization, organizationId, signature, beforeData, afterData)
    {
    }
}