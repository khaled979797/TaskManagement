namespace TaskManagement.Core.Helpers
{
    public class ResponseHandler
    {
        public NewResponse<T> Deleted<T>(string message = null!)
        {
            return new NewResponse<T>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message is null ? "Deleted" : message
            };
        }

        public NewResponse<T> Success<T>(T entity, object meta = null!)
        {
            return new NewResponse<T>
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Success",
                Meta = meta
            };
        }

        public NewResponse<T> Unauthorized<T>(string message = null!)
        {
            return new NewResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = message == null ? "UnAuthorized" : message
            };
        }

        public NewResponse<T> BadRequest<T>(string message = null!)
        {
            return new NewResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null ? "BadRequest" : message
            };
        }

        public NewResponse<T> UnprocessableEntity<T>(string message = null!)
        {
            return new NewResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? "UnprocessableEntity" : message
            };
        }

        public NewResponse<T> NotFound<T>(string message = null!)
        {
            return new NewResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "NotFound" : message
            };
        }

        public NewResponse<T> Created<T>(T entity, object meta = null!)
        {
            return new NewResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = meta
            };
        }
    }
}
