using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatR.Data.Repositiories
{
    public abstract class CrudRepositoryBase<TEntry, TKey> : IRepository<TEntry, TKey> where TEntry : class, IHasKeyEntry<TKey>
    {
        private readonly DbContext dbContext;
        public CrudRepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TEntry> Create(TEntry entry)
        {
            Thread.Sleep(2000);
            dbContext.Set<TEntry>().Add(entry);
            await dbContext.SaveChangesAsync();
            foreach (var reference in dbContext.Entry(entry).References)
            {
                await reference.LoadAsync();
            }
            return entry;
        }

        public async Task Delete(TKey id)
        {
            Thread.Sleep(500);
            TEntry fordelete = await dbContext.Set<TEntry>().FindAsync(id);
            if (fordelete != null)
            {
                dbContext.Set<TEntry>().Remove(fordelete);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntry> Get(TKey id)
        {
            Thread.Sleep(500);
            return await dbContext.Set<TEntry>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntry>> GetAll()
        {
            Thread.Sleep(500);
            return await dbContext.Set<TEntry>().ToListAsync();
        }

        public async Task<TEntry> Update(TEntry entry)
        {
            Thread.Sleep(500);
            dbContext.Set<TEntry>().Update(entry);
            await dbContext.SaveChangesAsync();
            foreach (var reference in dbContext.Entry(entry).References)
            {
                await reference.LoadAsync();
            }
            return entry;
        }
    }
}
