namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;

public static class PageNavigationExtensions
{
    public static Task NavigationPushPageAsync(this Page self, Page page, bool animate = true)
    {
        return self.Navigation.PushAsync(page, animate);
    }

    public static Task NavigationPushModalPageAsync(this Page self, Page page, bool animate = true)
    {
        return self.Navigation.PushModalAsync(page, animate);
    }

    public static Task NavigationPopPageAsync(this Page self, bool animate = true, Action<Page>? callbackAction = null)
    {
        return self.Navigation.PopAsync(animate).ContinueWith((task) =>
        {
            task.Result.Dispatcher.Dispatch(() =>
            {
                callbackAction?.Invoke(task.Result);

                if (task.Result is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            });
        });
    }

    public static Task NavigationPopModalPageAsync(this Page self, bool animate = true, Action<Page>? callbackAction = null)
    {
        return self.Navigation.PopModalAsync(animate).ContinueWith((task) =>
        {
            task.Result.Dispatcher.Dispatch(() =>
            {
                callbackAction?.Invoke(task.Result);

                if (task.Result is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            });
        });
    }
}
