namespace SimpleCRUD.ServiceModels
{
    public class ResponseBase
    {
        public int Status { get; set; }
    }
    public class Response: ResponseBase
    {
        public string Message { get; set; } = null!;
    }
    public class ResponseData<T>: Response
    {
        public T Object { get; set; }
        public List<T> List { get; set; }
    }
}
