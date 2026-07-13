using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Interfaces;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Behaviors;

public sealed class AdaptableGridItemLayoutCollectionViewBehavior : Behavior
{
    private ICommand? itemsLayoutConfiguredCommand;

    public double ItemWidth { get; set; }

    public double ItemSpacing { get; set; }

    protected override void OnAttachedTo(BindableObject bindable)
    {
        base.OnAttachedTo(bindable);

        if (bindable is not CollectionView collectionView) return;

        if (collectionView!.ItemsLayout is not GridItemsLayout) return;

        collectionView.SizeChanged += CollectionView_SizeChanged!;
        collectionView.BindingContextChanged += CollectionView_BindingContextChanged;
    }

    private void CollectionView_BindingContextChanged(object? sender, EventArgs eventArgs)
    {
        if (((BindableObject)sender!).BindingContext is ICollectionViewSizeChangeReloadItemsPageModel sizeChangeItemsReloadPageModel)
        {
            itemsLayoutConfiguredCommand = sizeChangeItemsReloadPageModel.ReloadCommand;
        }
    }

    protected override void OnDetachingFrom(BindableObject bindable)
    {
        base.OnDetachingFrom(bindable);

        itemsLayoutConfiguredCommand = null;

        var collectionView = bindable as CollectionView;

        if (collectionView!.ItemsLayout is not GridItemsLayout) return;

        collectionView.SizeChanged -= CollectionView_SizeChanged!;
        collectionView.BindingContextChanged -= CollectionView_BindingContextChanged;
    }

    private void CollectionView_SizeChanged(object sender, EventArgs eventArgs)
    {
        var collectionView = sender as CollectionView;

        var reazon = collectionView!.Width / (ItemWidth + ItemSpacing);

        int columnCount = Convert.ToInt32(Math.Round(reazon, MidpointRounding.ToEven));

        if (columnCount > reazon)
        {
            columnCount--;
        }

        if (columnCount <= 0)
        {
            columnCount = 1;
        }

        (collectionView.ItemsLayout as GridItemsLayout)!.Span = columnCount;

        itemsLayoutConfiguredCommand?.Execute(null);
    }
}
