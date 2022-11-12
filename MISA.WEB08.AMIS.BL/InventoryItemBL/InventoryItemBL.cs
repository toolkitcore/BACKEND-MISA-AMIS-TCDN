using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.DL;


namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Lớp thực thi tầng BL của đối tượng InventoryItem
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class InventoryItemBL : BaseBL<InventoryItem>, IInventoryItemBL
    {
        #region Field
        IInventoryItemDL _inventoryItemDL;
        #endregion

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public InventoryItemBL(IInventoryItemDL inventoryItemDL) : base(inventoryItemDL)
        {
            _inventoryItemDL = inventoryItemDL;
        }

        /// <summary>
        /// Lấy mã hàng hóa dịch vụ mới
        /// </summary>
        /// <returns>Mã hàng hóa dịch vụ mới</returns>
        /// Created by: AnhDV (06/11/2022)

        public string GetNewInventoryItemCode()
        {
            return _inventoryItemDL.GetNewInventoryItemCode();
        }
    }
}
