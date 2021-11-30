using System;
using DataAccessLevel.Interfaces.Base;
using DatabaseLevel.EntityModels;

namespace DataAccessLevel.Interfaces
{
    public interface IPersonRepository : Repository<PersonEntityModel, Guid>
    {
    }
}
