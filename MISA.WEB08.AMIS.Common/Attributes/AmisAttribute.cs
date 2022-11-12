using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MISA.WEB08.AMIS.Common
{
    /// <summary>
    /// Khai báo các Custom Attribute cho các property
    /// </summary>
    /// Created by: TCDN AnhDV (23/09/2022)
    public class AmisAttribute
    {

        /// <summary>
        /// Attribute dùng để kiểm tra format của các property theo định dạng custom
        /// Ex: Kiểm tra mã nhân viên có đúng định dạng NV-123 : NV-[0-9]{1,}
        /// </summary>
        /// Created by: TCDN AnhDV (23/09/2022)
        [AttributeUsage(AttributeTargets.Property)]
        public class RegularExpressionsAttribute : ValidationAttribute
        {
            /// <summary>
            /// Định dạng regex
            /// </summary>
            private string _regex;

            /// <summary>
            /// Hàm khởi tạo
            /// </summary>
            /// <param name="regex">Định dạng cần kiểm tra</param>
            /// Created by: TCDN AnhDV (23/09/2022)
            public RegularExpressionsAttribute(string regex)
            {
                _regex = regex;
            }

            /// <summary>
            /// Hàm kiểm tra định dạng
            /// </summary>
            /// <param name="value">Giá trị cần kiểm tra</param>
            /// <returns>True: đúng định dạng, False: sai định dạng</returns>
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return false;
                }
                return Regex.IsMatch(value.ToString(), _regex);
            }

        }

        /// <summary>
        /// Attribute dùng để kiểm tra các property có bắt buộc nhập hay không
        /// </summary>
        /// Created by: TCDN AnhDV (23/09/2022)
        [AttributeUsage(AttributeTargets.Property)]
        public class RequiredAttribute : ValidationAttribute
        {
            /// <summary>
            /// Tên file resource
            /// </summary>
            public string ResourceName { get; set; }

            /// <summary>
            /// Type của file resource
            /// </summary>
            public Type? ResourceType { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="errorMessage">Thông báo lỗi</param>
            /// Created by: TCDN AnhDV (23/09/2022)
            public RequiredAttribute(string errorMessage) : base(errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            /// <summary>
            /// Hàm kiểm tra giá trị có bị null hay không
            /// </summary>
            /// <param name="value">Giá trị cần kiểm tra</param>
            /// <returns>True: bắt buộc nhập, False: không bắt buộc nhập</returns>
            public override bool IsValid(object value)
            {
                if ((value == null) || string.IsNullOrEmpty(value.ToString()))
                {
                    return false;
                }
                return true;
            }

        }

        /// <summary>
        /// Attribute khóa chính
        /// </summary>
        /// Created by: TCDN AnhDV (23/09/2022)
        [AttributeUsage(AttributeTargets.Property)]
        public class PrimaryKeyAttribute : Attribute
        {

        }
        /// <summary>
        /// Attribute Unique
        /// </summary>
        /// Created by: TCDN AnhDV (23/09/2022)
        [AttributeUsage(AttributeTargets.Property)]
        public class UniqueAttribute : Attribute
        {

            public string ErrorMessage { get; set; }
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="errorMessage">Thông báo lỗi</param>
            /// Created by: TCDN AnhDV (23/09/2022)
            public UniqueAttribute(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
            public UniqueAttribute()
            {
            }
        }
        /// <summary>
        /// Attribute tạo tên cột phục vụ cho việc Export Excel
        /// </summary> 
        /// Created by: TCDN AnhDV (05/10/2022)
        [AttributeUsage(AttributeTargets.Property)]
        public class ExcelColumnNameAttribute : Attribute
        {
            /// <summary>
            /// Tên cột
            /// </summary>
            public string ColumnName { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="columnName">Tên cột</param>
            /// Created by: TCDN AnhDV (05/10/2022)
            public ExcelColumnNameAttribute(string columnName)
            {
                ColumnName = columnName;
            }
        }

        /// <summary>
        /// Attribute tạo tên file phục vụ cho việc Export Excel
        /// </summary>
        /// Created by: TCDN AnhDV (05/10/2022)
        [AttributeUsage(AttributeTargets.Class)]
        public class ExcelFileNameAttribute : Attribute
        {
            /// <summary>
            /// Tên file
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="fileName">Tên file</param>
            /// Created by: TCDN AnhDV (05/10/2022)
            public ExcelFileNameAttribute(string fileName)
            {
                FileName = fileName;
            }
        }

        /// <summary>
        /// Attribute tạo tên sheet phục vụ cho việc Export Excel
        /// </summary>
        /// Created by: TCDN AnhDV (05/10/2022)
        [AttributeUsage(AttributeTargets.Class)]
        public class ExcelSheetNameAttribute : Attribute
        {
            /// <summary>
            /// Tên sheet
            /// </summary>
            public string SheetName { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="sheetName">Tên sheet</param>
            /// Created by: TCDN AnhDV (05/10/2022)
            public ExcelSheetNameAttribute(string sheetName)
            {
                SheetName = sheetName;
            }
        }

        /// <summary>
        /// Attribute filter dữ liệu
        /// </summary>
        /// Created by: TCDN AnhDV (05/10/2022)
        [AttributeUsage(AttributeTargets.Property)]
        public class FilterAttribute : Attribute
        {

            /// <summary>
            /// Tiền tố
            /// </summary>
            public string Prefix { get; set; }

            /// <summary>
            /// Hậu tố
            /// </summary>
            public string Suffix { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="filterOption">Loại filter</param>
            /// <param name="prefix">Tiền tố</param>
            /// <param name="suffix">Hậu tố</param>
            /// Created by: Customize AnhDV (11/10/2022)
            public FilterAttribute(string prefix = "", string suffix = "")
            {
                Prefix = prefix;
                Suffix = suffix;
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="FilterOption">Loại filter</param>
            /// <param name="prefix">Tiền tố</param>
            /// Created by: TCDN AnhDV (05/10/2022)
            public FilterAttribute(string prefix) : this(prefix, "")
            {
                Prefix = prefix;
            }
        }

        /// <summary>
        /// Attribute tạo cột trạng thái
        /// </summary>
        /// Created by: TCDN AnhDV (05/10/2022)
        [AttributeUsage(AttributeTargets.Property)]
        public class StatusAttribute : Attribute
        {
        }
    }
}
