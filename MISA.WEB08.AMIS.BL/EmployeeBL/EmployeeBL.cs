using System.Collections;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Exceptions;
using MISA.WEB08.AMIS.Common.Resources;
using MISA.WEB08.AMIS.DL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using static MISA.WEB08.AMIS.Common.AmisAttribute;
using System.Drawing;
using System;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Lớp thực thi các xử lý nghiệp vụ của nhân viên
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Fields

        private IEmployeeDL _employeeDL;

        #endregion

        #region Constructor
        public EmployeeBL(IEmployeeDL baseDL) : base(baseDL)
        {
            _employeeDL = baseDL;
        }
        #endregion


        #region Method

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public string GetNewEmployeeCode()
        {
            return string.Format(EmployeeResource.EmployeeCodeFormat, _employeeDL.GetNewEmployeeCode());
        }

        /// <summary>
        /// Validate nếu mã nhân viên đã tồn tại 
        /// </summary>
        /// <param name="employee">Nhân viên cần validate</param>
        /// <param name="isInsert">Kiểm tra là validate custom khi thêm mới hay cập nhật</param>
        /// <param name="Id">Id của nhân viên cần cập nhật</param>
        /// CreatedBy: AnhDV (27/09/2022)
        protected override void ValidateCustom(Employee employee, bool isInsert = true, Guid? Id = null)
        {
            bool isExistEmployeeCode;
            if (isInsert)
            {
                isExistEmployeeCode = _employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode.Trim());
            }
            else
            {
                isExistEmployeeCode = _employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode.Trim(), employee.EmployeeID ?? Id);
            }
            if (isExistEmployeeCode)
            {
                IDictionary errorList = new Dictionary<string, string>(){
                    { "EmployeeCode", String.Format(ValidationResource.MsgErrorEmployeeDuplicate, employee.EmployeeCode) }
                };
                throw new ValidationException(Resource.UserMsg_Insert_Duplicate, errorList);
            }
        }


        #endregion

      
    }
}
