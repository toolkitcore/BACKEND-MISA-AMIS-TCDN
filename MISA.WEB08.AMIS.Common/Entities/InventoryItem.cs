using MISA.WEB08.AMIS.Common.Enum;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.Common.Entities
{
    /// <summary>
    /// Thông tin hàng hóa dịch vụ 
    /// </summary>
    /// CreatedBy: AnhDV (02/11/2022)
    [ExcelFileName("hang_hoa_dich_vu")]
    [ExcelSheetName("Hàng hóa dịch vụ")]
    public class InventoryItem : BaseEntity
    {
        /// <summary>
        /// Id hàng hóa dịch vụ
        /// </summary>
        [PrimaryKey]
        public Guid? InventoryItemID { get; set; }

        /// <summary>
        /// Mã hàng hóa dịch vụ
        /// </summary>
        [Filter("InventoryItem.")]
        [Unique]
        [ExcelColumnName("Mã hàng hóa dịch vụ")]
        [Required("Mã vật tư hàng hóa không được để trống")]
        public string? InventoryItemCode { get; set; }

        /// <summary>
        /// Tên hàng hóa dịch vụ
        /// </summary>
        [Filter("InventoryItem.")]
        [ExcelColumnName("Tên hàng hóa dịch vụ")]
        [Required("Tên vật tư hàng hóa không được để trống")]
        public string? InventoryItemName { get; set; }

        /// <summary>
        /// Loại giảm thuế
        /// </summary>
        [ExcelColumnName("Loại giảm thuế")]
        [Filter("InventoryItem.")]
        public TaxReductionType? TaxReductionType { get; set; }

        /// <summary>
        /// Loại hàng hóa dịch vụ
        /// </summary>
        [ExcelColumnName("Loại hàng hóa dịch vụ")]
        [Filter("InventoryItem.")]
        public InventoryItemType? InventoryItemType { get; set; }

        /// <summary>
        /// Tên nhóm hàng hóa dịch vụ
        /// </summary>
        [ExcelColumnName("Tên nhóm hàng hóa dịch vụ")]
        [Filter("InventoryItem.")]
        public string? InventoryGroupName { get; set; }

        /// <summary>
        /// Mã nhóm hàng hóa dịch vụ
        /// </summary>
        [Filter("InventoryItem.")]
        public string? InventoryGroupID { get; set; }

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        public Guid? UnitId { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        [ExcelColumnName("Tên đơn vị tính")]
        [Filter("Unit.")]
        public string? UnitName { get; set; }

        /// <summary>
        /// Thời gian bảo hành
        /// </summary>
        [ExcelColumnName("Thời gian bảo hành")]
        [Filter("InventoryItem.")]
        public string? GuarantyPeriod { get; set; }

        /// <summary>
        /// Số lượng tồn kho tối thiểu
        /// </summary>
        [ExcelColumnName("Số lượng tồn kho tối thiểu")]
        [Filter("InventoryItem.")]
        public decimal? MinimumStock { get; set; }

        /// <summary>
        /// Số lượng tồn 
        /// </summary>
        [ExcelColumnName("Số lượng tồn")]
        [Filter("InventoryItem.")]
        public decimal? ClosingQuantity { get; set; }

        /// <summary>
        /// Giá trị tồn kho
        /// </summary>
        [ExcelColumnName("Giá trị tồn")]
        [Filter("InventoryItem.")]
        public decimal? ClosingAmount { get; set; }

        /// <summary>
        /// Nguồn hàng hóa dịch vụ
        /// </summary>
        [ExcelColumnName("Nguồn hàng hóa dịch vụ")]
        [Filter("InventoryItem.")]
        public string? InventoryItemSource { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [Filter("InventoryItem.")]
        public string? Description { get; set; }

        /// <summary>
        /// Mô tả mua hàng
        /// </summary>
        [Filter("InventoryItem.")]
        public string? PurchaseDescription { get; set; }

        /// <summary>
        /// Mô tả bán hàng
        /// </summary>
        [Filter("InventoryItem.")]
        public string? SaleDescription { get; set; }
        /// <summary>
        /// ID kho 
        public Guid? StockID { get; set; }

        /// <summary>
        /// Tên kho
        /// </summary>
        [ExcelColumnName("Tên kho")]
        [Filter("Stock.")]
        public string? StockName { get; set; }

        /// <summary>
        /// Tài khoản kho
        /// </summary>
        [ExcelColumnName("Tài khoản kho")]
        [Filter("InventoryItem.")]
        public string? InventoryAccount { get; set; }

        /// <summary>
        /// Tài khoản bán hàng
        /// </summary>
        [ExcelColumnName("Tài khoản bán hàng")]
        [Filter("InventoryItem.")]
        public string? SaleAccount { get; set; }
        /// <summary>
        /// Tài khoản chiết khấu
        /// </summary>
        [ExcelColumnName("Tài khoản chiết khấu")]
        [Filter("InventoryItem.")]
        public string? DiscountAccount { get; set; }

        /// <summary>
        /// Tài khoản khuyến mãi
        /// </summary>
        [ExcelColumnName("Tài khoản khuyến mãi")]
        [Filter("InventoryItem.")]
        public string? SaleOffAccount { get; set; }

        /// <summary>
        /// Tài khoản trả hàng
        /// </summary>
        [ExcelColumnName("Tài khoản trả hàng")]
        [Filter("InventoryItem.")]
        public string? ReturnAccount { get; set; }

        /// <summary>
        /// Tài khoản chi phí
        /// </summary>
        [ExcelColumnName("Tài khoản chi phí")]
        [Filter("InventoryItem.")]
        public string? CostAccount { get; set; }
        /// <summary>
        /// Tỷ lệ chiết khấu mua hàng
        /// </summary>
        [ExcelColumnName("Tỷ lệ chiết khấu mua hàng")]
        [Filter("InventoryItem.")]
        public decimal? PurchaseDiscountRate { get; set; }

        /// <summary>
        /// Đơn giá cố định
        /// </summary>
        [ExcelColumnName("Đơn giá mua cố định")]
        [Filter("InventoryItem.")]
        public decimal? FixedUnitPrice { get; set; }    // Đơn giá cố định

        /// <summary>
        /// Đơn giá 
        /// </summary>
        [ExcelColumnName("Đơn giá mua gần nhất")]
        [Filter("InventoryItem.")]
        public decimal? UnitPrice { get; set; } // Đơn giá
        /// <summary>
        /// Giá bán
        /// </summary>
        [ExcelColumnName("Đơn giá bán")]
        [Filter("InventoryItem.")]
        public decimal? SalePrice { get; set; } // Giá bán

        /// <summary>
        /// Thuế suất
        /// </summary>
        [ExcelColumnName("Thuế suất")]
        [Filter("InventoryItem.")]
        public string? TaxRate { get; set; } // Thuế suất

        /// <summary>
        /// Thuế suất nhập khẩu
        /// </summary>
        [ExcelColumnName("Thuế suất nhập khẩu")]
        [Filter("InventoryItem.")]
        public decimal? ImportTaxRate { get; set; } // Thuế suất nhập khẩu

        /// <summary>
        /// Thuế suất xuất khẩu
        /// </summary>
        [ExcelColumnName("Thuế suất xuất khẩu")]
        [Filter("InventoryItem.")]
        public decimal? ExportTaxRate { get; set; } // Thuế suất xuất khẩu

        /// <summary>
        /// Tên loại hàng hóa dịch vụ chịu thuế đặc biệt
        /// </summary>
        [ExcelColumnName("Tên loại hàng hóa dịch vụ chịu thuế đặc biệt")]
        [Filter("InventoryItem.")]
        public string? InventoryCategorySpecialTaxName { get; set; } // Tên loại hàng hóa dịch vụ chịu thuế đặc biệt

        /// <summary>
        /// Trạng thái
        /// </summary>
        [ExcelColumnName("Trạng thái")]
        [Status]
        [Filter("InventoryItem.")]
        public Status Status { get; set; }
    }
}
