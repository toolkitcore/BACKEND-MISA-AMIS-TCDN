using MISA.WEB08.AMIS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Interface thực thi các xử lý nghiệp vụ của nhân viên
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        /// <summary>
        /// Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public string GetNewEmployeeCode();

      
    }
}
