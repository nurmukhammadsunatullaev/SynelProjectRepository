using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLevel.Interfaces;
using BusinessLevel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SynelProject.Models;

namespace SynelProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPersonService personService, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _personService = personService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var people = await _personService.GetAllAsyns();
            ViewBag.People = _mapper.Map<IEnumerable<PersonViewModel>>(people);
            return View();
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var person = await _personService.GetByIdAsync(id);
            var people = await _personService.GetAllAsyns();
            ViewBag.People = _mapper.Map<IEnumerable<PersonViewModel>>(people);
            return View("Views/Home/Index.cshtml", _mapper.Map<PersonViewModel>(person));
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditAsync(PersonViewModel person)
        {
            var dto = _mapper.Map<PersonDtoModel>(person);
            await _personService.UpdateAsync(dto);
            return Redirect("/");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _personService.DeleteAsync(id);
            return Redirect("/");
        }


        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUploadAsync(IFormFile file)
        {
            IEnumerable<PersonDtoModel> people;
            using (var stream = file.OpenReadStream())
            {
               people = await _personService.CreateAsync(stream);
            }
            ViewBag.Message = $"Inserted {people.Count()} Records!";
            return View("Views/Home/Index.cshtml", _mapper.Map<IEnumerable<PersonViewModel>>(people));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
