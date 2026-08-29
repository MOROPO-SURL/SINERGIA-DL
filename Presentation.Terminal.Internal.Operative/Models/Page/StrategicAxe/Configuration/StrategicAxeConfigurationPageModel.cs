using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Configuration;

public sealed class StrategicAxeConfigurationPageModel : AbstractConfigurationPageModel<StrategicAxeDetailDtoModel, StrategicAxeDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string DescriptionValidableProperty => nameof(Description);

    private int id = 1;
    private string? name;
    private PersonBasicDtoModel? coordinator;
    private string? description;

    private readonly List<MacroprogramBasicDtoModel> inMacroprograms = [];
    private readonly List<MacroprogramBasicDtoModel> outMacroprograms = [];

    public StrategicAxeConfigurationPageModel(StrategicAxeDetailDtoModel? model, Action<StrategicAxeDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicAxeConfigurationValidator())
    {
        #region Commands

        #region Macroprograms

        AddMacroprogramCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new MacroprogramPickPage(MacroprogramPicked_Callback)));
        });

        RemoveMacroprogramCommand = new Command<MacroprogramBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inMacroprograms)
                {
                    if (item.Id != model.Id) continue;

                    inMacroprograms.Remove(inMacroprograms.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outMacroprograms.Add(model);
                }

                Dispatcher.Dispatch(() => Macroprograms.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #endregion

        if (model is null) return;

        Id = model.Id;
        name = model.Name;
        coordinator = model.Coordinator;
        description = model.Description;

        Macroprograms = [.. model.Macroprograms];
    }

    public int Id { get => id; set => SetProperty(ref id, value); }

    public string? Name { get => name; set => SetProperty(ref name, value); }

    public PersonBasicDtoModel? Coordinator { get => coordinator; set => SetProperty(ref coordinator, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<MacroprogramBasicDtoModel> Macroprograms { get; private set; } = [];

    public ICommand AddMacroprogramCommand { get; private set; }

    public ICommand RemoveMacroprogramCommand { get; private set; }

    protected override Task<StrategicAxeDetailDtoModel> PerformCreationAsync()
    {
        StrategicAxeCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicAxeCreateRequestModel
            (
                Id,
                true,
                Name!,
                [.. inMacroprograms],
                Coordinator?.Id,
                Description
            ));
    }

    protected override Task<StrategicAxeDetailDtoModel> PerformEditionAsync()
    {
        StrategicAxeCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicAxeUpdateRequestModel
            (
                Id!,
                true,
                Name!,
                [.. inMacroprograms],
                [.. outMacroprograms],
                Coordinator?.Id,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicAxeConfigurationPageModel>(this);

    private void MacroprogramPicked_Callback(MacroprogramBasicDtoModel model)
    {
        inMacroprograms.Add(model);

        Macroprograms.Add(model);

        hasChangesFlag = true;
    }
}