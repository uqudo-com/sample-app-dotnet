using System.Diagnostics;
using System.Reflection;
using UqudoSDK;

namespace UqudoSampleApp;

public class Tracer : UQTracer
{
    public override void Trace(UQTrace trace)
    {
        try
        {
            string sessionId = trace.SessionId ?? "";
            string statusMessage = trace.StatusMessage ?? "";

            string category = GetStringFromIntPtr(trace.Category);
            string eventStr = GetStringFromIntPtr(trace.Event);
            string page = GetStringFromIntPtr(trace.Page);
            string status = GetStringFromIntPtr(trace.Status);
            string statusCode = GetStringFromIntPtr(trace.StatusCode);

            Debug.WriteLine($"Trace(sessionId={sessionId}, category={category}, event={eventStr}, page={page}, status={status}, statusCode={statusCode}, statusMessage={statusMessage}, documentType={trace.DocumentType})");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Tracer error: {ex.Message}");
        }
    }

    private string GetStringFromIntPtr(IntPtr ptr)
    {
        foreach (var field in typeof(Constants).GetProperties())
        {
            if ((IntPtr)field.GetValue(null)! == ptr)
            {
                int underscoreIndex = field.Name.IndexOf('_');
                return underscoreIndex != -1 ? field.Name.Substring(underscoreIndex + 1) : field.Name;
            }
        }
        return "";
    }
}
