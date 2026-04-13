namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Views;

public partial class BusyView : ContentView
{
    public static readonly BindableProperty SpinnerSizeProperty = BindableProperty.Create(nameof(SpinnerSize), typeof(double), typeof(View), 64.0, BindingMode.OneWay, null, SpinnerSizeProperty_Changed);

    public BusyView()
	{
		InitializeComponent();

        ActivitiyIndicator.WidthRequest = 64;
        ActivitiyIndicator.HeightRequest = 64;
    }

    public double SpinnerSize
    {
        get
        {
            return (double)GetValue(SpinnerSizeProperty);
        }
        set
        {
            SetValue(SpinnerSizeProperty, value);
        }
    }

    private static void SpinnerSizeProperty_Changed(BindableObject bindable, object oldValue, object newValue)
    {
        var spinner = (ActivityIndicator)bindable;

        spinner.WidthRequest = (double)newValue;
        spinner.HeightRequest = (double)newValue;
    }
}