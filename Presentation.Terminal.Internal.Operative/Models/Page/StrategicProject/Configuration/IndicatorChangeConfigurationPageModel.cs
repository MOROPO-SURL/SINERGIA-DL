using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;

public sealed class IndicatorChangeConfigurationPageModel : AbstractConfigurationPageModel<IndicatorChangeDetailDtoModel, IndicatorChangeDetailDtoModel>
{
    public static string ContextValidableProperty => nameof(Context);

    public static DateTime MAX_AT => DateTime.Now;

    private DateTime at = DateTime.Now;
    private float amount;
    private string? context;

    public IndicatorChangeConfigurationPageModel(Guid programId, Guid indicatorId, string indicatorName, UnitMeasurementBasicDtoModel unitMeasurement, Action<IndicatorChangeDetailDtoModel> successCallbackAction, IValidator validator) : base(null, successCallbackAction, validator)
    {
        ProjectId = programId;
        IndicatorId = indicatorId;
        IndicatorName = indicatorName;
        UnitMeasurement = unitMeasurement;
    }

    public Guid ProjectId { get; init; }

    public Guid IndicatorId { get; init; }

    public string IndicatorName { get; init; }

    public UnitMeasurementBasicDtoModel UnitMeasurement { get; init; }

    public DateTime At { get => at; set => SetProperty(ref at, value); }

    public float Amount { get => amount; set => SetProperty(ref amount, value); }

    public string? Context { get => context; set => SetProperty(ref context, value); }

    public override IValidationContext? ValidationContext => new ValidationContext<IndicatorChangeConfigurationPageModel>(this);

    protected override Task<IndicatorChangeDetailDtoModel> PerformCreationAsync()
    {
        StrategicProjectIndicatorChangeCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new IndicatorChangeCreateRequestModel
            (
                At,
                ProjectId,
                IndicatorId,
                Amount,
                context
            ));
    }

    protected override Task<IndicatorChangeDetailDtoModel> PerformEditionAsync()
    {
        throw new InvalidOperationException();
    }
}