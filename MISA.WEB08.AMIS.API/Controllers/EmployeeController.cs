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

        public EmployeeController(IEmployeeBL baseBL) : base(baseBL)
        {
            _employeeBL = baseBL;
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
        /// Lấy danh sách nhân viên theo điều kiện lọc và có phân trang
        /// </summary>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>Danh sách nhân viên theo điều kiện lọc và có phân trang</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        [HttpGet("filter")]
        public IActionResult GetPagingData([FromQuery] EmployeeFilter filter)
        {
            var employeeData = _employeeBL.GetPagingData(filter);
            return StatusCode(StatusCodes.Status200OK, employeeData);
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
            var response = _employeeBL.DeleteMultipleEmployee(employeeIds);
            return Ok(response);
        }

        /// <summary>
        /// Xuất file excel danh sách nhân viên
        /// </summary>
        /// <returns>File excel danh sách nhân viên</returns>
        /// Created by: TCDN AnhDV (05/10/2022)
        [HttpGet("export")]
        public IActionResult ExportExcel()
        {
            var stream = _employeeBL.ExportExcel();
            string excelName = $"{ExportResource.Export_Employee_File_Name}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
