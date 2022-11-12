using Microsoft.AspNetCore.Mvc;
using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Resources;

namespace MISA.WEB08.AMIS.API.Controllers
{

    /// <summary>
    /// Controller quản lý nhân viên
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class EmployeeController : BaseController<Employee>
    {
        private IEmployeeBL _employeeBL;
        private IBaseBL<Employee> _baseBL;

        public EmployeeController(IBaseBL<Employee> baseBL, IEmployeeBL employeeBL) : base(baseBL)
        {
            _baseBL = baseBL;
            _employeeBL = employeeBL;
        }


        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpGet("new-employee-code")]
        public IActionResult GetNewEmployeeCode()
        {
            string maxEmployeeCode = _employeeBL.GetNewEmployeeCode();
            // Trả về dữ liệu cho client
            return Ok(maxEmployeeCode);
        }


        /// <summary>
        /// Xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách id nhân viên cần xóa</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        [HttpPost("delete-multiple")]
        public IActionResult DeleteMultiple([FromBody] List<Guid> employeeIds)
        {
            var response = _baseBL.DeleteMultiple(employeeIds);
            return Ok(response);
        }
    }
}
