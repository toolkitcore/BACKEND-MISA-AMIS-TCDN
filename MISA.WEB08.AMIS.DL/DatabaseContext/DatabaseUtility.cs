using Dapper;
using MISA.WEB08.AMIS.Common.Enum;
using MISA.WEB08.AMIS.Common.Resources;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Lớp hỗ trợ thực hiện các thao tác với database
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class DatabaseUtility
    {
        /// <summary>
        /// Sinh tên Store Procedure theo tên entity và tên action cần thực hiện
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <param name="procdureTypeName">Kiểu thực thi của store (Thêm, sửa, xóa)</param>
        /// <returns>Tên store procedure</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GeneateStoreName<T>(ProcdureTypeName procdureTypeName)
        {

            // Lấy tên bảng
            var tableName = typeof(T).Name;

            // Lấy tên kiểu thao tác dữ liệu
            var procdureType = procdureTypeName.ToString();

            return string.Format(Resource.Proc_Name, tableName, procdureType);
        }

        /// <summary>
        /// Lấy property của entity là khóa chính
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <returns>Property là khóa chính</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GetPrimaryKeyName<T>()
        {
            var properties = typeof(T).GetProperties();
            string propertyName = string.Empty;
            foreach (var property in properties)
            {
                var primaryKeyAttribute = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(property, typeof(PrimaryKeyAttribute));
                if (primaryKeyAttribute != null)
                {
                    propertyName = property.Name;
                    break;
                }
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new Exception(string.Format(Resource.Exception_NoPrimaryKey, typeof(T).Name));
            }
            return propertyName;
        }

        /// <summary>
        /// Lấy giá tên của bảng
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <returns>Tên bảng</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GetTableName<T>()
        {
            var tableName = typeof(T).Name;
            return tableName;
        }
        /// <summary>
        /// Thực hiện mapping value của tham số đầu vào với các value của các property của đối tượng 
        /// và trả về danh sách các tham số
        /// </summary>
        /// <param name="entity">Đối tượng cần mapping</param>
        /// Created by: TCDN AnhDV (29/09/2022)
        public static DynamicParameters MappingParams<T>(T entity)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            // Lấy danh sách các property của đối tượng
            var properties = entity.GetType().GetProperties();
            // Duyệt từng property
            foreach (var property in properties)
            {
                // Lấy tên của property
                var propertyName = property.Name;
                // Lấy value của property
                var propertyValue = property.GetValue(entity);
                // Thêm tham số tương ứng với mỗi property của đối tượng
                dynamicParameters.Add($"v_{propertyName}", propertyValue);
            }
            return dynamicParameters;
        }
    }
}
