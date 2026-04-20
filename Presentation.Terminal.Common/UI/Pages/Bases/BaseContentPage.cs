namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;

public class BaseContentPage : ContentPage, IDisposable
{
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (!disposedValue) return;

        if (disposedValue) Content = null;

        GC.Collect();
    }

    #region IDisposable Support
    private bool disposedValue = false;

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                DisposeManagementResources();
            }

            DisposeUnmanagementResources();

            if (BindingContext is IDisposable disposable)
            {
                disposable.Dispose();
            }

            disposedValue = true;

            BindingContext = null;
        }
    }

    protected virtual void DisposeManagementResources() { }

    protected virtual void DisposeUnmanagementResources() { }

    public void Dispose()
    {
        Dispose(true);
    }
    #endregion
}
