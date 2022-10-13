using MISA.WEB08.AMIS.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Kết quả trả về từ tầng BL
    /// </summary>
    public class ServiceResponse
    {
        #region Property

        /// <summary>
        /// Kết quả trả về thành công hay không
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Thông báo trả về
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Mã trả về 
        /// </summary>
        public MISACode MISACode { get; set; } = MISACode.Success;

        /// <summary>
        /// Dữ liệu trả về sau khi thành công hoặc thất bại
        /// </summary>
        public object? Data { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo kết quả trả về
        /// </summary>
        /// <param name="success">Kết quả trả về</param>
        /// <param name="message">Thông báo trả về</param>
        /// <param name="code">Mã trả về</param>
        public ServiceResponse(bool success, string message, MISACode code)
        {
            this.Success = success;
            this.Message = message;
            this.MISACode = code;
        }

        /// <summary>
        /// Khởi tạo kết quả trả về
        /// </summary>
        /// <param name="success">Kết quả trả về</param>
        /// <param name="message">Thông báo trả về</param>
        /// <param name="code">Mã trả về</param>
        /// <param name="data">Dữ liệu trả về</param>
        public ServiceResponse(bool success, string message, MISACode code, object data)
        {
            this.Success = success;
            this.Message = message;
            this.MISACode = code;
            this.Data = data;
        }
        #endregion
    }
}
