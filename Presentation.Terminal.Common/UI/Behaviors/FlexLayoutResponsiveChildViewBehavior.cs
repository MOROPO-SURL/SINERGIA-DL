namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Behaviors;

public sealed class FlexLayoutResponsiveChildViewBehavior : Behavior<View>
{
    public double WrapSpacing { get; set; } = 8;

    public double SingleSpacing { get; set; } = 4;

    public Models.ResponsiveColumnConfigurationModel ResponsiveColumnConfiguration { get; set; } = null!;

    protected override void OnAttachedTo(View bindable)
    {
        base.OnAttachedTo(bindable);

        bindable.ParentChanged += View_ParentChanged;
    }

    protected override void OnDetachingFrom(View bindable)
    {
        base.OnDetachingFrom(bindable);

        bindable.ParentChanged -= View_ParentChanged;
    }

    private void View_ParentChanged(object? sender, EventArgs eventArgs)
    {
        if (sender is not View view || view.Parent is not FlexLayout) throw new InvalidOperationException("FlexLayoutResponsiveChildViewBehavior attaching on a not FlexLayout child view!!!.");

        Binding binding = new()
        {
            Mode = BindingMode.OneWay,
            Source = view.Parent,
            Path = nameof(VisualElement.Width),
            Converter = new Converters.FlexLayoutIWithToResponsiveChildWithConverter
            {
                WrapSpacing = 8,
                SingleSpacing = 4,
            },
            ConverterParameter = ResponsiveColumnConfiguration
        };

        view.Margin = new Thickness(SingleSpacing);

        view.SetBinding(VisualElement.WidthRequestProperty, binding);
    }
}