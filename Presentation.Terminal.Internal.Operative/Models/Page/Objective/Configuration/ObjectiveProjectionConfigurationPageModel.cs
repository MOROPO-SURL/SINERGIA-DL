using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

public sealed class ObjectiveProjectionConfigurationPageModel : AbstractConfigurationPageModel<ObjectiveProjectionDetailDtoModel, ObjectiveProjectionDetailDtoModel>
{
    public static string IndexValidableProperty => nameof(Index);
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private string? title;
    private string? description;

    public ObjectiveProjectionConfigurationPageModel(ObjectiveProjectionDetailDtoModel? model, Action<ObjectiveProjectionDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
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

    protected override bool PresentChangeNotification => false;

    protected override Task<ObjectiveProjectionDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new ObjectiveProjectionDetailDtoModel(Guid.NewGuid(), Index, Title!, Description));
    }

    protected override Task<ObjectiveProjectionDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new ObjectiveProjectionDetailDtoModel(Id!.Value, Index, Title!, Description));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<ObjectiveProjectionConfigurationPageModel>(this);
}