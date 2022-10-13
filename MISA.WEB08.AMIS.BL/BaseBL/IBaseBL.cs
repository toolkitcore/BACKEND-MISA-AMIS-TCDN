using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Interface thực thi các xử lý nghiệp vụ của tầng BL
    /// </summary>
    /// <typeparam name="T">Kiểu dữ liệu</typeparam>
    /// CreatedBy: AnhDV (27/09/2022)
    public interface IBaseBL<T>
    {
        #region GET
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public IEnumerable<T> GetList();

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="Id">Id của dữ liệu</param>
        /// <returns>Dữ liệu</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public T GetEntityById(Guid Id);
        #endregion

        #region INSERT
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu</param>
        /// <returns>ID của dữ liệu</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public Guid Insert(T entity);
        #endregion

        #region UPDATE
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="Id">Id của dữ liệu cần cập nhật</param>
        /// <param name="entity">Dữ liệu cần cập nhật</param>
        /// <returns>Số bản ghi được sửa</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public int Update(Guid Id, T entity);
        #endregion

        #region DELETE
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="Id">Id của dữ liệu</param>
        /// <returns>Kết quả trả về từ ServiceResponse</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public int Delete(Guid Id);

        #endregion
    }
}
