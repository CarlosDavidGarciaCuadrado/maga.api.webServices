

namespace maga.accessData.contracts.entities
{
    public class FamilyEntity
    {
        public ulong id { get; set; }
        public string lastName { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public ulong idUserCreation { get; set; }
        public byte state { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updatedDate { get; set; }
        public virtual ICollection<UserFamilyEntity>? userFamily { get; set; }
    }
}
