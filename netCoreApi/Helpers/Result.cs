namespace netCoreApi.Helpers
{
    public class Result
    {
        public object? Data { get; set;}
        public string? Message { get; set;}
        public ResultCode Code { get; set;}
    }
    public class ResultTable 
    {
        private int? _total;
        public int? Total { get { return _total; } set { _total = value ?? 0; }}
        public object? Content { get; set;}
    }
   
    public enum ResultCode
    {
        Success = 200,
        Error = 500,
        BadRequest = 400,
    }
}
