using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration.Clipped
{
    public sealed class MilestoneProjectClippedConfigurationPageModel : AbstractConfigurationPageModel<IndicatorMilestoneDetailDtoModel, IndicatorMilestoneDetailDtoModel>
    {
        public static string AmountValidableProperty => nameof(Amount);
        public static string DescriptionValidableProperty => nameof(Description);

        private DateTime at;
        private float amount;
        private string? description;

        public MilestoneProjectClippedConfigurationPageModel(IndicatorMilestoneDetailDtoModel? model, UnitMeasurementBasicDtoModel unitMeasurement, Action<IndicatorMilestoneDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
        {
            UnitMeasurement = unitMeasurement;

            Id = model?.Id;
            at = model?.At.ToDateTime(default) ?? DateTime.Now;
            amount = model?.Amount ?? 0f;
            description = model?.Description;
        }

        protected override bool PresentChangeNotification => false;

        public override IValidationContext? ValidationContext => new ValidationContext<MilestoneProjectClippedConfigurationPageModel>(this);

        protected override Task<IndicatorMilestoneDetailDtoModel> PerformCreationAsync()
        {
            return Task.FromResult(new IndicatorMilestoneDetailDtoModel(Guid.NewGuid(), DateOnly.FromDateTime(at), amount, description));
        }

        protected override Task<IndicatorMilestoneDetailDtoModel> PerformEditionAsync()
        {
            return Task.FromResult(new IndicatorMilestoneDetailDtoModel(Id!.Value, DateOnly.FromDateTime(at), amount, description));
        }

        public Guid? Id { get; set; }

        public UnitMeasurementBasicDtoModel UnitMeasurement { get; init; }

        public DateTime At { get => at; set => SetProperty(ref at, value); }

        public float Amount { get => amount; set => SetProperty(ref amount, value); }

        public string? Description { get => description; set => SetProperty(ref description, value); }
    }
}
