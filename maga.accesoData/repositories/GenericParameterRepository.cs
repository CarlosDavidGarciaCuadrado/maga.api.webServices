using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;

namespace maga.accessData.repositories
{
    public class GenericParameterRepository: IGenericParemeterRepository
    {
        private readonly IMagaContext _magaContext;
        public GenericParameterRepository(IMagaContext magaContext) 
        {
            _magaContext = magaContext;
        }

        public Task<List<GenericParameterEntity>> GetAllParameters(string code)
        {
            return Task.FromResult(_magaContext.genericParameters.Where(entity => entity.code == code).ToList());
        }

        public async Task<GenericParameterEntity?> GetParamByCodeAndLabel(string code, string label)
        {
            List<GenericParameterEntity> parameters = await GetAllParameters(code);
            return parameters.Find(parameter => parameter.label == label);
        }
    }
}
