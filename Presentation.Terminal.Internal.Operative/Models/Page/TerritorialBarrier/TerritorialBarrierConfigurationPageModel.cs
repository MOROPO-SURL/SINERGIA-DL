using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritorialBarrier;

public sealed class TerritorialBarrierConfigurationPageModel : AbstractConfigurationPageModel<TerritorialBarrierDetailDtoModel, TerritorialBarrierDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title = null!;
    private string? description;

    public TerritorialBarrierConfigurationPageModel(TerritorialBarrierDetailDtoModel? model, Action<TerritorialBarrierDetailDtoModel> successCallbackAction) : base(model, successCallbackAction, new TerritorialBarrierConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        title = model.Title;
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    protected override Task<TerritorialBarrierDetailDtoModel> PerformCreationAsync()
    {
        TerritorialBarrierCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new TerritorialBarrierCreateRequestModel
            (
                Title!,
                Description
            ));
    }

    protected override Task<TerritorialBarrierDetailDtoModel> PerformEditionAsync()
    {
        TerritorialBarrierCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new TerritorialBarrierUpdateRequestModel
            (
                Id!.Value,
                Title!,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<TerritorialBarrierConfigurationPageModel>(this);
}
