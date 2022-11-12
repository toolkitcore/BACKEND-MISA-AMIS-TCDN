namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Phân trang dữ liệu
    /// <typeparam name="T">Thực thể</typeparam>
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class PagingData<T>
    {
        /// <summary>
        /// Mảng đối tượng thỏa mãn điều kiện lọc và phân trang
        /// </summary>
        public IEnumerable<T>? Data { get; set; }

        /// <summary>
        /// Tóm tắt danh sách dữ liệu
        /// </summary>
        public object? Summary { get; set; }

        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public int? TotalRecord { get; set; }
        /// <summary>
        /// Số bản ghi trên 1 trang
        /// </summary>
        private int? _pageSize;

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        
        private int? _pageNumber;
        /// <summary>
        /// Trang hiện tại 
        /// </summary>
        public int? PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value;
                if (_pageNumber <= 0)
                {
                    _pageNumber = 1;
                }
            }
        }

        /// <summary>
        /// Số bản ghi trên một trang
        /// </summary>
        public int? PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
                if (_pageSize <= 0)
                {
                    _pageSize = 10;
                }
                if (_pageSize > 100)
                {
                    _pageSize = 100;
                }
            }
        }

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
