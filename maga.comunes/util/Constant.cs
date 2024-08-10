
namespace maga.commons.util
{
    public static class Constant
    {
        public const string ADD_SUCCESS = "Se agregó el registro exitosamente.";
        public const string UPDATE_SUCCESS = "Se actualizó el registro exitosamente.";
        public const string DELETE_SUCCESS = "Se eliminó el registro exitosamente.";
        public const string GET_SUCCESS = "Registro obtenidos exitosamente.";
        public const string UPDATE_PASSWORD_SUCCESS = "Se actualizó la contraseña exitosamente.";
        public const string RECOVERY_CODE_PASSWORD_SUCCESS = "Se envió un codigo de recuperación de contraseña al correo.";

        public const string ADD_ERROR = "Error al ingresar la información en base de datos.";
        public const string UPDATE_ERROR = "Error al actualizar la información en base de datos.";
        public const string DELETE_ERROR = "Error al eliminar la información en base de datos.";

        public const string CODE_SEND_EMAIL_VERIFY = "VERIFY_EMAIL";
        public const string HOST_SEND_EMAIL_VERIFY = "HOST";
        public const string PORT_SEND_EMAIL_VERIFY = "PORT";
        public const string USER_SEND_EMAIL_VERIFY = "USER";
        public const string PASSWORD_APLICATION_SEND_EMAIL_VERIFY = "PASSWORD_APLICATION";
        public const string BODY_SEND_EMAIL_VERIFY = "BODY";
        public const string CODE_GENERIC_PARAM = "GENERIC_PARAM";
        public const string EXPIRATION_CODE_GENERIC_PARAM = "CODE_VERIFY_EMAIL_DATE";
        public const string EXPIRATION_TOKEN_GENERIC_PARAM = "TOKEN_EXPIRATION_DATE";


        public const int TOKEN_EXPIRATION_DATE = 10;
        public const uint CODE_EXPIRATION_DATE = 5;
    }
}
