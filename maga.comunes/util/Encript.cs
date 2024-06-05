
namespace maga.commons.util
{
    public static class Encript
    {
        public static string encriptBCrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool verifyBCrypt(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
