using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.API.Controllers
{

    /// <summary>
    /// Controller thực thi các thao tác với đối tượng InventoryGroup
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class InventoryGroupController : BaseController<InventoryGroup>
    {
        /// <summary>
        /// Khởi tạo controller
        /// </summary>
        /// Created by: AnhDV (01/11/2022)
        public InventoryGroupController(IBaseBL<InventoryGroup> baseBL) : base(baseBL)
        {
        }
    }
}
