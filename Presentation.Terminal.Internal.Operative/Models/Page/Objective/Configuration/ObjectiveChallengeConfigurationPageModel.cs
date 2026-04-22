using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

public sealed class ObjectiveChallengeConfigurationPageModel : AbstractConfigurationPageModel<ObjectiveChallengeDetailDtoModel, ObjectiveChallengeDetailDtoModel>
{
    public static string IndexValidableProperty => nameof(Index);
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private string? title;
    private string? description;

    public ObjectiveChallengeConfigurationPageModel(ObjectiveChallengeDetailDtoModel? model, Action<ObjectiveChallengeDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        index = model.Index;
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public string? Title { get => title; set => SetProperty(ref title, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    protected override Task<ObjectiveChallengeDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new ObjectiveChallengeDetailDtoModel(Guid.NewGuid(), Index, Title!, Description));
    }

    protected override Task<ObjectiveChallengeDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new ObjectiveChallengeDetailDtoModel(Id!.Value, Index, Title!, Description));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<ObjectiveChallengeConfigurationPageModel>(this);
}