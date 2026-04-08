namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;

public static class ContentPageExtensions
{
    public static void PresentToastNotification(this ContentPage target, Enumerations.NotificationKind kind, string message, TimeSpan? delay = null, TimeSpan? time = null)
    {
        //#if WINDOWS
        if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message)) return;

        if (target.Content is not Grid toastContainerGrid)
        {
            if (target.Content is ScrollView targetScrollViewContent && targetScrollViewContent.Content is not Grid)
            {
                throw new InvalidOperationException();
            }
            else
            {
                toastContainerGrid = (Grid)((ScrollView)target.Content).Content;
            }
        }

        if (toastContainerGrid == null) throw new InvalidOperationException();

        var toastFrame = new Frame
        {
            Style = (Style)Application.Current!.Resources[$"{Enum.GetName(kind)}ToastFrameStyle"],
            Opacity = 0,
            Margin = new Thickness(48),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.End,
            Content = new Label
            {
                Style = (Style)Application.Current.Resources[$"{Enum.GetName(kind)}ToastLabelStyle"],
                Text = message
            }
        };

        if (toastContainerGrid.ColumnDefinitions.Count > 1) Grid.SetColumnSpan(toastFrame, toastContainerGrid.ColumnDefinitions.Count);

        if (toastContainerGrid.RowDefinitions.Count > 1) Grid.SetRowSpan(toastFrame, toastContainerGrid.RowDefinitions.Count);

        toastContainerGrid.Add(toastFrame);

        Task.Delay(delay ?? TimeSpan.FromMilliseconds(100)).ContinueWith(_ =>
        {
            target.Dispatcher.Dispatch(() =>
            {
                toastFrame.FadeTo(1).ContinueWith(async _ =>
                {
                    await Task.Delay(time ?? TimeSpan.FromSeconds(3));

                    target.Dispatcher.Dispatch(() =>
                    {
                        toastFrame.FadeTo(0).ContinueWith(_ =>
                        {
                            target.Dispatcher.Dispatch(() =>
                            {
                                toastContainerGrid.Remove(toastFrame);

                                toastFrame = null;
                            });
                        });
                    });
                });
            });
        });
        //#else
        //            CommunityToolkit.Maui.Alerts.Snackbar.Make(message).Show();
        //#endif
    }
}
