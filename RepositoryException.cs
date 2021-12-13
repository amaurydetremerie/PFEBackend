using System.Net;
using System.Web.Http;

namespace PFEBackend
{
    public class RepositoryException : HttpResponseException
    {
        public String Message
        {
            get;
            private set;
        }
        public RepositoryException(HttpStatusCode statusCode) : base(statusCode)
        {
        }

        public RepositoryException(HttpResponseMessage response) : base(response)
        {
        }

        public RepositoryException(HttpStatusCode statusCode, String Message) : base(statusCode)
        {
            this.Message = Message;
        }
    }
}
