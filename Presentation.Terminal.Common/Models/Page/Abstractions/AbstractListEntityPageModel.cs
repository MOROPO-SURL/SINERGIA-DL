using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

public abstract class AbstractListEntityPageModel<TBasicModel, TDetailModel> : BasePageModel, ICollectionViewSizeChangeReloadItemsPageModel
{
    private int currentItemsPageNumber;
    private int currentItemsPageLimit;

    private bool isEnabled;
    private bool hasMoreItems;
    private string? searchParameter;

    private IListItemsPageModelPresenter<TBasicModel> presenter = null!;

    protected AbstractListEntityPageModel()
    {
        ReloadCommand = new Command(() =>
        {
            if (IsBusy) return;

            SearchParameter = null;

            IsEnabled = true;

            LoadItems(true);
        });

        SearchCommand = new Command(() => 
        {
            if (IsBusy) return;

            IsEnabled = true;

            LoadItems(true);
        });

        LoadMoreCommand = new Command(() => LoadItems());

        DetailItemCommand = new Command<TBasicModel>(model =>
        {
            if (IsBusy) return;

            presenter.PresentItemDetailUserInterfaceAsync(model).ContinueWith(task =>
            {
                if (!task.IsFaulted && !task.IsCanceled) return;

                Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;

                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                });
            });
        });
    }

    protected virtual string? ViewerPermissionCode => null;

    protected virtual string? DetailPermissionCode => null;

    public System.Collections.ObjectModel.ObservableCollection<TBasicModel> Items { get; private set; } = [];

    public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }

    public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }

    public string? SearchParameter { get => searchParameter; set => SetProperty(ref searchParameter, value); }

    public ICommand ReloadCommand { get; set; }

    public ICommand SearchCommand { get; set; }

    public ICommand LoadMoreCommand { get; set; }

    public ICommand DetailItemCommand { get; set; }

    public void BindPresenter(IListItemsPageModelPresenter<TBasicModel> presenter)
    {
        this.presenter = presenter;
    }

    protected abstract Task<PaginateResultModel<TBasicModel>> FetchItemsAsync(int currentItemsPageNumber, int currentItemsPageLimit);

    public void LoadItems(bool reset = false)
    {
        if (ViewerPermissionCode != null)
        {
            var session = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>()!.CurrentSession!;

            if (!session.HasFullAccess && !session.Permissions.Any(item => item == ViewerPermissionCode))
            {
                Application.Current!.MainPage!.DisplayAlert("Aviso", "Su usuario no cuenta con permisos para visualizar esta información. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                IsEnabled = false;

                return;
            }
        }

        IsBusy = true;

        if (reset)
        {
            currentItemsPageLimit = presenter.CalculatecurrentItemsPageLimit();

            currentItemsPageNumber = 0;

            foreach (var item in Items)
            {
                if (item == null || item is not IDisposable disposable) continue;

                disposable.Dispose();
            }

            Items.Clear();
        }

        currentItemsPageNumber++;

        FetchItemsAsync(currentItemsPageNumber, currentItemsPageLimit).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    currentItemsPageNumber--;

                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }
                else
                {
                    foreach (TBasicModel model in task.Result.Items)
                    {
                        Items.Add(model);
                    }

                    HasMoreItems = task.Result.HasNext && task.Result.Items.Length > 0;
                }

                IsEnabled = true;
                IsBusy = false;
            });
        });
    }
}