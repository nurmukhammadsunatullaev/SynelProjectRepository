using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SynelProject.Data;
using SynelProject.Models.EntityModels;

namespace SynelProject.Repositories
{
    public class PersonRepository
    {
        private readonly AppDbContext _dbContext;
        public PersonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<PersonEntityModel> CreateAsync(PersonEntityModel person)
        {
            var entityEntry = await _dbContext.Set<PersonEntityModel>().AddAsync(person);
            return entityEntry.Entity;
        }

        public async Task<IList<PersonEntityModel>> FindAllAsync()
        {
            return await _dbContext.Set<PersonEntityModel>().ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
