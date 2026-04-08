namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Behaviors;

public sealed class AdaptableGridItemLayoutCollectionViewBehavior : Behavior
{
    public double ItemWidth { get; set; }

    public double ItemSpacing { get; set; }

    protected override void OnAttachedTo(BindableObject bindable)
    {
        base.OnAttachedTo(bindable);

        if (bindable is not CollectionView) return;

        var collectionView = bindable as CollectionView;

        if (collectionView!.ItemsLayout is not GridItemsLayout) return;

        collectionView.SizeChanged += CollectionView_SizeChanged!;
    }

    protected override void OnDetachingFrom(BindableObject bindable)
    {
        base.OnDetachingFrom(bindable);

        var collectionView = bindable as CollectionView;

        if (collectionView!.ItemsLayout is not GridItemsLayout) return;

        collectionView.SizeChanged -= CollectionView_SizeChanged!;
    }

    private void CollectionView_SizeChanged(object sender, EventArgs e)
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
    }
}
