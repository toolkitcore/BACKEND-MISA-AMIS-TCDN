
using Microsoft.AspNetCore.Mvc;
using MISA.WEB08.AMIS.BL;
using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.API.Controllers
{

    /// <summary>
    /// Controller thực thi các thao tác với đối tượng InventoryItem
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class InventoryItemController : BaseController<InventoryItem>
    {
        IInventoryItemBL _inventoryItemBL;

        /// <summary>
        /// Khởi tạo controller
        /// </summary>
        /// Created by: AnhDV (01/11/2022)
        public InventoryItemController(IInventoryItemBL inventoryItemBL) : base(inventoryItemBL)
        {
            _inventoryItemBL = inventoryItemBL;
        }

        /// <summary>
        /// Lấy mã hàng hóa dịch vụ mới
        /// </summary>
        /// <returns>Mã hàng hóa dịch vụ mới</returns>
        /// Created by: AnhDV (06/11/2022)
        [HttpGet("max-code")]
        public IActionResult GetNewInventoryItemCode()
        {
            var newInventoryItemCode = _inventoryItemBL.GetNewInventoryItemCode();
            return HandleReturnResult(newInventoryItemCode);
        }

        /// <summary>
        /// Xóa nhiều hàng hóa
        /// </summary>
        /// <param name="inventoryItemIds">Danh sách id nhân viên cần xóa</param>
        /// <returns>Số bản ghi đã xóa</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        [HttpPost("delete-multiple")]
        public IActionResult DeleteMultiple([FromBody] List<Guid> inventoryItemIds)
        {
            var response = _inventoryItemBL.DeleteMultiple(inventoryItemIds);
            return HandleReturnResult(response);
        }
    }
}
