using System;
using System.IO;
using System.Web.Hosting;

namespace $safeprojectname$.Http
{
    /// <summary>
    /// Used to simulate an HttpRequest.
    /// </summary>
    public class FakeHttpRequest : SimpleWorkerRequest
    {
        string _host;
        string _requestType;

        /// <summary>
        /// Creates a new <see cref="FakeHttpRequest"/> instance.
        /// </summary>
        /// <param name="appVirtualDir">App virtual dir.</param>
        /// <param name="appPhysicalDir">App physical dir.</param>
        /// <param name="page">Page.</param>
        /// <param name="query">Query.</param>
        /// <param name="output">Output.</param>
        /// <param name="host">Host.</param>
        public FakeHttpRequest(string appVirtualDir, string appPhysicalDir, string page, string query, TextWriter output, string host, string requestType = "GET")
            : base(appVirtualDir, appPhysicalDir, page, query, output)
        {
            if (host == null || host.Length == 0)
                throw new ArgumentNullException("host", "Host cannot be null nor empty.");
            _host = host;
            this._requestType = requestType;
        }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <returns></returns>
        public override string GetServerName()
            => _host;

        /// <summary>
        /// Maps the path to a filesystem path.
        /// </summary>
        /// <param name="virtualPath">Virtual path.</param>
        /// <returns></returns>
        public override string MapPath(string virtualPath)
            => Path.Combine(this.GetAppPath(), virtualPath);

        public string RequestType
            => "GET";
    }

}
