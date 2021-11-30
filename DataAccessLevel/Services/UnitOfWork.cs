using System;
using System.Threading.Tasks;
using DataAccessLevel.Interfaces;
using DataAccessLevel.Repositories;
using DataAccessLevel.Services.Base;
using DatabaseLevel.Data;

namespace DataAccessLevel.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private IPersonRepository persons;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public IPersonRepository Persons
        {
            get
            {
                if (persons == null)
                {
                    persons = new PersonRepository(context);
                }
                return persons;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                context.DisposeAsync();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
