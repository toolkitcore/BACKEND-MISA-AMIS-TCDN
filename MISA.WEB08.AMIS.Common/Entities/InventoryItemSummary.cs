
namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Lớp lưu trữ thông tóm tắt của toàn bộ hàng hóa
    /// </summary>
    /// CreatedBy: AnhDV (01/11/2022)
    public class InventoryItemSummary
    {

        /// <summary>
        /// Số lượng tồn 
        /// </summary>
        public decimal? ClosingQuantity { get; set; }

        /// <summary>
        /// Giá trị tồn kho
        /// </summary>
        public decimal? ClosingAmount { get; set; }


        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int? TotalCount { get; set; }
    }

}
