using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration.Clipped
{
    public sealed class SpecificObjectiveProjectClippedConfigurationPageModel : AbstractConfigurationPageModel<SpecificObjectiveProjectDetailDtoModel, SpecificObjectiveProjectDetailDtoModel>
    {
        public static string IndexValidableProperty => nameof(Index);
        public static string ContentValidableProperty => nameof(Content);

        private int index = 1;
        private string content = null!;

        public SpecificObjectiveProjectClippedConfigurationPageModel(SpecificObjectiveProjectDetailDtoModel? model, Action<SpecificObjectiveProjectDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
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

        protected override Task<SpecificObjectiveProjectDetailDtoModel> PerformCreationAsync()
        {
            return Task.FromResult(new SpecificObjectiveProjectDetailDtoModel(Guid.NewGuid(), Index, Content));
        }

        protected override Task<SpecificObjectiveProjectDetailDtoModel> PerformEditionAsync()
        {
            return Task.FromResult(new SpecificObjectiveProjectDetailDtoModel(Id!.Value, Index, Content));
        }

        public override IValidationContext? ValidationContext => new ValidationContext<SpecificObjectiveProjectClippedConfigurationPageModel>(this);
    }
}
