using maga.accessData.contracts.entities;

namespace maga.accessData.contracts.repositories
{
    public interface IGenericParemeterRepository
    {
        Task<List<GenericParameterEntity>> GetAllParameters(string code);
        Task<GenericParameterEntity?> GetParamByCodeAndLabel(string code, string label);
    }
}
