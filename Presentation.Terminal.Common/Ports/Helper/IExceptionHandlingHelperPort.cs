namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;

public interface IExceptionHandlingHelperPort
{
    void HandleException(Exception? exception, Action<Exception?>? callbackAction = null);
}