namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models;

public class BaseBindableModel : BindableObject, System.ComponentModel.INotifyPropertyChanged, IDisposable
{
    protected void SetProperty<T>(ref T property, T newValue, Action? listener = null, [System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        if (Equals(property, newValue)) return;

        property = newValue;

        OnPropertyChanged(propertyName);

        listener?.Invoke();
    }

    #region IDisposable Support
    private bool disposedValue = false;

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                DisposeManagedResources();
            }

            DisposeUnmanagedResources();

            disposedValue = true;
        }
    }

    protected virtual void DisposeManagedResources() { }

    protected virtual void DisposeUnmanagedResources() { }

    public void Dispose()
    {
        Dispose(true);
    }
    #endregion
}
