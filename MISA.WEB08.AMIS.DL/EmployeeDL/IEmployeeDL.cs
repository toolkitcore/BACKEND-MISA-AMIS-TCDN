using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Interface thao tác với database của Employee
    /// </summary>
    public interface IEmployeeDL : IBaseDL<Employee>
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
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>true: đã tồn tại, false: chưa tồn tại</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public bool CheckEmployeeCodeExist(string employeeCode, Guid? employeeId = null);

        /// <summary>
        /// Xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách id nhân viên cần xóa</param>
        /// <returns>Tổng số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        public int DeleteMultipleEmployee(List<Guid> employeeIds);

    }
}
