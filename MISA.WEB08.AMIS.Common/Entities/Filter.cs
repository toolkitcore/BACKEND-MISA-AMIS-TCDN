namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Lớp filter
    /// </summary>
    /// CreatedBy: AnhDV (27/10/2022)
    public class Filter
    {
        /// <summary>
        /// Tên trường
        /// </summary>
        public string? FieldName { get; set; }
        /// <summary>
        /// Giá trị trường
        /// </summary>
        public dynamic? Value { get; set; }
        /// <summary>
        /// Kiểu so sánh
        /// </summary>
        public string? FilterCondition { get; set; }
    }
}
