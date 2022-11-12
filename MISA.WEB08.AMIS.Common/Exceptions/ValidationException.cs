using MISA.WEB08.AMIS.Common.Enum;
using System.Collections;

namespace MISA.WEB08.AMIS.Common.Exceptions
{
    /// <summary>
    /// Lớp response trả về cho client khi có lỗi validation xảy ra
    /// </summary>
    /// CreatedBy: AnhDV (11/10/2022)
    public class ValidationException : ClientException
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message">Thông báo lỗi</param>
        /// <param name="dataError">Dữ liệu lỗi</param>
        /// CreatedBy: AnhDV (11/10/2022)
        public ValidationException(string message, IDictionary? dataError = null) : base(message, dataError)
        {
        }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message">Thông báo lỗi</param>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="dataError">Dữ liệu lỗi</param>
        /// CreatedBy: AnhDV (11/10/2022)
        public ValidationException(string message, MISAError errorCode, IDictionary? dataError = null) : base(message, errorCode, dataError)
        {
        }
    }
}
