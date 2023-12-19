using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using WarsztatApi.Dto;
using WarsztatApi.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WarsztatApi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ComissionController : ControllerBase
    {
        private readonly IPersonService _personsService;
        private readonly ICarService _carService;

        public ComissionController(ICarService carService, IPersonService personService)
        {
            this._personsService = personService;
            this._carService = carService;
        }


    }
}
