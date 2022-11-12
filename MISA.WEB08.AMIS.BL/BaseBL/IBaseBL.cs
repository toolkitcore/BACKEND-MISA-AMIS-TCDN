using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Entities.DTO;

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

        /// <summary>
        /// Lấy danh sách các bản ghi theo điều kiện
        /// </summary>
        /// <param name="
        /// <returns>Danh sách các bản ghi theo điều kiện</returns>
        /// Created by: TCDN AnhDV (24/10/2022)
        public PagingData<T> GetPagingData(FilterBase filter);

        /// <summary>
        /// Xử lý lấy dữ liệu theo filter
        /// </summary>
        /// <param name="filters">Điều kiện lọc</param>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <returns>Danh sách dữ liệu</returns>
        public PagingData<T> GetPagingDataV2(int pageSize, int pageNumber, string? keyword, List<Filter>? filter);
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

        /// <summary>
        /// Hàm cập nhật status của bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="fieldName">Tên trường</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: Customize (28/10/2022)
        public int UpdateStatus(int value, Guid? id);

        #endregion

        #region DELETE
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="Id">Id của dữ liệu</param>
        /// <returns>Kết quả trả về</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public int Delete(Guid Id);

        /// <summary>
        /// Hàm dùng để xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách id của bản ghi</param>
        /// <returns>Số bản ghi được xóa</returns>
        /// Created by: AnhDV (28/10/2022)
        public int DeleteMultiple(List<Guid> Ids);
        #endregion

        /// <summary>
        /// Xuất file excel 
        /// </summary>
        /// <returns>Stream file excel</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        public Stream ExportExcel(FilterBase filter, bool isExportAll);
    }
}
