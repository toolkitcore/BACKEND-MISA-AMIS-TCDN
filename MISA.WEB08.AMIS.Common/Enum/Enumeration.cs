using System.ComponentModel;
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
    /// Các error code trả về
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public enum MISAError
    {
        /// <summary>
        /// Lỗi Exception
        /// </summary>
        Exception = 500,

        /// <summary>
        /// Lỗi trùng dữ liệu
        /// </summary>
        Duplicate = 6,

        /// <summary>
        /// Lỗi xóa dữ liệu
        /// </summary>
        Delete = 7,

        /// <summary>
        /// Lỗi validate do nghiệp vụ
        /// </summary>
        Validate = 8,


        /// <summary>
        /// Lỗi không tìm thấy dữ liệu
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Lỗi xóa dữ liệu do có nhiều bảng tham chiếu
        /// </summary>
        ForeignKey = 9,

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

        GetPagingV2,

        /// <summary>
        /// Lấy mã code
        /// </summary>
        GetCode,

        /// <summary>
        /// Lấy mã code
        /// </summary>
        Export,
        /// <summary>
        /// Kiểm tra trùng mã
        /// </summary>
        CheckUnique,

        /// <summary>
        /// Update status
        /// </summary>
        UpdateStatus

    }


    /// <summary>
    /// Liệt kê trạng thái
    /// </summary>
    /// Created by: AnhDV (09/11/2022)
    public enum Status
    {
        /// <summary>
        /// Nữ
        /// </summary>
        [Description("Ngừng sử dụng")]
        InActive = 0,

        /// <summary>
        /// Nam
        /// </summary>
        [Description("Đang sử dụng")]
        Active = 1,
    }
    /// <summary>
    /// Liệt kê giảm thuế
    /// </summary>
    /// Created by: AnhDV (09/11/2022)
    public enum TaxReductionType
    {
        /// <summary>
        /// Chưa xác định
        /// </summary>
        [Description("Chưa xác định")]
        NotDetermined = 1,

        /// <summary>
        /// Không giảm thuế
        /// </summary>
        [Description("Không giảm thuế")]
        NotReduction = 2,

        /// <summary>
        /// Giảm thuế
        /// </summary>
        [Description("Có Giảm thuế")]
        Reduction = 3,
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
        [Description("Nữ")]
        Female = 0,

        /// <summary>
        /// Nam
        /// </summary>
        [Description("Nam")]
        Nam = 1,

        /// <summary>
        /// Khác
        /// </summary>
        [Description("Khác")]
        Khác = 2
    }

    /// <summary>
    /// Liệt kê các loại tính chất hàng hóa
    /// </summary>
    /// Created by: AnhDV(07/11/2022)
    public enum InventoryItemType
    {

        /// <summary>
        /// Hàng hóa
        /// </summary>
        [Description("Hàng hóa")]
        Goods = 1,

        /// <summary>
        /// Dịch vụ
        /// </summary>
        [Description("Dịch vụ")]
        Service = 2,


        /// <summary>
        /// Nguyên vật liệu
        /// </summary>
        [Description("Nguyên vật liệu")]
        RawMaterial = 3,


        /// <summary>
        /// Thành phẩm
        /// </summary>
        [Description("Thành phẩm")]
        FinishedProduct = 4,

        /// <summary>
        /// Công cụ dụng cụ
        /// </summary>
        [Description("Công cụ dụng cụ")]
        Tool = 5,
    }
}
