using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.User.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Common.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Common.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Validators;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.User;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Person;

public sealed class PersonConfigurationPageModel : AbstractConfigurationPageModel<PersonDetailDtoModel, PersonDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string LastNameValidableProperty => nameof(LastName);
    public static string AliasValidableProperty => nameof(Alias);
    public static string AboutValidableProperty => nameof(About);

    private ImageCreateRequestModel? imagePickedModel;

    private readonly List<PhoneNumberDetailDtoModel> inPhoneNumbers = [];
    private readonly List<PhoneNumberDetailDtoModel> outPhoneNumbers = [];
    private readonly List<EmailAddressDetailDtoModel> inEmailAddresses = [];
    private readonly List<EmailAddressDetailDtoModel> outEmailAddresses = [];
    private readonly List<PostalAddressDetailDtoModel> inPostalAddresses = [];
    private readonly List<PostalAddressDetailDtoModel> outPostalAddresses = [];
    private readonly List<WebSiteAddressDetailDtoModel> inWebSiteAddresses = [];
    private readonly List<WebSiteAddressDetailDtoModel> outWebSiteAddresses = [];

    private int priority = 1;
    private string name = null!;
    private string? lastName;
    private string? alias;
    private string? about;
    private ImageSource? imageSource;
    private UserBasicDtoModel? user;

    public PersonConfigurationPageModel(PersonDetailDtoModel? model, Action<PersonDetailDtoModel> successCallbackAction) : base(model, successCallbackAction, new PersonConfigurationValidator())
    {
        PickUserCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new UserPickPage(UserPicked_Callback)));
        });

        #region PhoneNumber

        CreatePhoneNumberCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new PhoneNumberConfigurationPage(new PhoneNumberConfigurationPageModel(null, PhoneNumberCreateSuccess_Callback, new PhoneNumberConfigurationValidator())));
        });

        //UpdatePhoneNumberCommand = new Command<PhoneNumberDetailDtoModel>(async model =>
        //{
        //    await Application.Current!.MainPage!.NavigationPushPageAsync(new PhoneNumberConfigurationPage(new PhoneNumberConfigurationPageModel(model, PhoneNumberModifySuccess_Callback, new PhoneNumberConfigurationValidator())));
        //});

        DetailPhoneNumberCommand = new Command<PhoneNumberDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new PhoneNumberDetailPage(model));
        });

        RemovePhoneNumberCommand = new Command<PhoneNumberDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inPhoneNumbers)
                {
                    if (item != model) continue;

                    inPhoneNumbers.Remove(item);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outPhoneNumbers.Add(model);
                }

                Dispatcher.Dispatch(() => PhoneNumbers.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region EmailAddress

        CreateEmailAddressCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new EmailAddressConfigurationPage(new EmailAddressConfigurationPageModel(null, EmailAddressCreateSuccess_Callback, new EmailAddressConfigurationValidator())));
        });

        //UpdateEmailAddressCommand = new Command<EmailAddressDetailDtoModel>(async model =>
        //{
        //    await Application.Current!.MainPage!.NavigationPushPageAsync(new EmailAddressConfigurationPage(new EmailAddressConfigurationPageModel(model, EmailAddressModifySuccess_Callback, new EmailAddressConfigurationValidator())));
        //});

        DetailEmailAddressCommand = new Command<EmailAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new EmailAddressDetailPage(model));
        });

        RemoveEmailAddressCommand = new Command<EmailAddressDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inEmailAddresses)
                {
                    if (item != model) continue;

                    inEmailAddresses.Remove(item);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outEmailAddresses.Add(model);
                }

                Dispatcher.Dispatch(() => EmailAddresses.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region PostalAddress

        CreatePostalAddressCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new PostalAddressConfigurationPage(new PostalAddressConfigurationPageModel(null, PostalAddressCreateSuccess_Callback, new PostalAddressConfigurationValidator())));
        });

        //UpdatePostalAddressCommand = new Command<PostalAddressDetailDtoModel>(async model =>
        //{
        //    await Application.Current!.MainPage!.NavigationPushPageAsync(new PostalAddressConfigurationPage(new PostalAddressConfigurationPageModel(model, PostalAddressModifySuccess_Callback, new PostalAddressConfigurationValidator())));
        //});

        DetailPostalAddressCommand = new Command<PostalAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new PostalAddressDetailPage(model));
        });

        RemovePostalAddressCommand = new Command<PostalAddressDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inPostalAddresses)
                {
                    if (item != model) continue;

                    inPostalAddresses.Remove(item);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outPostalAddresses.Add(model);
                }

                Dispatcher.Dispatch(() => PostalAddresses.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region WebSiteAddress

        CreateWebSiteAddressCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new WebSiteAddressConfigurationPage(new WebSiteAddressConfigurationPageModel(null, WebSiteAddressCreateSuccess_Callback, new WebSiteAddressConfigurationValidator())));
        });

        //UpdateWebSiteAddressCommand = new Command<WebSiteAddressDetailDtoModel>(async model =>
        //{
        //    await Application.Current!.MainPage!.NavigationPushPageAsync(new WebSiteAddressConfigurationPage(new WebSiteAddressConfigurationPageModel(model, WebSiteAddressModifySuccess_Callback, new WebSiteAddressConfigurationValidator())));
        //});

        DetailWebSiteAddressCommand = new Command<WebSiteAddressDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new WebSiteAddressDetailPage(model));
        });

        RemoveWebSiteAddressCommand = new Command<WebSiteAddressDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inWebSiteAddresses)
                {
                    if (item != model) continue;

                    inWebSiteAddresses.Remove(item);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outWebSiteAddresses.Add(model);
                }

                Dispatcher.Dispatch(() => WebSiteAddresses.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        if (model is null) return;

        Id = model.Id;
        priority = model.Priority;
        name = model.Name;
        lastName = model.LastName;
        alias = model.Alias;
        imageSource = model.Image?.ToImageSource();
        about = model.About;
        user = model.User;

        PhoneNumbers = [.. model.PhoneNumbers];
        EmailAddresses = [.. model.EmailAddresses];
        PostalAddresses = [.. model.PostalAddresses];
        WebSiteAddresses = [.. model.WebSiteAddresses];
    }

    public Guid? Id { get; set; }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string? LastName { get => lastName; set => SetProperty(ref lastName, value); }

    public string? Alias { get => alias; set => SetProperty(ref alias, value); }

    public string? About { get => about; set => SetProperty(ref about, value); }

    public UserBasicDtoModel? User { get => user; set => SetProperty(ref user, value); }

    public ObservableCollection<PhoneNumberDetailDtoModel> PhoneNumbers { get; set; } = [];

    public ObservableCollection<EmailAddressDetailDtoModel> EmailAddresses { get; set; } = [];

    public ObservableCollection<PostalAddressDetailDtoModel> PostalAddresses { get; set; } = [];

    public ObservableCollection<WebSiteAddressDetailDtoModel> WebSiteAddresses { get; set; } = [];

    public ImageSource? ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

    public ICommand PickUserCommand { get; private set; }

    public ICommand CreatePhoneNumberCommand { get; private set; }

    public ICommand DetailPhoneNumberCommand { get; private set; }

    public ICommand RemovePhoneNumberCommand { get; private set; }

    public ICommand CreateEmailAddressCommand { get; private set; }

    public ICommand DetailEmailAddressCommand { get; private set; }

    public ICommand RemoveEmailAddressCommand { get; private set; }

    public ICommand CreatePostalAddressCommand { get; private set; }

    public ICommand DetailPostalAddressCommand { get; private set; }

    public ICommand RemovePostalAddressCommand { get; private set; }

    public ICommand CreateWebSiteAddressCommand { get; private set; }

    public ICommand DetailWebSiteAddressCommand { get; private set; }

    public ICommand RemoveWebSiteAddressCommand { get; private set; }

    protected override void DisposeUnmanagedResources()
    {
        base.DisposeUnmanagedResources();

        imagePickedModel = null;
    }

    protected override Task<PersonDetailDtoModel> PerformCreationAsync()
    {
        PersonCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new PersonCreateRequestModel
            (
                name!,
                priority,
                [.. EmailAddresses],
                [.. PhoneNumbers],
                [.. PostalAddresses],
                [.. WebSiteAddresses],
                lastName,
                alias,
                about,
                imagePickedModel,
                user
            ));
    }

    protected override Task<PersonDetailDtoModel> PerformEditionAsync()
    {
        PersonCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new PersonUpdateRequestModel
            (
                Id!.Value,
                name!,
                priority,
                [.. inEmailAddresses],
                [.. outEmailAddresses],
                [.. inPhoneNumbers],
                [.. outPhoneNumbers],
                [.. inPostalAddresses],
                [.. outPostalAddresses],
                [.. inWebSiteAddresses],
                [.. outWebSiteAddresses],
                lastName,
                alias,
                about,
                imagePickedModel,
                user
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<PersonConfigurationPageModel>(this);

    private void UserPicked_Callback(UserBasicDtoModel model)
    {
        User = model;

        hasChangesFlag = true;
    }

    private void PhoneNumberCreateSuccess_Callback(PhoneNumberDetailDtoModel model)
    {
        inPhoneNumbers.Add(model);

        PhoneNumbers.Add(model);

        hasChangesFlag = true;
    }

    private void EmailAddressCreateSuccess_Callback(EmailAddressDetailDtoModel model)
    {
        inEmailAddresses.Add(model);

        EmailAddresses.Add(model);

        hasChangesFlag = true;
    }

    private void PostalAddressCreateSuccess_Callback(PostalAddressDetailDtoModel model)
    {
        inPostalAddresses.Add(model);

        PostalAddresses.Add(model);

        hasChangesFlag = true;
    }

    private void WebSiteAddressCreateSuccess_Callback(WebSiteAddressDetailDtoModel model)
    {
        inWebSiteAddresses.Add(model);

        WebSiteAddresses.Add(model);

        hasChangesFlag = true;
    }

    internal void SetImagePickedModel(ImageCreateRequestModel model)
    {
        imagePickedModel = model;

        hasChangesFlag = true;
    }
}