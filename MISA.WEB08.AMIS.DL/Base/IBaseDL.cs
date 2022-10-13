using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Base Interface của tầng Data Access Layer
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public interface IBaseDL<T>
    {
        #region GET
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public IEnumerable<T> GetList();

        /// <summary>
        /// Lấy danh sách dữ liệu export
        /// </summary>
        /// <returns>Danh sách dữ liệu export excel</returns>
        /// Created by: TCDN AnhDV (07/10/2022)
        public IEnumerable<T> GetListExport();

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="Id">Id của dữ liệu</param>
        /// <returns>Dữ liệu</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public T GetEntityById(object Id);
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
        /// <returns>Số bản ghi được xóa</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public int Delete(Guid Id);

        #endregion
    }
}
