using MISA.WEB08.AMIS.Common.Enum;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Lớp lưu trữ thông tin đơn vị tính
    /// CreatedBy: AnhDV (27/10/2022)
    [ExcelFileNameAttribute("don_vi_tinh")]
    [ExcelSheetNameAttribute("Đơn vị tính")]
    public class Unit : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid UnitID { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        [Filter]
        [Unique("Tên đơn vị tính đã tồn tại")]
        [ExcelColumnName("Tên đơn vị tính")]
        [Required("Tên đơn vị tính không được để trống")]
        public string? UnitName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        [Filter]
        [ExcelColumnName("Mô tả")]
        public string? Description { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        [Filter]
        [ExcelColumnName("Trạng thái")]
        [Status]
        public Status Status { get; set; }


    }
}
