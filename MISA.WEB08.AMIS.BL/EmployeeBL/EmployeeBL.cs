using System.Collections;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Exceptions;
using MISA.WEB08.AMIS.Common.Resources;
using MISA.WEB08.AMIS.DL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using static MISA.WEB08.AMIS.Common.AmisAttribute;
using System.Drawing;
using System;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Lớp thực thi các xử lý nghiệp vụ của nhân viên
    /// </summary>
    /// CreatedBy: AnhDV (27/09/2022)
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Fields

        private IEmployeeDL _employeeDL;

        #endregion

        #region Constructor
        public EmployeeBL(IEmployeeDL baseDL) : base(baseDL)
        {
            _employeeDL = baseDL;
        }
        #endregion


        #region Method

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy: AnhDV (27/09/2022)
        public string GetNewEmployeeCode()
        {
            return string.Format(EmployeeResource.EmployeeCodeFormat, _employeeDL.GetNewEmployeeCode());
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo điều kiện lọc và có phân trang
        /// </summary>
        /// <param name="EmployeeFilter">Điều kiện lọc</param>
        /// <returns>Danh sách nhân viên theo điều kiện lọc và có phân trang</returns>
        /// Created by: TCDN AnhDV (16/09/2022)
        public PagingData<Employee> GetPagingData(EmployeeFilter filter)
        {
            return _employeeDL.GetPagingData(filter);
        }

        /// <summary>
        /// Xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách id nhân viên cần xóa</param>
        /// <returns>Tổng số bản ghi bị ảnh hưởng</returns>
        /// Created by: TCDN AnhDV (04/10/2022)
        public int DeleteMultipleEmployee(List<Guid> employeeIds)
        {
            return _employeeDL.DeleteMultipleEmployee(employeeIds);
        }

        /// <summary>
        /// Validate nếu mã nhân viên đã tồn tại 
        /// </summary>
        /// <param name="employee">Nhân viên cần validate</param>
        /// <param name="isInsert">Kiểm tra là validate custom khi thêm mới hay cập nhật</param>
        /// <param name="Id">Id của nhân viên cần cập nhật</param>
        /// CreatedBy: AnhDV (27/09/2022)
        protected override void ValidateCustom(Employee employee, bool isInsert = true, Guid? Id = null)
        {
            bool isExistEmployeeCode;
            if (isInsert)
            {
                isExistEmployeeCode = _employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode.Trim());
            }
            else
            {
                isExistEmployeeCode = _employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode.Trim(), employee.EmployeeID ?? Id);
            }
            if (isExistEmployeeCode)
            {
                IDictionary errorList = new Dictionary<string, string>(){
                    { "EmployeeCode", String.Format(ValidationResource.MsgErrorEmployeeDuplicate, employee.EmployeeCode) }
                };
                throw new ValidationException(Resource.UserMsg_Insert_Duplicate, errorList);
            }
        }

        /// <summary>
        /// Xuất file excel danh sách nhân viên
        /// </summary>
        /// <returns>Đối tượng Stream chứa file excel</returns>
        /// CreatedBy: AnhDV (05/10/2022)
        public Stream ExportExcel()
        {
            var employees = _employeeDL.GetListExport();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Giải pháp tạm thời để sử dụng thư viện EPPlus
            var stream = new MemoryStream();
            var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add(ExportResource.Export_Employee_Sheet_Name);
            package.Workbook.Properties.Author = Resource.DefaultUser;
            package.Workbook.Properties.Title = ExportResource.Export_Employee_Title_Name;
            BindingFormatForExcel(workSheet, employees); // Binding format cho file excel
            package.Save();
            stream.Position = 0; // Đặt con trỏ về đầu file để đọc
            return package.Stream;
        }

        /// <summary>
        /// Binding format style cho file excel
        /// </summary>
        /// <param name="workSheet">Sheet cần binding format</param>
        /// <param name="employees">Danh sách nhân viên</param>
        /// CreatedBy: AnhDV (05/10/2022)
        private void BindingFormatForExcel(ExcelWorksheet workSheet, IEnumerable<Employee> employees)
        {
            // Lấy ra các property có attribute name là ExcelColumnNameAttribute 
            var excelColumnProperties = typeof(Employee).GetProperties().Where(p => p.GetCustomAttributes(typeof(ExcelColumnNameAttribute), true).Length > 0);

            // Lấy ra tên column cuối cùng (tính cả số thứ tự)
            var lastColumnName = (char)('A' + excelColumnProperties.Count());

            // Tạo phần tiêu đề cho file excel
            using (var range = workSheet.Cells[$"A1:{lastColumnName}1"])
            {
                range.Merge = true;
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 16;
                range.Style.Font.Name = "Arial";
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Value = ExportResource.Export_Employee_Title_Name;
            }
            // Gộp các ô từ A2 đến ô cuối cùng của dòng 2
            workSheet.Cells[$"A2:{lastColumnName}2"].Merge = true;

            // Style chung cho tất cả bảng
            using (var range = workSheet.Cells[$"A3:{lastColumnName}{employees.Count() + 3}"])
            {
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                range.Style.Font.Name = "Times New Roman";
                range.Style.Font.Size = 11;
                range.AutoFitColumns();
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
            using (var range = workSheet.Cells[$"A3:{lastColumnName}3"])
            {
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
            foreach (var employee in employees)
            {
                columnIndex = 1;
                workSheet.Cells[rowIndex, columnIndex].Value = stt;
                columnIndex++;
                foreach (var property in excelColumnProperties)
                {
                    // Lấy ra giá trị của property
                    var propertyValue = property.GetValue(employee);
                    // Trả về đối số kiểu cơ bản của kiểu nullable đã chỉ định.
                    var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    var value = "";
                    switch (propertyType.Name)
                    {
                        case "DateTime":
                            value = (propertyValue as DateTime?)?.ToString("dd/MM/yyyy"); // Định dạng ngày tháng
                            workSheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            break;
                        default:
                            value = propertyValue?.ToString();
                            break;
                    }
                    // Đổ dữ liệu vào cột
                    workSheet.Cells[rowIndex, columnIndex].Value = value;
                    workSheet.Column(columnIndex).AutoFit();
                    columnIndex++;
                }
                rowIndex++;
                stt++;
            }
        }
        #endregion
    }
}
