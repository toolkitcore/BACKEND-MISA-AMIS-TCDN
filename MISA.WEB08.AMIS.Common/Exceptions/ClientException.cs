using System.Collections;

namespace MISA.WEB08.AMIS.Common.Exceptions
{
    /// <summary>
    /// Lớp response trả về cho client khi có lỗi xảy ra
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class ClientException : Exception
    {
        /// <summary>
        /// Dữ liệu lỗi
        /// </summary>
        public IDictionary? DataError { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message">Thông báo lỗi</param>
        /// <param name="dataError">Dữ liệu lỗi</param>
        /// CreatedBy: AnhDV (27/09/2022)
        public ClientException(string message, IDictionary? dataError = null) : base(message)
        {
            DataError = dataError;
        }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message">Thông báo lỗi</param>
        /// <param name="errorCode">Mã lỗi</param>
        /// <param name="dataError">Dữ liệu lỗi</param>
        /// CreatedBy: AnhDV (11/10/2022)
        public ClientException(string message, string errorCode, IDictionary? dataError = null) : base(message)
        {
            DataError = dataError;
            ErrorCode = errorCode;
        }
    }
}
