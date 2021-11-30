using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLevel.Interfaces;
using DatabaseLevel.Data;
using DatabaseLevel.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLevel.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext context;
        protected readonly DbSet<PersonEntityModel> set;

        public PersonRepository(AppDbContext context)
        {
            this.context = context;
            this.set = context.Set<PersonEntityModel>();
        }

        public  async Task<IEnumerable<PersonEntityModel>> FindAllAsync()
        {
            return await set.ToListAsync();
        }

        
        public  async Task<IEnumerable<PersonEntityModel>> FindByConditionAsync(Expression<Func<PersonEntityModel, bool>> expression)
        {
            IQueryable<PersonEntityModel> query = set.Where(expression);
            return await query.ToListAsync();
        }

        public  async Task<PersonEntityModel> FindByIdAsync(Guid id)
        {
            return await set.FindAsync(id);
        }

        public  async Task<PersonEntityModel> CreateAsync(PersonEntityModel item)
        {
            var entityEntry = await set.AddAsync(item);
            return entityEntry.Entity;
        }

        public  bool Update(PersonEntityModel item)
        {
            context.Update(item);
            return true;
        }

        public  bool Delete(Guid id)
        {
            PersonEntityModel del_item = set.Find(id);
            if (del_item != null)
            {
                set.Remove(del_item);
                return true;
            }
            return false;
        }
    }
}
