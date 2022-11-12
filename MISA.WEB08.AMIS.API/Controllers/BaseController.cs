using Microsoft.AspNetCore.Mvc;
using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.Common.Entities.DTO;
using MISA.WEB08.AMIS.Common.Utilities;

namespace MISA.WEB08.AMIS.API.Controllers
{
    /// <summary>
    /// Lớp controller chung
    /// </summary>
    /// Created by: TCDN AnhDV (16/09/2022)
    [Route("api/v2/[controller]s")]
    [ApiController]

    public class BaseController<T> : ControllerBase
    {
        #region Fields
        private readonly IBaseBL<T> _baseBL; // Khai báo interface


        #endregion

        #region Constructor
        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion

        #region GET
        /// <summary>
        /// API Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleReturnResult(_baseBL.GetList());
        }

        /// <summary>
        /// Lọc dữ liệu theo điều kiện v2 và có phân trang
        /// </summary>
        /// <param name="filter">Điều kiện lọc</param>
        /// <param name="pageNumer">Số trang</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <returns>Danh sách dữ liệu theo điều kiện</returns>
        /// Created by: AnhDV (24/10/2022)
        [HttpPost("filter")]
        public IActionResult GetPagingDataV2([FromBody] FilterBase filter)
        {
            var entities = _baseBL.GetPagingDataV2(filter.PageSize, filter.PageNumber, filter.Keyword, filter.Filter);
            return HandleReturnResult(entities);
        }


        /// <summary>
        /// API Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="Id">Id là khóa chính của bảng</param>
        /// <returns>Dữ liệu tương ứng với Id</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpGet("{entityID}")]
        public IActionResult GetEntityById([FromRoute] Guid entityID)
        {
            var entity = _baseBL.GetEntityById(entityID);
            return HandleReturnResult(entity);
        }

        #endregion

        #region INSERT
        /// <summary>
        /// API Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu cần thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpPost]
        public IActionResult Insert([FromBody] T entity)
        {
            return HandleReturnResult(_baseBL.Insert(entity));
        }
        #endregion

        #region DELETE
        /// <summary>
        /// API Xóa dữ liệu theo Id
        /// </summary>
        /// <param name="Id">Id là khóa chính của bảng</param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpDelete("{entityID}")]
        public IActionResult DeleteById([FromRoute] Guid entityID)
        {
            return HandleReturnResult(_baseBL.Delete(entityID));
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// API Cập nhật dữ liệu theo Id
        /// </summary>
        /// <param name="entity">Dữ liệu cần cập nhật</param>
        /// <param name="entityID">Id là khóa chính của bảng</param>
        /// <returns>Số bản ghi bị cập nhật</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpPut("{entityID}")]
        public IActionResult Update([FromBody] T entity, [FromRoute] Guid entityID)
        {
            var rowAffect = _baseBL.Update(entityID, entity);
            return HandleReturnResult(rowAffect);
        }

        /// <summary>
        /// API Cập nhật trạng thái theo Id
        /// </summary>
        /// <param name="entityID">Id là khóa chính của bảng</param>
        /// <param name="status">Trạng thái</param>
        /// <returns>Số bản ghi bị cập nhật</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpPut("status/{entityID}")]
        public IActionResult UpdateStatus([FromRoute] Guid entityID, [FromQuery] int status)
        {
            var rowAffect = _baseBL.UpdateStatus(status, entityID);
            return HandleReturnResult(rowAffect);
        }
        #endregion

        #region EXPORT
        /// <summary>
        /// Xuất file excel
        /// </summary>
        /// <returns>File excel</returns>
        /// Created by: TCDN AnhDV (05/10/2022)
        [HttpGet("export")]
        public IActionResult ExportExcel()
        {
            var stream = _baseBL.ExportExcel(null, true);
            string excelName = $"Danh_sach_{CommonUtility.GetExcelFileName<T>()}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        #endregion

        /// <summary>
        /// Hàm xử lý kết quả trả về
        /// </summary>
        /// <param name="result">Kết quả trả về</param>
        /// <returns>Trả về kết quả</returns>
        /// Created by: AnhDV (11/08/2022)
        /// <summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual IActionResult HandleReturnResult(object result)
        {
            var res = new
            {
                Success = true,
                MisaCode = 0,
                Data = result,
            };
            return StatusCode(200, res);
        }
    }
}
