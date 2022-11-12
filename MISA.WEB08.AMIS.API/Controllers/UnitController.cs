
using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.Common.Entities;


namespace MISA.WEB08.AMIS.API.Controllers
{

    /// <summary>
    /// Controller thực thi các thao tác với đối tượng Unit
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class UnitController : BaseController<Unit>
    {

        /// <summary>
        /// Khởi tạo controller
        /// </summary>
        /// Created by: AnhDV (01/11/2022)
        public UnitController(IBaseBL<Unit> baseBL) : base(baseBL)
        {
        }

    }
}
