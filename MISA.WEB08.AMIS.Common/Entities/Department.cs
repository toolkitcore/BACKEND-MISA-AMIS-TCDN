
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Bảng phòng ban
    /// </summary>
    /// Created by: TCDN AnhDV (16/09/2022)
    public class Department : BaseEntity
    {
        #region Properties
        /// <summary>
        /// ID phòng ban
        /// </summary>
        [PrimaryKey]
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [Required("Mã phòng ban không được để trống")]
        public string? DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [Required("Tên phòng ban không được để trống")]
        public string? DepartmentName { get; set; }
        #endregion

    }
}
