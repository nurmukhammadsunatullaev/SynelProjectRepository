using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BusinessLevel.Models;

namespace BusinessLevel.Interfaces
{
    public interface IPersonService
    {
        public  Task<IEnumerable<PersonDtoModel>> CreateAsync(Stream stream);
        public  Task<PersonDtoModel> CreateAsync(PersonDtoModel dtoModel);
        public  Task<IEnumerable<PersonDtoModel>> GetAllAsyns();
        public  Task<IEnumerable<PersonDtoModel>> CreateAllAsync(IEnumerable<PersonDtoModel> records);
        public  Task<PersonDtoModel> GetByIdAsync(Guid id);
        public  Task UpdateAsync(PersonDtoModel dto);
        public  Task DeleteAsync(Guid id);
    }
}
