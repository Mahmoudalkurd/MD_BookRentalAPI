namespace BookRentalAPI.Domain.Common
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static OperationResult<T> Ok(T data) => new() { Success = true, Data = data, StatusCode = 200 };
        public static OperationResult<T> Fail(string error, int statusCode = 400) => new() { Success = false, ErrorMessage = error, StatusCode = statusCode };
        public static OperationResult<T> NotFound(string error = "Not found") => new() { Success = false, ErrorMessage = error, StatusCode = 404 };
    }
}