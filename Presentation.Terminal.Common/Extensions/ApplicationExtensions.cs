namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

public static class ApplicationExtensions
{

    public static void PresentToastNotification(this Application self, Enumerations.NotificationKind kind, string message, TimeSpan? delay = null, TimeSpan? time = null)
    {
        //#if WINDOWS
        if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message)) return;

        if ((Application.Current!.MainPage as Shell)?.CurrentPage is not ContentPage targetPage) return;

        if (targetPage.Content is not Grid toastContainerGrid)
        {
            if (targetPage.Content is ScrollView targetScrollViewContent && targetScrollViewContent.Content is not Grid targetScrollViewContentGrid)
            {
                throw new InvalidOperationException();
            }
            else
            {
                toastContainerGrid = (Grid)((ScrollView)targetPage.Content).Content;
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
            self.Dispatcher.Dispatch(() =>
            {
                toastFrame.FadeTo(1).ContinueWith(async _ =>
                {
                    await Task.Delay(time ?? TimeSpan.FromSeconds(3));

                    self.Dispatcher.Dispatch(() =>
                    {
                        toastFrame.FadeTo(0).ContinueWith(_ =>
                        {
                            self.Dispatcher.Dispatch(() =>
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
