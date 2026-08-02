using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Abstractions;

public abstract class AbstractOperationReport : AbstractEntity<OperationReportId, long>, IAggregateRoot<OperationReportId, long>
{
    protected List<Entities.OperationReportAccountingEntry> accountingEntries = [];

    internal protected AbstractOperationReport() : base(default) { }

    protected AbstractOperationReport(
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
        IEnumerable<Entities.OperationReportAccountingEntry> accountingEntries,
        string? description = null) : base(id)
    {
        OwnerId = ownerId;
        At = at;
        Period = period;
        EmployeeCount = employeeCount;
        FemaleEmployeeCount = femaleEmployeeCount;
        DiscapacityEmployeeCount = discapacityEmployeeCount;
        GridEnergySpend = gridEnergySpend;
        RenerenewableEnergyGeneration = renerenewableEnergyGeneration;
        RenerenewableEnergyExportation = renerenewableEnergyExportation;
        Description = description;

        this.accountingEntries = [.. accountingEntries];
    }

    public DevelopmentActorProfileId OwnerId { get; set; }

    public DateOnly Period { get; set; }

    public DateTime At { get; set; }

    public int EmployeeCount { get; set; }

    public int FemaleEmployeeCount { get; set; }

    public int DiscapacityEmployeeCount { get; set; }

    public float GridEnergySpend { get; set; }

    public float RenerenewableEnergyGeneration { get; set; }

    public float RenerenewableEnergyExportation { get; set; }

    public string? Description { get; set; }

    public IReadOnlyList<Entities.OperationReportAccountingEntry> AccountingEntries => [.. accountingEntries];
}
