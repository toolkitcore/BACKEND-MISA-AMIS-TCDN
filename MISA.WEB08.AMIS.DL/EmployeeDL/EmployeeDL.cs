using Dapper;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Enum;
using MISA.WEB08.AMIS.Common.Resources;
using MySqlConnector;
using System.Data;

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
        /// <summary>
        /// Lấy danh sách nhân viên theo điều kiện lọc và có phân trang
        /// </summary>
        /// <param name="EmployeeFilter">Điều kiện lọc</param>
        /// <returns>Danh sách nhân viên theo điều kiện lọc và có phân trang</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public PagingData<Employee> GetPagingData(EmployeeFilter filter)
        {
            // Khởi tạo kết quả trả về
            var result = new PagingData<Employee>()
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
            };

            // Tạo kết nối tới database
            using (var connection = GetConnection())
            {
                var procedureName = DatabaseUtility.GeneateStoreName<Employee>(ProcdureTypeName.GetPaging);

                // Tạo tham số truyền vào
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("v_KeyWord", filter.Keyword);
                dynamicParameters.Add("v_Offset", (filter.PageNumber - 1) * filter.PageSize);
                dynamicParameters.Add("v_Limit", filter.PageSize);

                // Thực hiện lấy dữ liệu
                var data = connection.QueryMultiple(procedureName, param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                if (data != null)
                {
                    result.Data = data.Read<Employee>().ToList();
                    result.TotalRecord = data.Read<int>().FirstOrDefault();
                }
                else
                {
                    result.Data = new List<Employee>();
                    result.TotalRecord = 0;
                }
                // Trả về kết quả
                return result;
            }
        }

        /// <summary>
        /// Xóa nhiều bản ghi theo danh sách khóa chính sử dụng transaction
        /// </summary>
        /// <param name="Ids">Danh sách khóa chính</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        public int DeleteMultipleEmployee(List<Guid> Ids)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<Employee>(ProcdureTypeName.DeleteMultiple);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("v_EmployeeIds", string.Join(",", Ids));
            using (var connection = GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                { // Khởi tạo transaction
                    try
                    {
                        var rowAffects = connection.Execute(procedureName, param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                        return rowAffects;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }
    }
}
