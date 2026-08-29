using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;

public sealed class PDLOperationReport : Abstractions.AbstractOperationReport
{
    private PDLOperationReport() { }

    public PDLOperationReport(
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
        float income,
        float incomeBankDeposit,
        float periodResult,
        float camComission,
        IEnumerable<Bridges.OperationReportDocumentBridge> documentBridges,
        string? description = null,
        AbstractPDLDevelopmentActorProfile? owner = null)
        : base(id, ownerId, at, period, employeeCount, femaleEmployeeCount, discapacityEmployeeCount, gridEnergySpend, renerenewableEnergyGeneration, renerenewableEnergyExportation, documentBridges, description)
    {
        Owner = owner;
        Income = income;
        IncomeBankDeposit = incomeBankDeposit;
        PeriodResult = periodResult;
        CAMComission = camComission;
    }

    public AbstractPDLDevelopmentActorProfile? Owner { get; set; }

    public float Income { get; set; }

    public float IncomeBankDeposit { get; set; }

    public float PeriodResult { get; set; }

    public float CAMComission { get; set; }
}
