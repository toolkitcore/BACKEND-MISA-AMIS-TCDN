using System.Data;
using Dapper;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Entities.DTO;
using MISA.WEB08.AMIS.Common.Enum;
using MISA.WEB08.AMIS.Common.Utilities;
using MySqlConnector;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Lớp dùng để thực thi những nghiệp vụ chung tầng Data Layer
    /// Created by: TCDN AnhDV (29/09/2022)
    /// </summary>
    public class BaseDL<T> : IBaseDL<T>
    {
        #region BASE METHOD
        /// <summary>
        /// Thực hiện kêt nối với database
        /// </summary>
        /// <returns>Đối tượng kết nối</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        protected MySqlConnection GetConnection()
        {
            // Lấy chuỗi kết nối tới database
            string connectionString = DatabaseContext.ConnectionString;
            // Khởi tạo đối tượng kết nối
            MySqlConnection connection = new MySqlConnection(connectionString);
            // Mở kết nối
            connection.Open();
            return connection;
        }
        #endregion

        #region GET
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        public IEnumerable<T> GetList()
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.GetAll);
            using (var connection = GetConnection())
            {
                return connection.Query<T>(procedureName, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Lấy danh sách dữ liệu để export excel
        /// </summary>
        /// <returns>Danh sách dữ liệu export excel</returns>
        /// Created by: TCDN AnhDV (07/10/2022)
        public IEnumerable<T> GetListExport()
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.Export);
            using (var connection = GetConnection())
            {
                return connection.Query<T>(procedureName, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Lấy chi tiết dữ liệu theo khóa chính của bảng 
        /// </summary>
        /// <param name="id">Khóa chính</param>
        /// <returns>Thông tin chi tiết</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        public T GetEntityById(object Id)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.GetByID);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"v_{CommonUtility.GetPrimaryKeyName<T>()}", Id);
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<T>(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Lấy danh sách dữ liệu theo điều kiện
        /// </summary>
        /// <param name="whereCondition">Điều kiện lọc</param>
        /// <returns>Danh sách dữ liệu</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        public PagingData<T> GetPagingData(FilterBase filter)
        {
            // Khởi tạo kết quả trả về
            var result = new PagingData<T>()
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
            };

            // Tạo kết nối tới database
            using (var connection = GetConnection())
            {
                var procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.GetPaging);

                // Tạo tham số truyền vào
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("v_KeyWord", filter.Keyword);
                dynamicParameters.Add("v_Offset", (result.PageNumber - 1) * result.PageSize);
                dynamicParameters.Add("v_Limit", result.PageSize);

                // Thực hiện lấy dữ liệu
                var data = connection.QueryMultiple(procedureName, param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                if (data != null)
                {
                    result.Data = data.Read<T>().ToList();
                    result.TotalRecord = data.Read<int>().FirstOrDefault();
                }
                else
                {
                    result.Data = new List<T>();
                    result.TotalRecord = 0;
                }
                // Trả về kết quả
                return result;
            }
        }

        /// <summary>
        /// Xử lý lấy dữ liệu theo filter v2
        /// </summary>
        /// <param name="filters">Điều kiện lọc</param>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <returns>Danh sách dữ liệu</returns>
        public virtual PagingData<T> GetPagingDataV2(int pageSize, int pageNumber, string? keyword, string filters)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.GetPagingV2);
            using (var connection = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("v_Offset", (pageNumber - 1) * pageSize);
                dynamicParameters.Add("v_Limit", pageSize);
                dynamicParameters.Add("v_Where", filters);
                dynamicParameters.Add("v_KeyWord", keyword);
                var data = connection.QueryMultiple(procedureName, param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var result = new PagingData<T>()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Data = data.Read<T>().ToList(),
                    TotalRecord = data.Read<int>().FirstOrDefault(),
                };
                return result;
            }
        }

        #endregion

        #region INSERT
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Thông tin dữ liệu</param>
        /// <returns>ID của dữ liệu vừa thêm</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        public Guid Insert(T entity)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.Insert);
            DynamicParameters dynamicParameters = DatabaseUtility.MappingParams<T>(entity);
            var newEntityId = Guid.NewGuid(); // Tạo mới ID cho đối tượng
            dynamicParameters.Add($"v_{CommonUtility.GetPrimaryKeyName<T>()}", newEntityId); // Gán ID cho đối tượng trước khi thêm vào database
            using (var connection = GetConnection())
            {
                var rowAffects = connection.Execute(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                if (rowAffects > 0)
                {
                    return newEntityId;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Xóa một bản ghi theo khóa chính
        /// </summary>
        /// <param name="Id">Khóa chính</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        public int Delete(Guid Id)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.Delete);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"v_{CommonUtility.GetPrimaryKeyName<T>()}", Id);
            using (var connection = GetConnection())
            {
                return connection.Execute(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách id cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        public int DeleteMultiple(List<Guid> Ids)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.DeleteMultiple);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"v_{CommonUtility.GetTableName<T>()}Ids", string.Join(",", Ids));
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
        #endregion

        #region UPDATE
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="Id">Id của dữ liệu cần cập nhật</param>
        /// <param name="entity">Dữ liệu cần cập nhật</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (29/09/2022)
        public virtual int Update(Guid Id, T entity)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<T>(ProcdureTypeName.Update);
            DynamicParameters dynamicParameters = DatabaseUtility.MappingParams<T>(entity);
            dynamicParameters.Add($"v_{CommonUtility.GetPrimaryKeyName<T>()}", Id);
            using (var connection = GetConnection())
            {
                return connection.Execute(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Hàm cập nhật status của bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="fieldName">Tên trường</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: Customize (28/10/2022)
        public int UpdateStatus(string fieldName, int value, Guid? id)
        {
            string procedureName = $"Proc_{ProcdureTypeName.UpdateStatus}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("v_TableName", CommonUtility.GetTableName<T>());
            dynamicParameters.Add("v_FieldName", fieldName);
            dynamicParameters.Add("v_Value", value);
            dynamicParameters.Add("v_FieldNameId", CommonUtility.GetPrimaryKeyName<T>());
            dynamicParameters.Add("v_Id", id);
            using (var connection = GetConnection())
            {
                return connection.Execute(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion


        /// <summary>
        /// Hàm kiểm tra unique dữ liệu cho field truyền vào
        /// </summary>
        /// <param name="FieldName">Tên trường</param>
        /// <param name="Value">Giá trị</param>
        /// <param name="Id">Id của bản ghi</param>
        /// <returns>true: unique, false: không unique</returns>
        /// Created by: Customize (28/10/2022)
        public bool CheckUnique(string fieldName, object value, Guid? id)
        {
            string procedureName = $"Proc_{ProcdureTypeName.CheckUnique}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("v_TableName", CommonUtility.GetTableName<T>());
            dynamicParameters.Add("v_FieldName", fieldName);
            dynamicParameters.Add("v_Value", value);
            dynamicParameters.Add("v_FieldNameId", CommonUtility.GetPrimaryKeyName<T>());
            dynamicParameters.Add("v_Id", id);
            using (var connection = GetConnection())
            {
                var result = connection.QueryFirstOrDefault<int>(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return result == 0;
            }
        }

    }
}
