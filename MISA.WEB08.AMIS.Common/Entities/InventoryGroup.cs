using MISA.WEB08.AMIS.Common.Enum;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Thực thể nhóm vật tư hàng hóa
    /// </summary>
    /// CreatedBy: AnhDV (30/10/2020)
    [ExcelFileName("nhom_vat_tu_hang_hoa")]
    [ExcelSheetName("Nhóm vật tư hàng hóa")]
    public class InventoryGroup : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid InventoryGroupID { get; set; }

        /// <summary>
        /// ParentID của nhóm vật tư
        /// </summary>
        public Guid? InventoryGroupParentID { get; set; }

        /// <summary>
        /// Mã nhóm vật tư
        /// </summary>
        [Filter]
        [Unique]
        [ExcelColumnName("Mã nhóm vật tư")]
        public string? InventoryGroupCode { get; set; }

        /// <summary>
        /// Tên nhóm vật tư
        /// </summary>
        [Filter]
        [ExcelColumnName("Tên nhóm vật tư")]
        public string? InventoryGroupName { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        [Filter]
        [ExcelColumnName("Trạng thái")]
        [Status]
        public Status Status { get; set; }
    }
}
