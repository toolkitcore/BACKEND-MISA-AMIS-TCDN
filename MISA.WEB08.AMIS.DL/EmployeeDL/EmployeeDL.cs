using Dapper;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Enum;


namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Lớp thao tác với database của Employee
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {

        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public string GetNewEmployeeCode()
        {
            string procedureName = DatabaseUtility.GeneateStoreName<Employee>(ProcdureTypeName.GetMaxCode);
            using (var connection = GetConnection())
            {
                // Thực hiện lấy dữ liệu
                var result = connection.QueryFirstOrDefault<string>(procedureName, commandType: System.Data.CommandType.StoredProcedure);
                // Trả về kết quả
                return result;
            }
        }

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>true: đã tồn tại, false: chưa tồn tại</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public bool CheckEmployeeCodeExist(string employeeCode, Guid? employeeId = null)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<Employee>(ProcdureTypeName.GetCode);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("v_EmployeeCode", employeeCode);
            dynamicParameters.Add("v_EmployeeID", employeeId);
            using (var connection = GetConnection())
            {
                // Thực hiện lấy dữ liệu
                return connection.QueryFirstOrDefault<bool>(procedureName, param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
