using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB08.AMIS.Common.Enum
{
    /// <summary>
    /// Các status code trả về
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public enum MISACode
    {
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Thất bại
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Lỗi validate dữ liệu chung
        /// </summary>
        Validate = 400,

        /// <summary>
        /// Lỗi validate dữ liệu không hợp lệ
        /// </summary>
        ValidateEntity = 401,

        /// <summary>
        /// Lỗi validate dữ liệu do không đúng nghiệp vụ
        /// </summary>
        ValidateBussiness = 402,

        /// <summary>
        /// Lỗi Exception
        /// </summary>
        Exception = 500,

        /// <summary>
        /// Lỗi không tìm thấy dữ liệu
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Lỗi trùng dữ liệu
        /// </summary>
        Duplicate = 409,

    }
    /// <summary>
    /// Tên kiểu store sẽ thực thi
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public enum ProcdureTypeName
    {
        /// <summary>
        ///  Lấy dữ liệu
        /// </summary>
        GetAll,

        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        GetByID,

        /// <summary>
        /// Lấy Mã code lớn nhất
        /// </summary>
        GetMaxCode,

        /// <summary>
        /// Thêm mới
        /// </summary>
        Insert,

        /// <summary>
        /// Sửa/ cập nhật dữ liệu
        /// </summary>
        Update,

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        Delete,

        /// <summary>
        /// Xóa nhiều dữ liệu
        /// </summary>
        DeleteMultiple,

        /// <summary>
        /// Lấy dữ liệu có phân trang
        /// </summary>
        GetPaging,

        /// <summary>
        /// Lấy mã code
        /// </summary>
        GetCode,

        /// <summary>
        /// Lấy mã code
        /// </summary>
        Export,

    }
    /// <summary>
    /// Liệt kê các giới tính
    /// </summary>
    /// Created by: TCDN AnhDV (16/09/2022)
    public enum Gender
    {
        /// <summary>
        /// Nữ
        /// </summary>
        Nữ = 0,

        /// <summary>
        /// Nam
        /// </summary>
        Nam = 1,

        /// <summary>
        /// Khác
        /// </summary>
        Khác = 2
    }
}
