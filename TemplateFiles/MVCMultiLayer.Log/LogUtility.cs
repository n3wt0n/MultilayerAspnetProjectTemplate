using System;
using System.Text;

namespace $safeprojectname$
{
    public class LogUtility
    {  
        public static string BuildExceptionMessage(Exception x)
        {        
            Exception logException = x;
            if (x.InnerException != null)
                logException = x.InnerException;

            var strErrorMsg = new StringBuilder();
            strErrorMsg.AppendLine($"Error in Path: {System.Web.HttpContext.Current.Request.Path}");

            // Get the QueryString along with the Virtual Path
            strErrorMsg.AppendLine($"Raw Url: {System.Web.HttpContext.Current.Request.RawUrl}");

            // Get the error message
            strErrorMsg.AppendLine($"Message: {logException.Message}");

            // Source of the message
            strErrorMsg.AppendLine($"Source: {logException.Source}");

            // Stack Trace of the error
            strErrorMsg.AppendLine($"Stack Trace: {logException.StackTrace}");

            // Method where the error occurred
            strErrorMsg.AppendLine($"TargetSite: {logException.TargetSite}");

            return strErrorMsg.ToString();            
        }
    }
}
