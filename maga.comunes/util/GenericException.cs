
using System.Data.SqlTypes;

namespace maga.commons.util
{
    public static class GenericExceptionHelper
    {
        public static Exception GenerateException(string message) => new Exception(message);

        public static SqlTruncateException SqlException(string message, Exception? e) => new SqlTruncateException(message, e);
    }
}