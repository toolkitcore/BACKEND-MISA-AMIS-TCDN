using Dapper;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Enum;


namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Lớp thực thi các thao tác với database của đối tượng InventoryItem
    /// </summary>
    /// Created by: AnhDV (01/11/2022)
    public class InventoryItemDL : BaseDL<InventoryItem>, IInventoryItemDL
    {
        /// <summary>
        /// Lấy mã hàng hóa dịch vụ mới
        /// </summary>
        /// <returns>Mã hàng hóa dịch vụ mới</returns>
        /// Created by: AnhDV (06/11/2022)
        public string GetNewInventoryItemCode()
        {
            string procedureName = DatabaseUtility.GeneateStoreName<InventoryItem>(ProcdureTypeName.GetMaxCode);
            using (var connection = GetConnection())
            {
                // Thực hiện lấy dữ liệu
                var result = connection.QueryFirstOrDefault<string>(procedureName, commandType: System.Data.CommandType.StoredProcedure);
                // Trả về kết quả
                return result;
            }
        }

        /// <summary>
        /// Xử lý lấy dữ liệu theo filter v2
        /// </summary>
        /// <param name="filters">Điều kiện lọc</param>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <returns>Danh sách dữ liệu</returns>
        public override PagingData<InventoryItem> GetPagingDataV2(int pageSize, int pageNumber, string? keyword, string filters)
        {
            string procedureName = DatabaseUtility.GeneateStoreName<InventoryItem>(ProcdureTypeName.GetPagingV2);
            using (var connection = GetConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("v_Offset", (pageNumber - 1) * pageSize);
                dynamicParameters.Add("v_Limit", pageSize);
                dynamicParameters.Add("v_Where", filters);
                dynamicParameters.Add("v_KeyWord", keyword);
                var data = connection.QueryMultiple(procedureName, param: dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var listData = data.Read<InventoryItem>().ToList();
                var summary = data.Read<InventoryItemSummary>().FirstOrDefault();
                var result = new PagingData<InventoryItem>()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Data = listData,
                    TotalRecord = ((InventoryItemSummary)summary).TotalCount,
                    Summary = summary,
                };
                return result;
            }
        }

    }
}
