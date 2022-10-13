using MISA.WEB08.AMIS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Interface thực thi các xử lý nghiệp vụ của nhân viên
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        /// <summary>
        /// Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public string GetNewEmployeeCode();

        /// <summary>
        /// Lấy danh sách nhân viên theo điều kiện lọc và có phân trang
        /// </summary>
        /// <param name="EmployeeFilter">Điều kiện lọc</param>
        /// <returns>Danh sách nhân viên theo điều kiện lọc và có phân trang</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public PagingData<Employee> GetPagingData(EmployeeFilter filter);

        /// <summary>
        /// Xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách id nhân viên cần xóa</param>
        /// <returns>Tổng số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        public int DeleteMultipleEmployee(List<Guid> employeeIds);

        /// <summary>
        /// Xuất file excel danh sách nhân viên
        /// </summary>
        /// <returns>Stream file excel</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        public Stream ExportExcel();
    }
}
