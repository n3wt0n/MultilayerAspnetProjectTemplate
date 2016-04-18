using System.IO;
using System.Security.Claims;
using System.Web;

namespace MVCMultiLayer.Fakes.Http
{
    public static class FakeHttpContextHelper
    {
        /// <summary>
        /// Sets the HTTP context with a valid simulated request
        /// </summary>
        /// <param name="host">Host.</param>
        /// <param name="application">Application.</param>
        public static void SetHttpContext(string host, string application)
        {
            string appVirtualDir = "/";
            string appPhysicalDir = @"c:\\projects\\SubtextSystem\\Subtext.Web\\";
            string page = application.Replace("/", string.Empty) + "/default.aspx";
            string query = string.Empty;
            TextWriter output = null;

            FakeHttpRequest workerRequest = new FakeHttpRequest(appVirtualDir, appPhysicalDir, page, query, output, host);
            HttpContext.Current = new HttpContext(workerRequest);

            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                new System.Security.Principal.GenericIdentity("User Name"), 
                new string[] { "Administrator" }
                );                                   

            var claims = (ClaimsIdentity) HttpContext.Current.User.Identity;
            claims.AddClaim(new Claim("GalleryIDs", "1"));
            claims.AddClaim(new Claim("LocationGroupIDs", "1"));
            claims.AddClaim(new Claim("Language", "en"));
        }       
    }
}
