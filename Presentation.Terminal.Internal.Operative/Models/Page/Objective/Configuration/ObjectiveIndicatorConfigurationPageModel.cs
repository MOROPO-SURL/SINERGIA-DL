using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.Objective;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration
{
    public sealed class ObjectiveIndicatorConfigurationPageModel : AbstractConfigurationPageModel<ObjectiveActionIndicatorDetailDtoModel, ObjectiveIndicatorConfigurationResultCompousedModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string AliasValidableProperty => nameof(Alias);
        public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);

        private string name = null!;
        private int priority = 1;
        private string? alias;
        private UnitMeasurementBasicDtoModel unitMeasurement = null!;

        private readonly List<ObjectiveActionIndicatorMilestoneCreateRequestModel> inMilestones = [];
        private readonly List<ObjectiveActionIndicatorMilestoneUpdateRequestModel> patchMilestones = [];
        private readonly List<ObjectiveActionIndicatorMilestoneDetailDtoModel> outMilestones = [];

        protected override bool PresentChangeNotification => false;

        public override IValidationContext? ValidationContext => new ValidationContext<ObjectiveIndicatorConfigurationPageModel>(this);

        public ObjectiveIndicatorConfigurationPageModel(
            ObjectiveActionIndicatorDetailDtoModel? model,
            IEnumerable<UnitMeasurementBasicDtoModel> availableUnitmMeasurements,
            Action<ObjectiveIndicatorConfigurationResultCompousedModel> successCallbackAction,
            IValidator validator,
            IEnumerable<ObjectiveActionIndicatorMilestoneCreateRequestModel>? inMilestones = null,
            IEnumerable<ObjectiveActionIndicatorMilestoneUpdateRequestModel>? patchMilestones = null,
            IEnumerable<ObjectiveActionIndicatorMilestoneDetailDtoModel>? outMilestones = null) : base(model, successCallbackAction, validator)
        {
            #region Milestones

            CreateMilestoneCommand = new Command(async () =>
            {
                await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveMilestoneConfigurationPage(new ObjectiveMilestoneConfigurationPageModel(null, unitMeasurement, MilestoneCreateSuccess_Callback, new ObjectiveActionIndicatorMilestoneConfigurationValidator())));
            });

            UpdateMilestoneCommand = new Command<ObjectiveActionIndicatorMilestoneDetailDtoModel>(async model =>
            {
                await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveMilestoneConfigurationPage(new ObjectiveMilestoneConfigurationPageModel(model, unitMeasurement, MilestoneModifySuccess_Callback, new ObjectiveActionIndicatorMilestoneConfigurationValidator())));
            });

            DeleteMilestoneCommand = new Command<ObjectiveActionIndicatorMilestoneDetailDtoModel>(model =>
            {
                Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
                {
                    if (!task.Result) return;

                    bool handled = false;

                    foreach (var item in this.inMilestones)
                    {
                        if (item.Id != model.Id) continue;

                        this.inMilestones.Remove(this.inMilestones.First(item => item.Id == model.Id));

                        handled = true;

                        break;
                    }

                    if (!handled)
                    {
                        foreach (var item in this.patchMilestones)
                        {
                            if (item.Id != model.Id) continue;

                            this.patchMilestones.Remove(this.patchMilestones.First(item => item.Id == model.Id));

                            break;
                        }
                    }

                    if (!handled)
                    {
                        this.outMilestones.Add(model);
                    }

                    Dispatcher.Dispatch(() => Milestones.Remove(model));

                    hasChangesFlag = true;
                });
            });

            DetailMilestoneCommand = new Command<ObjectiveActionIndicatorMilestoneDetailDtoModel>(async model =>
            {
                await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveMilestoneDetailPage(model));
            });

            #endregion

            AvailableUnitmMeasurements = [.. availableUnitmMeasurements];

            if (inMilestones != null) this.inMilestones = [.. inMilestones];
            if (patchMilestones != null) this.patchMilestones = [.. patchMilestones];
            if (outMilestones != null) this.outMilestones = [.. outMilestones];

            if (model == null) return;

            Id = model.Id;
            name = model.Name;
            alias = model.Alias;
            unitMeasurement = AvailableUnitmMeasurements.First(item => item.Id == model.UnitMeasurement.Id);

            Milestones = [.. model.Milestones];
        }

        protected override Task<ObjectiveIndicatorConfigurationResultCompousedModel> PerformCreationAsync()
        {
            Guid id = Guid.NewGuid();

            return Task.FromResult(new ObjectiveIndicatorConfigurationResultCompousedModel(
                new ObjectiveActionIndicatorDetailDtoModel(id, name, unitMeasurement, priority, [.. Milestones], alias),
                new ObjectiveActionIndicatorUpdateRequestModel(id, name, unitMeasurement, priority, inMilestones, [], [])));
        }

        protected override Task<ObjectiveIndicatorConfigurationResultCompousedModel> PerformEditionAsync()
        {
            return Task.FromResult(new ObjectiveIndicatorConfigurationResultCompousedModel(
                new ObjectiveActionIndicatorDetailDtoModel(Id!.Value, name, unitMeasurement, priority, [.. Milestones], alias),
                new ObjectiveActionIndicatorUpdateRequestModel(Id!.Value, name, unitMeasurement, priority, inMilestones, patchMilestones, outMilestones, alias)));
        }

        public Guid? Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string? Alias { get => alias; set => SetProperty(ref alias, value); }

        public UnitMeasurementBasicDtoModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public ObservableCollection<UnitMeasurementBasicDtoModel> AvailableUnitmMeasurements { get; private set; }

        public ObservableCollection<ObjectiveActionIndicatorMilestoneDetailDtoModel> Milestones { get; init; } = [];

        public ICommand CreateMilestoneCommand { get; init; }

        public ICommand UpdateMilestoneCommand { get; init; }

        public ICommand DeleteMilestoneCommand { get; init; }

        public ICommand DetailMilestoneCommand { get; init; }

        private void MilestoneCreateSuccess_Callback(ObjectiveActionIndicatorMilestoneDetailDtoModel model)
        {
            inMilestones.Add(new ObjectiveActionIndicatorMilestoneCreateRequestModel(model.Id, model.At, model.Amount, model.Description));

            // TODO Order list !!!
            Milestones.Add(model);

            hasChangesFlag = true;
        }

        private void MilestoneModifySuccess_Callback(ObjectiveActionIndicatorMilestoneDetailDtoModel model)
        {
            bool handled = false;

            foreach (var item in inMilestones)
            {
                if (item.Id != model.Id) continue;

                inMilestones.Remove(item);

                inMilestones.Add(new ObjectiveActionIndicatorMilestoneCreateRequestModel(model.Id, model.At, model.Amount, model.Description));

                handled = true;

                break;
            }

            if (!handled)
            {
                foreach (var item in patchMilestones)
                {
                    if (item.Id != model.Id) continue;

                    patchMilestones.Remove(item);

                    patchMilestones.Add(new ObjectiveActionIndicatorMilestoneUpdateRequestModel(model.Id, model.At, model.Amount, model.Description));

                    handled = true;

                    break;
                }
            }

            if (!handled)
            {
                patchMilestones.Add(new ObjectiveActionIndicatorMilestoneUpdateRequestModel(model.Id, model.At, model.Amount, model.Description));
            }

            var index = -1;

            // TODO Order list !!!
            foreach (var item in Milestones)
            {
                index++;

                if (item.Id != model.Id) continue;

                Milestones[index] = new ObjectiveActionIndicatorMilestoneDetailDtoModel(model.Id, model.At, model.Amount, model.Description);

                break;
            }

            hasChangesFlag = true;
        }
    }
}
