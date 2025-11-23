
namespace netCoreApi.DTO
{
    public class DataTable<T> where T : class
    {
        public IEnumerable<T> Data {  get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
