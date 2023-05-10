using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Comic.Backend.Model.Filter
{
    public class HeroFilter
    {
        public string TextToSearch { get; set; }
        public string ColumnToSort { get; set; } = "created_at desc";
        public int PageSize { get; set; } = 1;
        public int PageIndex { get; set; } = 100;
    }
}
