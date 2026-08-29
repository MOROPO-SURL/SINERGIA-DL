using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Abstractions;

public abstract class AbstractOperationReport : AbstractEntity<OperationReportId, long>, IAggregateRoot<OperationReportId, long>
{
    protected readonly List<Bridges.OperationReportDocumentBridge> documentBridges = [];

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
        IEnumerable<Bridges.OperationReportDocumentBridge> documentBridges,
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

        this.documentBridges = [.. documentBridges];
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

    public IReadOnlyList<Bridges.OperationReportDocumentBridge> DocumentBridges => [.. documentBridges];

    public void LinkDocumentById(DocumentId imageId) => documentBridges.Add(new Bridges.OperationReportDocumentBridge(Id, imageId));

    public void RemoveDocumentBridge(Bridges.OperationReportDocumentBridge bridge) => documentBridges.Remove(bridge);
}
