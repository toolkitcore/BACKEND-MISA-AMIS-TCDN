
namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Lớp dùng để lọc dữ liệu nhân viên
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class EmployeeFilter
    {
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int? PageNumber { get; set; } = 1;

        /// <summary>
        /// Số bản ghi trên một trang
        /// </summary>
        public int? PageSize
        {
            get
            {
                return PageSize > 100 ? 100 : PageSize;
            }
            set
            {
                PageSize = value <= 0 ? value : 20;
            }
        }

        /// <summary>
        /// Từ khóa tìm kiếm (tìm kiếm theo tên, mã, số điện thoại)
        /// </summary>
        public string? Keyword { get; set; }

    }
}
