using System.Net;

namespace Core.Exceptions
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpException(HttpStatusCode code)
        {
            StatusCode = code;
        }
        public HttpException(string message, HttpStatusCode code) : base(message)
        {
            StatusCode = code;
        }
        public HttpException(string message, HttpStatusCode code, Exception inner) : base(message, inner)
        {
            StatusCode = code;
        }
        protected HttpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
