using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Data
{
    public interface IRepository<TEntry, TKey> where TEntry : IHasKeyEntry<TKey> 
    {
        Task<IEnumerable<TEntry>> GetAll();
        Task<TEntry> Get(TKey id);
        Task Delete(TKey id);
        Task<TEntry> Create(TEntry entry);
        Task<TEntry> Update(TEntry entry);
    }
}
