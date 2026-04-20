namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;

public interface IExceptionHandlingHelperPort
{
    void HandleException(Exception? exception, Action<Exception>? callbackAction = null);
}