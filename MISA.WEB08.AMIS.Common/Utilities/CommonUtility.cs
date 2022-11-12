using MISA.WEB08.AMIS.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.Common.Utilities
{
    /// <summary>
    /// Lớp chứa các hàm xử lý chung
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class CommonUtility
    {
        /// <summary>
        /// Lấy ra tên của property có attribute truyền vào
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <param name="attributeType">Kiểu attribute cần lấy</param>
        /// <returns>Tên của property có attribute truyền vào</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GetPropertyNameByAttribute<T>(Type attributeType)
        {
            var properties = typeof(T).GetProperties();
            string propertyName = string.Empty;
            foreach (var property in properties)
            {
                var attribute = (Attribute?)Attribute.GetCustomAttribute(property, attributeType);
                if (attribute != null)
                {
                    propertyName = property.Name;
                    break;
                }
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new Exception(string.Format(Resource.Property_NotFound, typeof(T).Name));
            }
            return propertyName;
        }
        /// <summary>
        /// Lấy property của entity là khóa chính
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <returns>Property là khóa chính</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GetPrimaryKeyName<T>()
        {
            return GetPropertyNameByAttribute<T>(typeof(PrimaryKeyAttribute));
        }

        /// <summary>
        /// Lấy ra các property có attribute truyền vào
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <param name="attributeType">Kiểu attribute cần lấy</param>
        /// <returns>Danh sách các property có attribute truyền vào</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static List<string> GetPropertiesByAttribute<T>(Type attributeType)
        {
            var properties = typeof(T).GetProperties();
            List<string> propertyNames = new List<string>();
            foreach (var property in properties)
            {
                var attribute = (Attribute?)Attribute.GetCustomAttribute(property, attributeType);
                if (attribute != null)
                {
                    propertyNames.Add(property.Name);
                }
            }
            return propertyNames;
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
        /// Lấy ra tên của file excel
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <returns>Tên file excel</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GetExcelFileName<T>()
        {
            var excelFileNameAttribute = (ExcelFileNameAttribute?)Attribute.GetCustomAttribute(typeof(T), typeof(ExcelFileNameAttribute));
            if (excelFileNameAttribute != null)
            {
                return excelFileNameAttribute.FileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// Lấy ra tên sheet của file excel
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <returns>Tên sheet của file excel</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GetExcelSheetName<T>()
        {
            var excelSheetNameAttribute = (ExcelSheetNameAttribute?)Attribute.GetCustomAttribute(typeof(T), typeof(ExcelSheetNameAttribute));
            if (excelSheetNameAttribute != null)
            {
                return excelSheetNameAttribute.SheetName;
            }
            return string.Empty;
        }

        /// <summary>
        /// Lấy ra cột status của bảng
        /// </summary>
        /// <typeparam name="T">Entity truyền vào</typeparam>
        /// <returns>Tên cột status</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public static string GetStatusName<T>()
        {
            return GetPropertyNameByAttribute<T>(typeof(StatusAttribute));
        }
    }
}
