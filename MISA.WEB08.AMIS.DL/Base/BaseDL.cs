using System.Data;
using Dapper;
using MISA.WEB08.AMIS.Common.Enum;
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
            dynamicParameters.Add($"v_{DatabaseUtility.GetPrimaryKeyName<T>()}", Id);
            using (var connection = GetConnection())
            {
                return connection.QueryFirstOrDefault<T>(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
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
            dynamicParameters.Add($"v_{DatabaseUtility.GetPrimaryKeyName<T>()}", newEntityId); // Gán ID cho đối tượng trước khi thêm vào database
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
            dynamicParameters.Add($"v_{DatabaseUtility.GetPrimaryKeyName<T>()}", Id);
            using (var connection = GetConnection())
            {
                return connection.Execute(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
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
            dynamicParameters.Add($"v_{DatabaseUtility.GetPrimaryKeyName<T>()}", Id);
            using (var connection = GetConnection())
            {
                return connection.Execute(procedureName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
    }
}
