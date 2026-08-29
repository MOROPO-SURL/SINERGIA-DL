using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;

public class OrganizationTrace : Abstractions.AbstractTrace<Organization, OrganizationId, Guid>
{
    private OrganizationTrace() { }

    public OrganizationTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, OrganizationId? organizationId = null, Organization? organization = null) : base(id, kind, author, createAt, signature, beforeData, afterData, organizationId, organization)
    {
    }
}