namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Phân trang dữ liệu
    /// <typeparam name="T">Thực thể</typeparam>
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class PagingData<T> where T : class
    {
        /// <summary>
        /// Mảng đối tượng thỏa mãn điều kiện lọc và phân trang
        /// </summary>
        public IEnumerable<T>? Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public int? TotalRecord { get; set; }

        /// <summary>
        /// Trang hiện tại 
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Số bản ghi trên một trang
        /// </summary>
        public int? PageSize { get; set; }


        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int? TotalPages
        {
            get
            {
                return (TotalRecord / PageSize) + (TotalRecord % PageSize > 0 ? 1 : 0);
            }
        }
    }
}
