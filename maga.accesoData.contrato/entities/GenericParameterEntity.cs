
namespace maga.accessData.contracts.entities
{
    public class GenericParameterEntity
    {
        public int id {  get; set; }
        public string code {  get; set; } = string.Empty;
        public string label { get; set; } = string.Empty;
        public string valueString { get; set; } = string.Empty;
        public uint valueInt { get; set; }
    }
}
