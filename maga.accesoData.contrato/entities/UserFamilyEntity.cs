
namespace maga.accessData.contracts.entities
{
    public class UserFamilyEntity
    {
        public ulong id { get; set; }
        public ulong idUser { get; set; }
        public ulong idFamily { get; set; }
        public virtual UserEntity? users { get; set; }
        public virtual FamilyEntity? families { get; set; }
    }
}
