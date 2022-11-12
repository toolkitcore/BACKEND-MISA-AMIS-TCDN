using MISA.WEB08.AMIS.Common.Entities;


namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Interface của lớp InventoryItemBL
    /// </summary>
    public interface IInventoryItemBL : IBaseBL<InventoryItem>
    {
        /// <summary>
        /// Lấy mã hàng hóa dịch vụ mới
        /// </summary>
        /// <returns>Mã hàng hóa dịch vụ mới</returns>
        /// Created by: AnhDV (06/11/2022)
        public string GetNewInventoryItemCode();
    }
}
