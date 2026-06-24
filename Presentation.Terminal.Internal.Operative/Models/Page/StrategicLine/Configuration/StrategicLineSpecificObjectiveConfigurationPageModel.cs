using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;

public sealed class StrategicLineSpecificObjectiveConfigurationPageModel : AbstractConfigurationPageModel<StrategicLineSpecificObjectiveDetailDtoModel, StrategicLineSpecificObjectiveDetailDtoModel>
{
    public static string IndexValidableProperty => nameof(Index);
    public static string ContentValidableProperty => nameof(Content);

    private int index = 1;
    private string content = null!;

    public StrategicLineSpecificObjectiveConfigurationPageModel(StrategicLineSpecificObjectiveDetailDtoModel? model, Action<StrategicLineSpecificObjectiveDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        Id = model.Id;
        index = model.Index;
        content = model.Content;
    }

    public Guid? Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public string Content { get => content; set => SetProperty(ref content, value); }

    protected override bool PresentChangeNotification => false;

    protected override Task<StrategicLineSpecificObjectiveDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new StrategicLineSpecificObjectiveDetailDtoModel(Guid.NewGuid(), Index, Content));
    }

    protected override Task<StrategicLineSpecificObjectiveDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new StrategicLineSpecificObjectiveDetailDtoModel(Id!.Value, Index, Content));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicLineSpecificObjectiveConfigurationPageModel>(this);
}