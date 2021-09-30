using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsMediatR.Data.Repositiories
{
    public class AnimalRepository : CrudRepositoryBase<Animal, int>
    {
        public AnimalRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
