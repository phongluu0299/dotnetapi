

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace netCoreApi.Helpers
{
    public class QueryTable 
    {
        private int? _page; 
        public int? Page { get { return _page; } set { _page = value ?? 0 ;} }

        private int? _size; 
        public int? Size { get { return _size; } set { _size = value ?? 10 ;} }

        private string? _order; 
        public string? Order { get { return _order; } set { _order = value ?? "asc" ;} }

        private string? _orderby;
        public string? OrderBy { get { return _orderby; } set { _orderby = value ?? ""; } }
        [NotMapped]
        public string CaseOrder => $"{OrderBy}_{Order}";
        [NotMapped]
        public int Skip => Page * Size ?? 0;
    }
}
