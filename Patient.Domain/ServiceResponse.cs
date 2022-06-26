namespace Domain
{
    public class ServiceResponse<T>
    {
        public bool Success { get;protected set; }
        public string Message { get;protected set; }
        public T Result { get;protected set; } = default!;

        public ServiceResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public ServiceResponse(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }
}
