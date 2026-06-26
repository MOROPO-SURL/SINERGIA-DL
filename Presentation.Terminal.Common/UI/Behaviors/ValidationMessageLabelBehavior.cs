using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Behaviors;

public sealed class ValidationMessageLabelBehavior : Behavior<Label>
{
    public string TargetValidationPropertyName { get; set; } = null!;

    public Style? InvalidStateStyle { get; set; }

    protected override void OnAttachedTo(Label bindable)
    {
        base.OnAttachedTo(bindable);

        bindable.Style = InvalidStateStyle;
        bindable.IsVisible = false;

        bindable.BindingContextChanged += TargetBindable_BindingContextChanged;
        bindable.PropertyChanged += TargetBindable_PropertyChanged;
    }

    protected override void OnDetachingFrom(Label bindable)
    {
        base.OnDetachingFrom(bindable);

        bindable.Style = null;

        bindable.BindingContextChanged -= TargetBindable_BindingContextChanged;
        bindable.PropertyChanged -= TargetBindable_PropertyChanged;
    }

    private void TargetBindable_BindingContextChanged(object? sender, EventArgs eventArgs)
    {
        if (sender == null || sender is not BindableObject bindable || bindable.BindingContext is not IValidableConfigurationPageModel validableConfigurationPageModel) return;

        Label target = (Label)sender!;

        Binding targetBinding = new()
        {
            Source = validableConfigurationPageModel,
            Path = nameof(IValidableConfigurationPageModel.ValidationResult),
            Mode = BindingMode.OneWay,
            Converter = new Converters.ValidationResultToTargetPropertyErrorMessageConverter(),
            ConverterParameter = TargetValidationPropertyName
        };

        target.SetBinding(Label.TextProperty, targetBinding);
    }

    private void TargetBindable_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs eventArgs)
    {
        if (Label.TextProperty.PropertyName != eventArgs.PropertyName) return;

        Label target = (Label)sender!;

        target.IsVisible = !string.IsNullOrEmpty(target!.Text);
    }
}
