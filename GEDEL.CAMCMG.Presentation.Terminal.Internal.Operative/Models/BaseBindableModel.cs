namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models;

public class BaseBindableModel : System.ComponentModel.INotifyPropertyChanged, IDisposable
{
    public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    }

    protected void SetProperty<T>(ref T property, T newValue, Action? listener = null, [System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        if (Equals(property, newValue)) return;

        property = newValue;

        RaisePropertyChanged(propertyName);

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
