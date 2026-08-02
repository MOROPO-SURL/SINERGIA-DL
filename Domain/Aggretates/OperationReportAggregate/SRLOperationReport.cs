using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;

public sealed class SRLOperationReport : Abstractions.AbstractOperationReport
{
    private SRLOperationReport() { }

    public SRLOperationReport(
        OperationReportId id, 
        DevelopmentActorProfileId ownerId,
        DateTime at,
        DateOnly period, 
        int employeeCount, 
        int femaleEmployeeCount, 
        int discapacityEmployeeCount,
        float gridEnergySpend,
        float renerenewableEnergyGeneration,
        float renerenewableEnergyExportation,
        IEnumerable<OperationReportAccountingEntry> accountingEntries, 
        string? description = null, 
        SRLDevelopmentActorProfile? owner = null)
        : base(id, ownerId, at, period, employeeCount, femaleEmployeeCount, discapacityEmployeeCount, gridEnergySpend, renerenewableEnergyGeneration, renerenewableEnergyExportation, accountingEntries, description)
    {
        Owner = owner;
    }

    public SRLDevelopmentActorProfile? Owner { get; set; }
}
