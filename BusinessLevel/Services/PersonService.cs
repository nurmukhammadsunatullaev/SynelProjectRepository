using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLevel.Interfaces;
using BusinessLevel.Models;
using DataAccessLevel.Services.Base;
using DatabaseLevel.EntityModels;

namespace BusinessLevel.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICSVReaderService _csvService;

        public PersonService(IUnitOfWork unitOfWork, ICSVReaderService csvService, IMapper mapper)
        {
            _mapper = mapper;
            _csvService = csvService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonDtoModel>> CreateAsync(Stream stream)
        {
            var records = _csvService.Read(stream);
            return await CreateAllAsync(_mapper.Map<IEnumerable<PersonDtoModel>>(records));

        }

        public async Task<PersonDtoModel> CreateAsync(PersonDtoModel dtoModel)
        {
            var entity = _mapper.Map<PersonEntityModel>(dtoModel);
            var dto = await _unitOfWork.Persons.CreateAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PersonDtoModel>(dto);
        }

        public async Task<IEnumerable<PersonDtoModel>> GetAllAsyns()
        {
            var persons = await _unitOfWork.Persons.FindAllAsync();
            return _mapper.Map<IEnumerable<PersonDtoModel>>(persons);
        }

        public async Task<IEnumerable<PersonDtoModel>> CreateAllAsync(IEnumerable<PersonDtoModel> records)
        {
            List<PersonDtoModel> persons = new List<PersonDtoModel>();
            foreach (var person in records)
            {
                var result = await CreateAsync(person);
                if (result != null)
                {
                    persons.Add(result);
                }
            }

            return persons;
           
        }

        public async Task DeleteAsync(Guid id)
        {
            _unitOfWork.Persons.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<PersonDtoModel> GetByIdAsync(Guid id)
        {
            var person = await _unitOfWork.Persons.FindByIdAsync(id);
            return _mapper.Map<PersonDtoModel>(person);
        }

        public async Task UpdateAsync(PersonDtoModel dto)
        {
            var entity = _mapper.Map<PersonEntityModel>(dto);
           _unitOfWork.Persons.Update(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
