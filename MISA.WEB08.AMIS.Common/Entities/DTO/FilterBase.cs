
namespace MISA.WEB08.AMIS.Common.Entities.DTO
{
    public class FilterBase
    {
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Số bản ghi trên một trang
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Từ khóa tìm kiếm
        /// </summary>
        public string? Keyword { get; set; }

        public List<Filter>? Filter { get; set; }
    }
}
