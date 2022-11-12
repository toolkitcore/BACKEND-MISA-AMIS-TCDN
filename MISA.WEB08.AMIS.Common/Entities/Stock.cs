using MISA.WEB08.AMIS.Common.Enum;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Lớp lưu trữ thông tin kho
    /// CreatedBy: AnhDV (28/10/2022)
    [ExcelFileName("kho")]
    [ExcelSheetName("Kho")]
    public class Stock : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid StockID { get; set; }

        /// <summary>
        /// Mã kho
        /// </summary>
        [Filter]
        [Unique("Mã kho đã tồn tại")]
        [ExcelColumnName("Mã kho")]
        [Required("Mã kho không được để trống")]
        public string? StockCode { get; set; }

        /// <summary>
        /// Tên kho
        /// </summary>
        [Filter]
        [ExcelColumnName("Tên kho")]
        [Required("Tên kho không được để trống")]
        public string? StockName { get; set; }

        /// <summary>
        /// Địa chỉ kho
        /// </summary>
        [Filter]
        [ExcelColumnName("Địa chỉ kho")]
        public string? Address { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        [Filter]
        [ExcelColumnName("Trạng thái")]
        [Status]
        public Status Status { get; set; }

    }
}
