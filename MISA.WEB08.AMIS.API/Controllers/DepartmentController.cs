using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.API.Controllers
{

    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(IBaseBL<Department> baseBL) : base(baseBL)
        {
        }
    }
}
