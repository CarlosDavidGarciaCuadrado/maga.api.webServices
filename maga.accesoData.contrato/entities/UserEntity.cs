
namespace maga.accessData.contracts.entities
{
    public class UserEntity
    {

        public ulong id {  get; set; }
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
        public string token {  get; set; } = string.Empty;  
        public string refresToken { get; set; } = string.Empty;
        public DateTime expirationTokenDate { get; set; } = DateTime.Now;
        public virtual ICollection<UserFamilyEntity>? userFamily { get; set; }
        public virtual ICollection<PhotoEntity>? photos { get; set; }
        public virtual ICollection<VideoEntity>? videos { get; set; }
    }
}
