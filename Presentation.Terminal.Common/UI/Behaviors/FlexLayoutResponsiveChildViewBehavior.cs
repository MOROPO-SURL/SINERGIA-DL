namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Behaviors;

public sealed class FlexLayoutResponsiveChildViewBehavior : Behavior<View>
{
    public double WrapSpacing { get; set; } = 8;

    public double SingleSpacing { get; set; } = 4;

    public Models.ResponsiveColumnConfigurationModel ResponsiveColumnConfiguration { get; set; } = null!;

    protected override void OnAttachedTo(View bindable)
    {
        base.OnAttachedTo(bindable);

        if (bindable.Parent is not FlexLayout) throw new InvalidOperationException();

        Binding binding = new()
        {
            Mode = BindingMode.OneWay,
            Source = bindable.Parent,
            Path = nameof(VisualElement.Width),
            Converter = new Converters.FlexLayoutIWithToResponsiveChildWithConverter
            {
                WrapSpacing = 8,
                SingleSpacing = 4,
            },
            ConverterParameter = ResponsiveColumnConfiguration
        };

        bindable.Margin = new Thickness(SingleSpacing);

        bindable.SetBinding(VisualElement.WidthProperty, binding);
    }
}