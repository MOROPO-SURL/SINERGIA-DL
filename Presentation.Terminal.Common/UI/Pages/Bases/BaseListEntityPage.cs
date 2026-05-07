using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;

public class BaseListEntityPage<TBasicModel, TListPageModel> : BaseContentPage
    where TListPageModel : AbstractListEntityPageModel<TBasicModel>
{
    public BaseListEntityPage(TListPageModel model)
    {
        BindingContext = model;
    }

    protected TListPageModel ConcreteBindingContext => (TListPageModel)BindingContext;

    protected virtual string? ViewerPermissionCode => null;

    protected virtual CollectionView GetItemsCollectionView() => throw new NotImplementedException();

    protected virtual double MeasureCollectionViewCellHeight(double width) { return width; }

    public int CalculatecurrentItemsPageLimit()
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

            return columnCount * rowCount;
        }
        
        return 10;
    }
}
