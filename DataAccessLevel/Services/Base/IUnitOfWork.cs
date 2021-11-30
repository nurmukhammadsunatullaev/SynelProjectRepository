using System;
using System.Threading.Tasks;
using DataAccessLevel.Interfaces;

namespace DataAccessLevel.Services.Base
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }
        Task SaveAsync();
    }
}
