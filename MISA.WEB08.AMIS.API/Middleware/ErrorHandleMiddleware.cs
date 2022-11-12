using MISA.WEB08.AMIS.Common.Enum;
using MISA.WEB08.AMIS.Common.Exceptions;
using MISA.WEB08.AMIS.Common.Resources;
using System.Text.Json;

namespace MISA.WEB08.AMIS.API.Middleware
{
    /// <summary>
    /// Middleware xử lý khi có lỗi ngoại lệ xảy ra
    /// </summary>
    /// Created by: TCDN AnhDV (04/10/2022)
    #region ErrorHandleMiddleware
    public class ErrorHandleMiddleware
    {
        #region PROPERTIES
        /// <summary>
        /// Luồng request.
        /// </summary>
        private RequestDelegate _next;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="next">Luồng request</param>
        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Hàm call của middleware
        /// </summary>
        /// <param name="context">Đối tượng HttpContext</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Hàm xử lý khi chương trình có lỗi xảy ra
        /// </summary>
        /// <param name="context">Đối tượng HttpContext</param>
        /// <param name="ex">Lỗi</param>
        /// <returns></returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var misaCode = MISAError.Exception;
            var data = ex.Data;
            var devMsg = ex.Message;
            var userMsg = Resource.ErrorException;
            switch (ex)
            {
                case ValidationException validationEx:
                    var validationExeption = (ValidationException)ex;
                    data = validationExeption.DataError;
                    userMsg = validationExeption.Message;
                    misaCode = (MISAError)validationEx.ErrorCode;
                    break;
                case ClientException:
                    var clientException = (ClientException)ex;
                    data = clientException.DataError;
                    userMsg = clientException.Message;
                    misaCode = MISAError.Exception;
                    break;
                case ForeignKeyException:
                    var foreignKeyException = (ForeignKeyException)ex;
                    data = foreignKeyException.DataError;
                    userMsg = foreignKeyException.Message;
                    misaCode = MISAError.ForeignKey;
                    break;
            }
            var res = new
            {
                Success = false,
                MisaCode = (int)misaCode,
                DevMsg = devMsg,
                UserMsg = userMsg,
                Data = data,
                MoreInfo = "https://api.misa.com.vn/api/error",
                TraceId = context.TraceIdentifier,
            };
            var result = JsonSerializer.Serialize(res); // Chuyển đối tượng thành chuỗi json
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json"; // Trả về kiểu dữ liệu json
            await context.Response.WriteAsync(result); // Trả về kết quả
        }
        #endregion
    }
    #endregion
}
