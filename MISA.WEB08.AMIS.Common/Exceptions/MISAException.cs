using System.Collections;
using MISA.WEB08.AMIS.Common.Enum;

namespace MISA.WEB08.AMIS.Common.Exceptions
{
    /// <summary>
    /// Lớp exception chung 
    /// </summary>
    public class MISAException : Exception
    {
        /// <summary>
        /// Dữ liệu lỗi
        /// </summary>
        public IDictionary? DataError { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public MISAError? ErrorCode { get; set; }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message">Thông báo lỗi</param>
        /// <param name="dataError">Dữ liệu lỗi</param>
        public MISAException(string message, IDictionary? dataError = null) : base(message)
        {
            DataError = dataError;
        }
    }
}
