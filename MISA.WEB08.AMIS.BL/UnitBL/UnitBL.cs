using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.DL;


namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Lớp thực thi tầng BL của đối tượng Unit
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class UnitBL : BaseBL<Unit>
    {
        /// <summary>
        /// Khởi tạo đối tượng UnitDL
        /// </summary>
        /// Created by: AnhDV (01/11/2022)
        public UnitBL(IBaseDL<Unit> baseDL) : base(baseDL)
        {
        }
    }
}
