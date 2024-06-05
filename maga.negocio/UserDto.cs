
namespace maga.Bussines
{
    public class UserDto
    {
        public ulong id { get; set; }
        public string name { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateTime birthDate { get; set; } = DateTime.Now;
        public string familyNickName { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public byte state { get; set; }
        public byte isAdmin { get; set; }
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public DateTime creationDate { get; set; } = DateTime.Now;
        public DateTime updatedDate { get; set; } = DateTime.Now;
        public ulong idFamily { get; set; }
    }

    public class UserToShow
    {
        public ulong id { get; set; }
        public string name { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateTime birthDate { get; set; } = DateTime.Now;
        public string familyNickName { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public byte state { get; set; }
        public byte isAdmin { get; set; }
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public ulong idFamily { get; set; }
    }

    public class ResponseAddOrUpdate<T> where T : class
    {
        public T? identity { get; set; }
        public bool created { get; set; } = true;
    }
}
