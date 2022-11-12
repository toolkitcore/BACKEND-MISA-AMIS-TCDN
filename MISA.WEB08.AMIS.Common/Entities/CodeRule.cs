namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Quy tắc đánh số tự động
    /// </summary>
    /// CreatedBy: AnhDV (10/11/2022)
    public class CodeRule : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid RefTypeCategoryID { get; set; }

        /// <summary>
        /// Mã loại tham chiếu
        /// </summary>
        public string RefTypeCategoryCode { get; set; }

        /// <summary>
        /// Tên loại tham chiếu
        /// </summary>
        public string RefTypeCategoryName { get; set; }

        /// <summary>
        /// Tiền tố
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Giá trị bắt đầu
        /// </summary>
        public decimal Value { get; set; }


        /// <summary>
        /// Số lượng ký tự
        /// </summary>
        public decimal LengthOfValue { get; set; }

        /// <summary>
        /// Hậu tố
        /// </summary>
        public string Suffix { get; set; }
    }
}
