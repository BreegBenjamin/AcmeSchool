namespace AcmeSchool.Core.DTOs
{
    public class ResponseDTO<T>
    { 
        public string? ResponseMessage { get; set; }
        public bool Status { get; set; }
        public T? DataResponse { get; set; }
    }

    public class ResponseMessage
    {
        public string Message { get; set; } = "OK";
    }
}
