using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Manager;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages;

public class BaseListBaseContentPage<TBasicModel, TDetailModel, TListPageModel> : BaseContentPage
    where TListPageModel : AbstractListEntityPageModel<TBasicModel>, new()
{
    public BaseListBaseContentPage()
    {
        BindingContext = new TListPageModel();
    }

    protected TListPageModel ConcreteBindingContext => (TListPageModel)BindingContext;

    protected virtual bool DetailRequiredAsyncWorkPresentation => false;

    protected virtual string? ViewerPermissionCode => null;

    protected int CurrentItemsPageNumber { get; private set; }

    protected int CurrentItemsPageLimit { get; private set; }

    protected virtual CollectionView GetItemsCollectionView() => throw new NotImplementedException();

    protected virtual double ItemViewRequestWidth => 320;

    protected virtual double MeasureCollectionViewCellHeight(double width) { return width; }

    protected void ItemDetailRequestControl_Invoked(object sender, EventArgs eventArgs)
    {
        if (ConcreteBindingContext.IsBusy) return;

        ConcreteBindingContext.IsBusy = DetailRequiredAsyncWorkPresentation;

        BuildDetailPageAysnc((TBasicModel)((BindableObject)sender).BindingContext).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                this.NavigationPushModalPageAsync(task.Result);

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    protected virtual Task<BaseDetailBaseContentPage<TDetailModel>> BuildDetailPageAysnc(TBasicModel model) => throw new NotImplementedException();

    protected void OnReload(object sender, EventArgs eventArgs)
    {
        if (((TListPageModel)BindingContext).IsBusy) return;

        IsEnabled = true;

        LoadItems(true);
    }

    protected void OnLoadMore(object sender, EventArgs eventArgs)
    {
        LoadItems();
    }

    protected void OnItemsCollectionViewLayoutResize(object sender, EventArgs eventArgs)
    {
        if (!IsEnabled) return;

        if (GetItemsCollectionView().ItemsLayout is GridItemsLayout)
        {
            var itemsCollectionViewItemsLayout = GetItemsCollectionView().ItemsLayout as GridItemsLayout;

            var itemsCollectionViewLayout = (Layout)sender;

            if (itemsCollectionViewLayout.Width < 0 || itemsCollectionViewLayout.Height < 0) return;

            if (((TListPageModel)BindingContext).IsBusy) return;

            var reazon = itemsCollectionViewLayout.Width / (ItemViewRequestWidth + itemsCollectionViewItemsLayout!.HorizontalItemSpacing);

            int columnCount = Convert.ToInt32(Math.Round(reazon, MidpointRounding.ToEven));

            if (columnCount > reazon)
            {
                columnCount--;
            }

            if (columnCount <= 0)
            {
                columnCount = 1;
            }

            itemsCollectionViewItemsLayout.Span = columnCount;
        }

        LoadItems(true);
    }

    protected void LoadItems(bool restart = false)
    {
        if (BindingContext == null) return;

        if (ViewerPermissionCode != null)
        {
            var session = IPlatformApplication.Current!.Services.GetRequiredService<ISessionManagerPort>()!.CurrentSession!;

            if (!session.HasFullAccess && !session.Permissions.Any(item => item == ViewerPermissionCode))
            {
                DisplayAlert("Aviso", "Su usuario no cuenta con permisos para visualizar esta información. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                IsEnabled = false;

                return;
            }
        }

        ConcreteBindingContext.IsBusy = true;

        if (restart)
        {
            CalculateCollectionViewPagingMetrics();

            CurrentItemsPageNumber = 0;

            foreach (var item in ConcreteBindingContext.Items)
            {
                if (item == null || item is not IDisposable disposable) continue;

                disposable.Dispose();
            }

            ConcreteBindingContext.Items.Clear();
        }

        CurrentItemsPageNumber++;

        FetchItemsAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (ConcreteBindingContext == null) return;

                if (task.Exception != null || task.IsCanceled)
                {
                    CurrentItemsPageNumber--;

                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception, this);
                }
                else
                {
                    foreach (TBasicModel model in task.Result.Items)
                    {
                        ConcreteBindingContext.Items.Add(model);
                    }

                    ConcreteBindingContext.HasMoreItems = task.Result.HasNext && task.Result.Items.Length > 0;
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    protected virtual Task<PaginateResultModel<TBasicModel>> FetchItemsAsync() { throw new NotImplementedException(); }

    private void CalculateCollectionViewPagingMetrics()
    {
        Layout itemsCollectionViewLayout = (Layout)GetItemsCollectionView().Parent;

        double itemsCollectionViewItemsLayoutHorizontalItemSpacing;

        if (GetItemsCollectionView().ItemsLayout is GridItemsLayout itemsCollectionViewItemsLayout)
        {
            int columnCount = itemsCollectionViewItemsLayout!.Span;

            itemsCollectionViewItemsLayoutHorizontalItemSpacing = itemsCollectionViewItemsLayout.HorizontalItemSpacing;

            double collectionViewCellWidth = (itemsCollectionViewLayout!.Width - (columnCount - 1) * itemsCollectionViewItemsLayoutHorizontalItemSpacing) / columnCount;

            double collectionViewCellHeight = MeasureCollectionViewCellHeight(collectionViewCellWidth);

            double availableVerticalHeight = itemsCollectionViewLayout.Height;

            int rowCount = 0;

            while (availableVerticalHeight > 0)
            {
                rowCount++;

                availableVerticalHeight -= collectionViewCellHeight + itemsCollectionViewItemsLayoutHorizontalItemSpacing;
            }

            CurrentItemsPageLimit = columnCount * rowCount;
        }
        else
        {
            CurrentItemsPageLimit = 10;
        }
    }
}
