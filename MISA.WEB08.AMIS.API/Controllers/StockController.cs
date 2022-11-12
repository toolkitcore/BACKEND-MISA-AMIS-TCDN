using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.API.Controllers
{

    /// <summary>
    /// Controller thực thi các thao tác với đối tượng Stock
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class StockController : BaseController<Stock>
    {
        /// <summary>
        /// Khởi tạo controller
        /// </summary>
        /// Created by: AnhDV (01/11/2022)
        public StockController(IBaseBL<Stock> baseBL) : base(baseBL)
        {
        }
    }
}
