
namespace maga.accessData.contracts.entities
{
    public class VerifyCodeEntity
    {
        public string code { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public DateTime expirationDate { get; set; }
    }
}
