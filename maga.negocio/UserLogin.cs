
namespace maga.Bussines
{
    public class UserLogin
    {
        public string userName { get; set;} = string.Empty;
        public string password { get; set; } = string.Empty; 
    }

    public class ResponseToken
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public UserToShow? userToShow { get; set; }
    }

    public class RequestToken
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }

    public enum enumClaimTypes
    {
        EnumUserId,
        EnumUserName,
    }
}
