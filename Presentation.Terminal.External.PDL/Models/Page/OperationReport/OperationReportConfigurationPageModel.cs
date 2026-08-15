using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Interop.Connect.Client;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.OperationReport;

public sealed class OperationReportConfigurationPageModel : AbstractConfigurationPageModel<PDLOperationReportDetailDtoModel, PDLOperationReportDetailDtoModel>
{
    public static string DescriptionValidableProperty => nameof(Description);
    public static string IncomeValidableProperty => nameof(Income);
    public static string FemaleEmployeeCountValidableProperty => nameof(FemaleEmployeeCount);
    public static string DiscapacityEmployeeCountValidableProperty => nameof(DiscapacityEmployeeCount);

    private DateTime period;
    private int employeeCount;
    private int femaleEmployeeCount;
    private int discapacityEmployeeCount;
    private float gridEnergySpend;
    private float renerenewableEnergyGeneration;
    private float renerenewableEnergyExportation;
    private float income;
    private float incomeBankDeposit;
    private float periodResult;
    private float camComission;
    private string? description;

    public OperationReportConfigurationPageModel(Guid ownerId, PDLOperationReportDetailDtoModel? model, Action<PDLOperationReportDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        OwnerId = ownerId;

        DateTime now = DateTime.Now;

        Id = model?.Id;
        period = new DateTime(model?.Period ?? new DateOnly(now.Year, now.Month, 28), default);
        employeeCount = model?.EmployeeCount ?? 0;
        femaleEmployeeCount = model?.FemaleEmployeeCount ?? 0;
        discapacityEmployeeCount = model?.DiscapacityEmployeeCount ?? 0;
        gridEnergySpend = model?.GridEnergySpend ?? 0;
        renerenewableEnergyGeneration = model?.RenerenewableEnergyGeneration ?? 0;
        renerenewableEnergyExportation = model?.RenerenewableEnergyExportation ?? 0;
        income = model?.Income ?? 0;
        incomeBankDeposit = model?.IncomeBankDeposit ?? 0;
        periodResult = model?.PeriodResult ?? 0;
        camComission = model?.CAMComission ?? 0;
        description = model?.Description;
    }

    public override IValidationContext? ValidationContext => new ValidationContext<OperationReportConfigurationPageModel>(this);

    protected override Task<PDLOperationReportDetailDtoModel> PerformCreationAsync()
    {
        PDLOperationReportCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new PDLOperationReportCreateRequestModel
            (
                OwnerId,
                DateOnly.FromDateTime(period),
                employeeCount,
                femaleEmployeeCount,
                discapacityEmployeeCount,
                gridEnergySpend,
                renerenewableEnergyGeneration,
                RenerenewableEnergyExportation,
                income,
                incomeBankDeposit,
                periodResult,
                camComission,
                Description
            ));
    }

    protected override Task<PDLOperationReportDetailDtoModel> PerformEditionAsync()
    {
        PDLOperationReportCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new PDLOperationReportUpdateRequestModel
            (
                Id!.Value,
                DateOnly.FromDateTime(period),
                employeeCount,
                femaleEmployeeCount,
                discapacityEmployeeCount,
                gridEnergySpend,
                renerenewableEnergyGeneration,
                RenerenewableEnergyExportation,
                income,
                incomeBankDeposit,
                periodResult,
                camComission,
                Description
            ));
    }

    public long? Id { get; init; }

    public Guid OwnerId { get; init; }

    public DateTime Period { get => period; set => SetProperty(ref period, new DateTime(value.Year, value.Month, 28), ReviewPeriod); }

    public int EmployeeCount { get => employeeCount; set => SetProperty(ref employeeCount, value); }

    public int FemaleEmployeeCount { get => femaleEmployeeCount; set => SetProperty(ref femaleEmployeeCount, value); }
    
    public int DiscapacityEmployeeCount { get => discapacityEmployeeCount; set => SetProperty(ref discapacityEmployeeCount, value); }
    public float GridEnergySpend { get => gridEnergySpend; set => SetProperty(ref gridEnergySpend, value); }

    public float RenerenewableEnergyGeneration { get => renerenewableEnergyGeneration; set => SetProperty(ref renerenewableEnergyGeneration, value); }

    public float RenerenewableEnergyExportation { get => renerenewableEnergyExportation; set => SetProperty(ref renerenewableEnergyExportation, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public float Income { get => income; set => SetProperty(ref income, value); }

    public float IncomeBankDeposit { get => incomeBankDeposit; set => SetProperty(ref incomeBankDeposit, value); }

    public float PeriodResult { get => periodResult; set => SetProperty(ref periodResult, value); }

    public float CAMComission { get => camComission; set => SetProperty(ref camComission, value); }

    private void ReviewPeriod()
    {
        if (period.Day == 28) return;

        Period = new DateTime(period.Year, period.Month, 28);
    }
}