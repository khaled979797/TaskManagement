using System.Net;

namespace TaskManagement.Core.Helpers
{
    public class NewResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public NewResponse() { }
        public NewResponse(T data, string message = null!)
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }
        public NewResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public NewResponse(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
