namespace RestSharp
{
    using System.Net;
    public class RestRequestAsyncHandle
    {
        public RestRequestAsyncHandle()
        {
        }

        public RestRequestAsyncHandle(HttpWebRequest webRequest)
        {
            this.WebRequest = webRequest;
        }

        public HttpWebRequest WebRequest { get; set; }

        public void Abort()
        {
            if (this.WebRequest != null)
                this.WebRequest.Abort();
        }
    }
}
