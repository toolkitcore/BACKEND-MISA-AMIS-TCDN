using MISA.WEB08.AMIS.Common.Enum;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Bảng nhân viên
    /// </summary>
    /// Created by: TCDN AnhDV (16/09/2022)
    public class Employee : BaseEntity
    {
        #region Properties
        /// <summary>
        /// ID nhân viên
        /// </summary>
        [PrimaryKey]
     
        public Guid? EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required("Mã nhân viên không được để trống")]
        [RegularExpressions(regex: "^NV-[0-9]{1,}$", ErrorMessage = "Mã nhân viên không đúng định dạng NV-XXX")]
        [ExcelColumnName("Mã nhân viên")]
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required("Tên nhân viên không được để trống")]
        [ExcelColumnName("Tên nhân viên")]
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        [ExcelColumnName("Giới tính")]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        [ExcelColumnName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        
        public string? EmployeeAddress { get; set; }

        /// <summary>
        /// ID phòng ban
        /// </summary>
      
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        [ExcelColumnName("Chức danh")]
        public string? JobTitle { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [ExcelColumnName("Tên đơn vị")]
        public string? DepartmentName { get; set; }


        /// <summary>
        /// Số CMND
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string? TelephoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        [ExcelColumnName("Số tài khoản")]
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [ExcelColumnName("Tên ngân hàng")]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankBranch { get; set; }

        /// <summary>
        /// Là Khách hàng
        /// </summary>
        public bool? IsCustomer { get; set; }

        /// <summary>
        /// Là nhà cung cấp
        /// </summary>
        public bool? IsSupplier { get; set; }
        #endregion

    }
}

