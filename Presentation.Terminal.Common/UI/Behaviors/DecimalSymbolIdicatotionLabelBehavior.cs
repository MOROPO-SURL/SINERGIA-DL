namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Behaviors;

public sealed class DecimalSymbolIdicatotionLabelBehavior : Behavior<Label>
{
    protected override void OnAttachedTo(Label bindable)
    {
        base.OnAttachedTo(bindable);

        bindable.FontAttributes = FontAttributes.Italic;
        bindable.Text = $"Use el símbolo \"{System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}\" para definir puestos decimales";
    }
}
