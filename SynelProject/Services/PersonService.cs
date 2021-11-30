using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SynelProject.Models.EntityModels;
using SynelProject.Models.ViewModels;
using SynelProject.Repositories;

namespace SynelProject.Services
{
    public class PersonService
    {
        private readonly IMapper _mapper;
        private readonly PersonRepository _repository;

        public PersonService(PersonRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PersonViewModel> CreateAsync(PersonViewModel viewModel)
        {
            var entity = _mapper.Map<PersonEntityModel>(viewModel);
            var view = await _repository.CreateAsync(entity);
            await _repository.SaveAsync();
            return _mapper.Map<PersonViewModel>(view);
        }

        public async Task<IEnumerable<PersonViewModel>> GetAllAsyns()
        {
            var persons = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<PersonViewModel>>(persons);
        }

        public async Task<IEnumerable<PersonViewModel>> SaveAllAsync(IEnumerable<PersonViewModel> records)
        {
            List<PersonViewModel> persons = new List<PersonViewModel>();
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
    }
}
