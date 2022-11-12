using MISA.WEB08.AMIS.Common.Entities;


namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Interface thực thi các thao tác với database của đối tượng InventoryItem
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public interface IInventoryItemDL : IBaseDL<InventoryItem>
    {
        /// <summary>
        /// Lấy mã hàng hóa dịch vụ mới
        /// </summary>
        /// <returns>Mã hàng hóa dịch vụ mới</returns>
        /// Created by: AnhDV (06/11/2022)
        public string GetNewInventoryItemCode();

    }
}
