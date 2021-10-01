
namespace HAIRCARE.CORE.Base
{
    public static class CommonConstants
    {
        public static bool EXECUTE_SUCCESS = true;
        public static bool EXECUTE_FAILED = false;
    }
    public static class ApplicationMessage
    {
        public const string ERR_MSG_REQUIRED_FIELD = "{0} là trường bắt buộc hoặc Hãy nhập {0}.";
        public const string ERR_MSG_USER_LOCKED = "Tài khoản đã bị khóa do login quá nhiều lần. ";
        public const string ERR_MSG_USER_INVALID = "{0} không tồn tại. Vui lòng kiểm tra lại.";
        public const string ERR_MSG_USER_INVALID_PASSWORD = "Đăng nhập không thành công do mật khẩu không hợp lệ. Vui lòng kiểm tra lại.";
        public const string ERR_MSG_USER_TEMPORARY = "{0} đã được tạo nhưng cần xác nhận email!";
        public const string ERR_MSG_IMAGE_SIZE = "Kích thước tệp phải từ 1BYTE đến 10MB!";
        public const string ERR_MSG_IMAGE_TYPE = "Loại tệp phải có định dạng (.jpg, .jepg, .png).";
        public const string ERR_MSG_FILE_SIEZ = "Kích thước tệp phải từ 0KB đến 20MB!";
        public const string ERR_MSG_FILE_TYPE = "Loại tệp có định dạng (.pdf, .docx, .doc, .xls, .xlsx, .jpg, .jepg, .png, .zip, .ppt, pptx).";
    }
    public static class ApplicationObjects
    {
        public const string USERNAME = "Tên đăng nhập";
        public const string PASSWORD = "Mật khẩu";
    }
}
