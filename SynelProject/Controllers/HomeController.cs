using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SynelProject.Models;
using SynelProject.Models.ViewModels;
using SynelProject.Services;

namespace SynelProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonService _personService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, PersonService personService, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _personService = personService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _personService.GetAllAsyns());
        }



        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUploadAsync(IFormFile file)
        {
            IEnumerable<PersonViewModel> people;
            CSVReaderService service = new CSVReaderService();
            using (var stream = file.OpenReadStream())
            {
              var records = service.ReadCSVFile(stream);
                people = await _personService.SaveAllAsync(_mapper.Map<IEnumerable<PersonViewModel>>(records));
            }
            return View("Views/Home/Index.cshtml", people);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
