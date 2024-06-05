using maga.accesoData.contrato;
using maga.accessData.contracts.entities;
using maga.accessData.contracts.repositories;  

namespace maga.accessData.repositories
{
    public class FamilyRepository: IFamilyRepository
    {
        private readonly IMagaContext _magaContext;
        public FamilyRepository(IMagaContext magaContext)
        {
            _magaContext = magaContext;
        }
        public async Task<FamilyEntity> Add(FamilyEntity family)
        {
            await _magaContext.families.AddAsync(family);
            var res = await _magaContext.SaveChangesAsync();
            Console.Write(res.ToString());
            return family;
        }

        public async Task<FamilyEntity?> DeleteAsync(ulong id)
        {
            FamilyEntity? family = await Get(id);
            if (family != null)
            {
                _magaContext.families.Remove(family);
                await _magaContext.SaveChangesAsync();
            }
            return family;
        }

        public async Task<bool> Exists(ulong id)
        {
            return await Get(id) != null;
        }

        public async Task<FamilyEntity?> Get(ulong id)
        {
            return await _magaContext.families.FindAsync(id);
        }

        public Task<IEnumerable<FamilyEntity>> GetAll() =>
            Task.FromResult<IEnumerable<FamilyEntity>>(_magaContext.families);

        public async Task<FamilyEntity> Update(FamilyEntity family)
        {
            _magaContext.families.Update(family);
            await _magaContext.SaveChangesAsync();
            return family;
        }
    }
}
