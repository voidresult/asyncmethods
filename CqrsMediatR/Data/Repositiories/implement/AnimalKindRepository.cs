using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsMediatR.Data.Repositiories
{
    public class AnimalKindRepository : CrudRepositoryBase<AnimalKind, int>
    {
        public AnimalKindRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
