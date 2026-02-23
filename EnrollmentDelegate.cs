using System.Diagnostics;
using Foundation;
using UqudoSDK;

namespace UqudoSampleApp;

public class EnrollmentDelegate : UQEnrollmentBuilderDelegate
{
    public override void DidEnrollmentCompleteWithInfo(string info)
    {
        Debug.WriteLine($"Enrollment complete: {info}");
    }

    public override void DidEnrollmentIncompleteWithStatus(UQSessionStatus status)
    {
        Debug.WriteLine($"Enrollment incomplete: Code={status.StatusCode}, Task={status.StatusTask}, Message={status.Message}");
    }

    public override void DidEnrollmentFailWithError(NSError error)
    {
        Debug.WriteLine($"Enrollment failed: {error.LocalizedDescription}");
    }
}
