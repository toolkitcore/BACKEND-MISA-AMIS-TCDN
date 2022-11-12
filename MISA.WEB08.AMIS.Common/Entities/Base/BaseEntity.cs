using MISA.WEB08.AMIS.Common.Resources;
namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Lớp này khai báo chung cho các class khác kế thừa
    /// Created by: TCDN AnhDV (29/09/2022)
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; } = Resource.DefaultUser;

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; } = Resource.DefaultUser;
    }
}
