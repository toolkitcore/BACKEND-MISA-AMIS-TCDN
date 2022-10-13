using System.Collections;
using MISA.WEB08.AMIS.Common;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Enum;
using MISA.WEB08.AMIS.Common.Exceptions;
using MISA.WEB08.AMIS.Common.Resources;
using MISA.WEB08.AMIS.DL;
using MySqlConnector;
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
        /// <returns>Kết quả trả về từ ServiceResponse</returns>
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
            return _baseDL.Delete(Id);
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
                throw new ValidationException(ValidationResource.UserMsg_Validate_Failed, errorList);
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
            // TODO: Ghi đè phương thức này để custom validate dữ liệu
        }
        #endregion
    }
}
