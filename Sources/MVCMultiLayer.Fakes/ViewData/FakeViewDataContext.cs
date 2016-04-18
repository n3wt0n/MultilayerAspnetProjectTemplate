using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace MVCMultiLayer.Fakes.ViewData
{
    public class FakeViewDataContext : HttpContextBase
    {
        private Dictionary<object, object> _items = new Dictionary<object, object>();
        public override IDictionary Items 
            => _items;

        public override HttpRequestBase Request
            => new HttpRequestWrapper(new HttpRequest("index.html", "http://fakeurl", ""));                                                    
    }
}
