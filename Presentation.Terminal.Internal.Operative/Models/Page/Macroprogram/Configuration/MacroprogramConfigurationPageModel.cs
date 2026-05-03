using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Macroprogram.Configuration;

public sealed class MacroprogramConfigurationPageModel : AbstractConfigurationPageModel<MacroprogramDetailDtoModel, MacroprogramDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private string? title;
    private string? description;

    public MacroprogramConfigurationPageModel(MacroprogramDetailDtoModel? model, Action<MacroprogramDetailDtoModel> successActionCallback) : base(model, successActionCallback, new MacroprogramConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        index = model.Index;
        title = model.Title;
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public string? Title { get => title; set => SetProperty(ref title, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    protected override Task<MacroprogramDetailDtoModel> PerformCreationAsync()
    {
        MacroprogramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new MacroprogramCreateRequestModel
            (
                Index,
                Title!,
                Description
            ));
    }

    protected override Task<MacroprogramDetailDtoModel> PerformEditionAsync()
    {
        MacroprogramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new MacroprogramUpdateRequestModel
            (
                Id!.Value,
                Index,
                Title!,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<MacroprogramConfigurationPageModel>(this);
}
