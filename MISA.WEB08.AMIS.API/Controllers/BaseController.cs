using Microsoft.AspNetCore.Mvc;
using MISA.WEB08.AMIS.BL;

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

        private string _className = typeof(T).Name; // Lấy tên class

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
            var entities = _baseBL.GetList();
            if (entities.Any())
            {
                return Ok(entities);
            }
            return NotFound();
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
            if (entity != null)
            {
                return Ok(entity);
            }
            return NotFound();
        }

        #endregion

        #region ADD
        /// <summary>
        /// API Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu cần thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpPost]
        public IActionResult Insert([FromBody] T entity)
        {
            var newEntityId = _baseBL.Insert(entity);
            if (newEntityId != null)
            {
                return StatusCode(StatusCodes.Status201Created, newEntityId);
            }
            return NoContent();
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
            var rowAffect = _baseBL.Delete(entityID);
            if (rowAffect > 0)
            {
                return Ok(rowAffect);
            }
            return NotFound();
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
            if (rowAffect > 0)
            {
                return Ok(rowAffect);
            }
            return NoContent();
        }
        #endregion
    }
}
