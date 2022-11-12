using System.Collections;
using System.Drawing;
using System.Reflection;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Entities.DTO;
using MISA.WEB08.AMIS.Common.Enum;
using MISA.WEB08.AMIS.Common.Exceptions;
using MISA.WEB08.AMIS.Common.Resources;
using MISA.WEB08.AMIS.Common.Utilities;
using MISA.WEB08.AMIS.DL;
using MySqlConnector;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using static MISA.WEB08.AMIS.Common.AmisAttribute;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Lớp thực thi các xử lý nghiệp vụ tầng BL 
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        /// <summary>
        /// Khởi tạo đối tượng BaseDL
        /// </summary>
        private IBaseDL<T> _baseDL;

        #endregion

        #region Contructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseDL">Đối tượng thực thi các xử lý nghiệp vụ tầng DL</param>
        /// CreatedBy: AnhDV (27/09/2022)
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion

        #region METHOD

        #region INSERT
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu cần thêm mới</param>
        /// <returns>Kết quả trả về</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public Guid Insert(T entity)
        {
            Validate(entity);
            ValidateCustom(entity);
            return _baseDL.Insert(entity);
        }

        #endregion

        #region DELETE


        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="Id">Id của dữ liệu</param>
        /// <returns>Tổng số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public int Delete(Guid Id)
        {
            try
            {
                return _baseDL.Delete(Id);
            }
            catch (MySqlException ex)
            {
                // bắt lỗi foreign key
                if (ex.Number == 1451)
                {
                    throw new ForeignKeyException(Resource.MsgError_ForeignKey);
                }
            }
            return 0;
        }

        /// <summary>
        /// Hàm dùng để xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách id của bản ghi</param>
        /// <returns>Số bản ghi được xóa</returns>
        /// Created by: AnhDV (28/10/2022)
        public int DeleteMultiple(List<Guid> Ids)
        {
            return _baseDL.DeleteMultiple(Ids);
        }
        #endregion

        #region GET
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="Id">Id của dữ liệu cần lấy</param>
        /// <returns>Dữ liệu của đối tượng ứng với Id</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public T GetEntityById(Guid Id)
        {
            return _baseDL.GetEntityById(Id);
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu của đối tượng</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public IEnumerable<T> GetList()
        {
            return _baseDL.GetList();
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="Id">Id của dữ liệu cần cập nhật</param>
        /// <param name="entity">Dữ liệu cần cập nhật</param>
        /// <returns>Tổng số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public int Update(Guid Id, T entity)
        {
            Validate(entity);
            ValidateCustom(entity, false, Id);
            return _baseDL.Update(Id, entity);
        }
        #endregion 

        #endregion

        #region BASE_METHOD

        /// <summary>
        /// Validate dữ liệu truyền lên từ client
        /// </summary>
        /// <param name="entity">Dữ liệu cần validate</param>
        /// <returns>Kết quả trả về từ ServiceResponse</returns>
        protected void Validate(T entity)
        {
            var properties = typeof(T).GetProperties(); // Lấy tất cả các thuộc tính của đối tượng
            IDictionary errorList = new Dictionary<string, List<string>>(); // Khởi tạo danh sách lỗi

            foreach (var property in properties)
            {
                List<string> errorMessages = new List<string>(); // Khởi tạo danh sách lỗi của từng thuộc tính

                var propertyAttributes = property.GetCustomAttributes(true); // Lấy tất cả các attribute của property

                var propertyValue = property.GetValue(entity); // Lấy giá trị của property

                foreach (var propertyAttribute in propertyAttributes)
                {
                    switch (propertyAttribute)
                    {
                        case RequiredAttribute requiredAttribute: // Kiểm tra attribute có phải là RequiredAttribute
                            if (!requiredAttribute.IsValid(propertyValue))
                            {
                                var message = ((RequiredAttribute)propertyAttribute).ErrorMessage; // Lấy thông báo lỗi
                                // errorList.Add(property.Name, message); // Thêm thông báo lỗi vào danh sách lỗi
                                errorMessages.Add(message);
                            }
                            break;
                        case RegularExpressionsAttribute regularExpressionsAttribute:
                            if (!regularExpressionsAttribute.IsValid(propertyValue))
                            {
                                var message = ((RegularExpressionsAttribute)propertyAttribute).ErrorMessage; // Lấy thông báo lỗi
                                // errorList.Add(property.Name, message); // Thêm thông báo lỗi vào danh sách lỗi
                                errorMessages.Add(message);
                            }
                            break;
                    }
                }
                if (errorMessages.Count > 0)
                { // Nếu có lỗi thì thêm vào danh sách lỗi
                    errorList.Add(property.Name, errorMessages);
                }
            }
            if (errorList.Count > 0)
            {
                throw new ValidationException(ValidationResource.UserMsg_Validate_Failed, MISAError.Validate, errorList);
            }
        }

        /// <summary>
        /// Phương thức dùng để custom validate dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu cần validate</param>
        /// <param name="isInsert">Kiểm tra là thêm mới hay cập nhật</param>
        /// <param name="Id">Id của dữ liệu cần cập nhật</param>
        /// CreatedBy: AnhDV (04/10/2022)
        protected virtual void ValidateCustom(T entity, bool isInsert = true, Guid? Id = null)
        {
            var listUniqueName = CommonUtility.GetPropertiesByAttribute<T>(typeof(UniqueAttribute));
            foreach (var propertyName in listUniqueName)
            {
                var propertyValue = typeof(T).GetProperty(propertyName).GetValue(entity);
                if (isInsert)
                {
                    if (!_baseDL.CheckUnique(propertyName, propertyValue, null))
                    {
                        throw new ValidationException(ValidationResource.MsgError_Duplicate, MISAError.Duplicate, null);
                    }
                }
                else
                {
                    if (!_baseDL.CheckUnique(propertyName, propertyValue, Id))
                    {
                        throw new ValidationException(ValidationResource.MsgError_Duplicate, MISAError.Duplicate, null);
                    }
                }
            }
            // TODO: Ghi đè phương thức này để custom validate dữ liệu
        }

        /// <summary>
        /// Hàm cập nhật status của bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <param name="fieldName">Tên trường</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: Customize (28/10/2022)
        public int UpdateStatus(int value, Guid? id)
        {
            var statusName = CommonUtility.GetStatusName<T>();
            // nếu value nằm ngoài 0 và 1 thì trả về lỗi
            if (value != 0 && value != 1)
            {
                throw new ValidationException(Resource.MsgError_InvalidStatus, MISAError.Validate, null);
            }
            return _baseDL.UpdateStatus(statusName, value, id);
        }

        /// <summary>
        /// Xử lý lấy dữ liệu theo filter
        /// </summary>
        /// <param name="filter">Filter dữ liệu</param>
        /// <returns>Danh sách dữ liệu</returns>
        public PagingData<T> GetPagingData(FilterBase filter)
        {
            return _baseDL.GetPagingData(filter);
        }

        /// <summary>
        /// Xử lý lấy dữ liệu theo filter v2
        /// </summary>
        /// <param name="filters">Điều kiện lọc</param>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <returns>Danh sách dữ liệu</returns>
        public PagingData<T> GetPagingDataV2(int pageSize, int pageNumber, string? keyword, List<Filter>? filter)
        {
            string filterStr = "";
            var properties = typeof(T).GetProperties(); // Lấy tất cả các thuộc tính của đối tượng
            if (filter != null)
            {
                // Duyệt qua các property của đối tượng kiểm tra xem có attribute là Filter hay không
                foreach (var property in properties)
                {
                    // kiểm tra xem column có được filter hay không
                    bool isFilter = Attribute.IsDefined(property, typeof(FilterAttribute));
                    if (isFilter)
                    {
                        foreach (var filterValue in filter)
                        {
                            if (filterValue.FieldName.ToLower().Trim() == property.Name.ToLower().Trim())
                            {
                                var filterAttribute = Attribute.GetCustomAttribute(property, typeof(FilterAttribute)) as FilterAttribute;

                                string prefix = filterAttribute.Prefix;

                                switch (filterValue.FilterCondition)
                                {
                                    case "Equal":
                                        filterStr += $" AND {prefix}{property.Name} = '{filterValue.Value}'";
                                        break;
                                    case "NotEqual":
                                        filterStr += $" AND {prefix}{property.Name} != '{filterValue.Value}'";
                                        break;
                                    case "Contain":
                                        filterStr += $" AND {prefix}{property.Name} LIKE '%{filterValue.Value}%'";
                                        break;
                                    case "NotContain":
                                        filterStr += $" AND {prefix}{property.Name} NOT LIKE '%{filterValue.Value}%'";
                                        break;
                                    case "StartWith":
                                        filterStr += $" AND {prefix}{property.Name} LIKE '{filterValue.Value}%'";
                                        break;
                                    case "EndWith":
                                        filterStr += $" AND {prefix}{property.Name} LIKE '%{filterValue.Value}'";
                                        break;
                                    case "IsNull":
                                        filterStr += $" AND {prefix}{property.Name} IS NULL OR {prefix}{property.Name} = ''";
                                        break;
                                    case "IsNotNull":
                                        filterStr += $" AND {prefix}{property.Name} IS NOT NULL AND {prefix}{property.Name} != ''";
                                        break;
                                    case "GreaterThan":
                                        filterStr += $" AND {prefix}{property.Name} > {filterValue.Value}";
                                        break;
                                    case "GreaterThanOrEqual":
                                        filterStr += $" AND {prefix}{property.Name} >= {filterValue.Value}";
                                        break;
                                    case "LessThan":
                                        filterStr += $" AND {prefix}{property.Name} < {filterValue.Value}";
                                        break;
                                    case "LessThanOrEqual":
                                        filterStr += $" AND {prefix}{property.Name} <= {filterValue.Value}";
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            return _baseDL.GetPagingDataV2(pageSize, pageNumber, keyword, filterStr);
        }

        /// <summary>
        /// Xuất file excel danh sách nhân viên
        /// </summary>
        /// <param name="isExportAll">Xuất tất cả hay không</param>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>Đối tượng Stream chứa file excel</returns>
        /// CreatedBy: AnhDV (05/10/2022)
        public Stream ExportExcel(FilterBase filter, bool isExportAll = true)
        {
            var listData = isExportAll ? _baseDL.GetListExport() : GetPagingDataV2(filter.PageSize, filter.PageNumber, filter.Keyword, filter.Filter).Data;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var stream = new MemoryStream();
            var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add($"Danh sách {CommonUtility.GetExcelSheetName<T>()}");
            package.Workbook.Properties.Author = Resource.DefaultUser;
            package.Workbook.Properties.Title = $"Danh sách {CommonUtility.GetExcelSheetName<T>()}";
            BindingFormatForExcel(workSheet, listData); // Binding format cho file excel
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
            package.Save();
            stream.Position = 0; // Đặt con trỏ về đầu file để đọc
            return package.Stream;
        }

        /// <summary>
        /// Binding format style cho file excel
        /// </summary>
        /// <param name="workSheet">Sheet cần binding format</param>
        /// <param name="listData">Danh sách dữ liệu</param>
        /// CreatedBy: AnhDV (05/10/2022)
        private void BindingFormatForExcel(ExcelWorksheet workSheet, IEnumerable<T> listData)
        {
            // Lấy ra các property có attribute name là ExcelColumnNameAttribute 
            var excelColumnProperties = typeof(T).GetProperties().Where(p => p.GetCustomAttributes(typeof(ExcelColumnNameAttribute), true).Length > 0);

            var lastColumn = excelColumnProperties.Count() + 1; // Lấy ra số cột của file excel

            // Tạo phần tiêu đề cho file excel
            using (var range = workSheet.Cells[1, 1, 1, lastColumn])
            { // Tạo range từ ô A1 đến ô cuối cùng của tiêu đề
                range.Merge = true;
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 16;
                range.Style.Font.Name = "Arial";
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Value = $"Danh sách {CommonUtility.GetExcelSheetName<T>()}";
            }
            // Gộp các ô từ A2 đến ô cuối cùng của dòng 2
            workSheet.Cells[2, 1, 2, lastColumn].Merge = true;

            // Style chung cho tất cả bảng
            using (var range = workSheet.Cells[3, 1, listData.Count() + 3, lastColumn])
            { // Tạo range từ ô A3 đến ô cuối cùng của dữ liệu
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Style.Font.Name = "Times New Roman";
                range.Style.Font.Size = 11;
            }

            // Lấy ra các property có attribute name là ExcelColumnNameAttribute và đổ vào header của table
            int columnIndex = 1;
            workSheet.Cells[3, columnIndex].Value = ExportResource.Export_Excel_No;
            columnIndex++;
            foreach (var property in excelColumnProperties)
            {
                var excelColumnName = (property.GetCustomAttributes(typeof(ExcelColumnNameAttribute), true)[0] as ExcelColumnNameAttribute).ColumnName;
                workSheet.Cells[3, columnIndex].Value = excelColumnName;
                columnIndex++;
            }
            // Style cho header của table
            using (var range = workSheet.Cells[3, 1, 3, lastColumn])
            { // Tạo range từ ô A3 đến ô cuối cùng của header
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 10;
                range.Style.Font.Name = "Arial";
                range.Style.Font.Color.SetColor(Color.Black);
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }

            // Đổ dữ liệu từ list nhân viên vào các côt tương ứng
            int rowIndex = 4;
            int stt = 1; // Số thứ tự
            foreach (var entity in listData)
            {
                columnIndex = 1;
                workSheet.Cells[rowIndex, columnIndex].Value = stt;
                columnIndex++;
                foreach (var property in excelColumnProperties)
                {
                    // Lấy ra giá trị của property
                    var propertyValue = property.GetValue(entity);
                    // Trả về đối số kiểu cơ bản của kiểu nullable đã chỉ định.
                    var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    var value = "";
                    switch (propertyType.Name)
                    {
                        case "DateTime":
                            value = (propertyValue as DateTime?)?.ToString("dd/MM/yyyy"); // Định dạng ngày tháng
                            workSheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            break;
                        case "Int32":
                            value = (propertyValue as int?)?.ToString();
                            workSheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            break;
                        case "Decimal":
                            value = (propertyValue as decimal?)?.ToString("#,##0.00");
                            workSheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            break;
                        default:
                            value = propertyValue?.ToString();
                            break;
                    }
                    // nếu property là kiểu enum thì lấy ra giá trị của enum
                    if (propertyType.IsEnum)
                    {
                        try
                        {
                            var description = propertyType.GetMember(propertyValue.ToString())[0].GetCustomAttribute<System.ComponentModel.DescriptionAttribute>().Description;
                            if (description != null)
                            { // nếu enum có attribute Description thì lấy ra giá trị của Description
                                value = description;
                            }
                        }
                        catch (Exception)
                        {
                            value = propertyValue?.ToString();
                        }
                    }
                    // Đổ dữ liệu vào cột
                    workSheet.Cells[rowIndex, columnIndex].Value = value;
                    columnIndex++;
                }
                rowIndex++;
                stt++;
            }
        }

        #endregion

    }
}
