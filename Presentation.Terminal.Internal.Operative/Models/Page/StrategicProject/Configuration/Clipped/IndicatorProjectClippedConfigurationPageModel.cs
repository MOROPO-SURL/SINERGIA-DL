using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.StrategicProject;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Configuration.Clipped;
//using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration.Clipped
{
    public sealed class IndicatorProjectClippedConfigurationPageModel : AbstractConfigurationPageModel<IndicatorDetailDtoModel, IndicatorProjectConfigurationResultCompousedModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string AliasValidableProperty => nameof(Alias);
        public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);

        private string name = null!;
        private int priority = 1;
        private string? alias;
        private UnitMeasurementBasicDtoModel unitMeasurement = null!;

        private readonly List<IndicatorMilestoneCreateClippedRequestModel> inMilestones = [];
        private readonly List<IndicatorMilestoneUpdateClippedRequestModel> patchMilestones = [];
        private readonly List<IndicatorMilestoneDetailDtoModel> outMilestones = [];

        protected override bool PresentChangeNotification => false;

        public override IValidationContext? ValidationContext => new ValidationContext<IndicatorProjectClippedConfigurationPageModel>(this);

        public IndicatorProjectClippedConfigurationPageModel(
           IndicatorDetailDtoModel? model,
           IEnumerable<UnitMeasurementBasicDtoModel> availableUnitmMeasurements,
           Action<IndicatorProjectConfigurationResultCompousedModel> successCallbackAction,
           IValidator validator,
           IEnumerable<IndicatorMilestoneCreateClippedRequestModel>? inMilestones = null,
           IEnumerable<IndicatorMilestoneUpdateClippedRequestModel>? patchMilestones = null,
           IEnumerable<IndicatorMilestoneDetailDtoModel>? outMilestones = null) : base(model, successCallbackAction, validator)
        {
                #region Milestones

                CreateMilestoneCommand = new Command(async () =>
                {
                    await Application.Current!.MainPage!.NavigationPushPageAsync(new MilestoneProjectClippedConfigurationPage(new MilestoneProjectClippedConfigurationPageModel(null, unitMeasurement, MilestoneCreateSuccess_Callback, new StrategicProjectIndicatorMilestoneConfigurationValidator())));
                });

                UpdateMilestoneCommand = new Command<IndicatorMilestoneDetailDtoModel>(async model =>
                {
                    await Application.Current!.MainPage!.NavigationPushPageAsync(new MilestoneProjectClippedConfigurationPage(new MilestoneProjectClippedConfigurationPageModel(model, unitMeasurement, MilestoneModifySuccess_Callback, new StrategicProjectIndicatorMilestoneConfigurationValidator())));
                });

                DeleteMilestoneCommand = new Command<IndicatorMilestoneDetailDtoModel>(model =>
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

                DetailMilestoneCommand = new Command<IndicatorMilestoneDetailDtoModel>(async model =>
                {
                    await Application.Current!.MainPage!.NavigationPushModalPageAsync(new MilestoneProjectClippedDetailPage(model));
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

        protected override Task<IndicatorProjectConfigurationResultCompousedModel> PerformCreationAsync()
        {
            Guid id = Guid.NewGuid();

            return Task.FromResult(new IndicatorProjectConfigurationResultCompousedModel(
                new IndicatorDetailDtoModel(id, name, unitMeasurement, priority, [.. Milestones], alias),
                new IndicatorUpdateClippedRequestModel(id, name, unitMeasurement, priority, inMilestones, [], [])));
        }

        protected override Task<IndicatorProjectConfigurationResultCompousedModel> PerformEditionAsync()
        {
            return Task.FromResult(new IndicatorProjectConfigurationResultCompousedModel(
                new IndicatorDetailDtoModel(Id!.Value, name, unitMeasurement, priority, [.. Milestones], alias),
                new IndicatorUpdateClippedRequestModel(Id!.Value, name, unitMeasurement, priority, inMilestones, patchMilestones, outMilestones, alias)));
        }

        public Guid? Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string? Alias { get => alias; set => SetProperty(ref alias, value); }

        public UnitMeasurementBasicDtoModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public ObservableCollection<UnitMeasurementBasicDtoModel> AvailableUnitmMeasurements { get; private set; }

        public ObservableCollection<IndicatorMilestoneDetailDtoModel> Milestones { get; init; } = [];

        public ICommand CreateMilestoneCommand { get; init; }

        public ICommand UpdateMilestoneCommand { get; init; }

        public ICommand DeleteMilestoneCommand { get; init; }

        public ICommand DetailMilestoneCommand { get; init; }

        private void MilestoneCreateSuccess_Callback(IndicatorMilestoneDetailDtoModel model)
        {
            inMilestones.Add(new IndicatorMilestoneCreateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));

            // TODO Order list !!!
            Milestones.Add(model);

            hasChangesFlag = true;
        }

        private void MilestoneModifySuccess_Callback(IndicatorMilestoneDetailDtoModel model)
        {
            bool handled = false;

            foreach (var item in inMilestones)
            {
                if (item.Id != model.Id) continue;

                inMilestones.Remove(item);

                inMilestones.Add(new IndicatorMilestoneCreateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));

                handled = true;

                break;
            }

            if (!handled)
            {
                foreach (var item in patchMilestones)
                {
                    if (item.Id != model.Id) continue;

                    patchMilestones.Remove(item);

                    patchMilestones.Add(new IndicatorMilestoneUpdateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));

                    handled = true;

                    break;
                }
            }

            if (!handled)
            {
                patchMilestones.Add(new IndicatorMilestoneUpdateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));
            }

            var index = -1;

            // TODO Order list !!!
            foreach (var item in Milestones)
            {
                index++;

                if (item.Id != model.Id) continue;

                Milestones[index] = new IndicatorMilestoneDetailDtoModel(model.Id, model.At, model.Amount, model.Description);

                break;
            }

            hasChangesFlag = true;
        }
    }
}
