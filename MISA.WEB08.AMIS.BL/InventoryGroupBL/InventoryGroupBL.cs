using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.DL;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ của nhóm hàng tầng BL
    /// </summary>
    /// CreatedBy: AnhDV (10/11/2022)
    public class InventoryGroupBL : BaseBL<InventoryGroup>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InventoryGroupBL(IBaseDL<InventoryGroup> baseDL) : base(baseDL)
        {
        }
    }
}
