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
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>true: đã tồn tại, false: chưa tồn tại</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public bool CheckEmployeeCodeExist(string employeeCode, Guid? employeeId = null);



    }
}
