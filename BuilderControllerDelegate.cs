using System.Diagnostics;
using UqudoSDK;

namespace UqudoSampleApp;

public class BuilderControllerDelegate : UQBuilderControllerDelegate
{
    public override void DidEnrollmentCompleteWithInfo(string info)
    {
        Debug.WriteLine($"Builder - Enrollment complete: {info}");
    }

    public override void DidEnrollmentIncompleteWithStatus(UQSessionStatus status)
    {
        Debug.WriteLine($"Builder - Enrollment incomplete: Code={status.StatusCode}, Task={status.StatusTask}, Message={status.Message}");
    }

    public override void DidAccountRecoveryCompleteWithInfo(string info)
    {
        Debug.WriteLine($"Builder - Account recovery complete: {info}");
    }

    public override void DidAccountRecoveryIncompleteWithStatus(UQSessionStatus status)
    {
        Debug.WriteLine($"Builder - Account recovery incomplete: Code={status.StatusCode}, Task={status.StatusTask}");
    }

    public override void DidRootedDeviceDetected(string info)
    {
        Debug.WriteLine($"Builder - Rooted device detected: {info}");
    }

    public override void DidLookupFlowCompleteWithInfo(string info)
    {
        Debug.WriteLine($"Builder - Lookup complete: {info}");
    }

    public override void DidLookupFlowIncompleteWithStatus(UQSessionStatus status)
    {
        Debug.WriteLine($"Builder - Lookup incomplete: Code={status.StatusCode}, Task={status.StatusTask}");
    }
}
