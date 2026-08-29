using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

public sealed class SpecificObjectiveClippedConfigurationPageModel : AbstractConfigurationPageModel<SpecificObjectiveDetailDtoModel, SpecificObjectiveDetailDtoModel>
{
    public static string IndexValidableProperty => nameof(Index);
    public static string ContentValidableProperty => nameof(Content);

    private int index = 1;
    private string content = null!;

    public SpecificObjectiveClippedConfigurationPageModel(SpecificObjectiveDetailDtoModel? model, Action<SpecificObjectiveDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
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

    protected override Task<SpecificObjectiveDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new SpecificObjectiveDetailDtoModel(Guid.NewGuid(), Index, Content));
    }

    protected override Task<SpecificObjectiveDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new SpecificObjectiveDetailDtoModel(Id!.Value, Index, Content));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<SpecificObjectiveClippedConfigurationPageModel>(this);
}