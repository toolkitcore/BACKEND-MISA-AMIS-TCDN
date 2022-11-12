using System.Collections;

namespace MISA.WEB08.AMIS.Common.Exceptions
{
    /// <summary>
    /// Lớp response trả về khi có lỗi ngoại khóa
    /// </summary>
    /// CreatedBy: AnhDV (08/11/2022)
    public class ForeignKeyException : MISAException
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="message">Thông báo lỗi</param>
        /// <param name="dataError">Dữ liệu lỗi</param>
        /// CreatedBy: AnhDV (08/11/2022)
        public ForeignKeyException(string message, IDictionary? dataError = null) : base(message, dataError)
        {
        }
    }
}
