using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.UnitMeasurement;

public sealed class UnitMeasurementConfigurationPageModel: AbstractConfigurationPageModel<UnitMeasurementDetailDtoModel, UnitMeasurementDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string SymbolValidableProperty => nameof(Symbol);

    private string name = null!;
    private string symbol = null!;
    private bool prefixed;
    private int priority = 1;

    public UnitMeasurementConfigurationPageModel(UnitMeasurementDetailDtoModel? model, Action<UnitMeasurementDetailDtoModel> successCallbackAction) : base(model, successCallbackAction, new UnitMeasurementConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        name = model.Name;
        symbol = model.Symbol;
        prefixed = model.Prefixed;
        priority = model.Priority;
    }

    public Guid? Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string Symbol { get => symbol; set => SetProperty(ref symbol, value); }

    public bool Prefixed { get => prefixed; set => SetProperty(ref prefixed, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    protected override Task<UnitMeasurementDetailDtoModel> PerformCreationAsync()
    {
        UnitMeasurementCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new UnitMeasurementCreateRequestModel
            (
                Name!,
                Symbol!,
                Prefixed,
                Priority
            ));
    }

    protected override Task<UnitMeasurementDetailDtoModel> PerformEditionAsync()
    {
        UnitMeasurementCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new UnitMeasurementUpdateRequestModel
            (
                Id!.Value,
                Name!,
                Symbol!,
                Prefixed,
                Priority
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<UnitMeasurementConfigurationPageModel>(this);
}
