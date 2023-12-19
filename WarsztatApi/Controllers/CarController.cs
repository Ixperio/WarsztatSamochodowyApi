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
    public class CarController : ControllerBase
    {
        private readonly IPersonService _personsService;
        private readonly ICarService _carService;

        public CarController(ICarService carService, IPersonService personService)
        {
            this._personsService = personService;
            this._carService = carService;
        }

        //tests

        [HttpGet]
        public IActionResult Test()
        {
            var test = new Test() { Controller = true, Service = _carService.test(), Repository = _carService.testRepo() };
            return new JsonResult(test);
        }

        //getters
        [HttpGet]
        public IActionResult GetFuelTypes()
        {
            var ret = _carService.getFuelType();
            if(ret == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(ret);
            }
            
        }

        [HttpPost]
        public IActionResult GetMyCars([FromBody] TrustString trustString)
        {
            if (ModelState.IsValid)
            {
                var person = _personsService.getPersonIdByTrustString(trustString.trustString);
                if (person != null)
                {

                    var ret = _carService.getCarByUserId(person.Value);


                    if (ret != null)
                    {
                        return new JsonResult(ret);
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }
        [HttpPost]
        public IActionResult GetBrands([FromBody] TrustString trust)
        {
            var carBrand = _carService.getBrands(trust);
            if (carBrand != null)
            {
                return new JsonResult(carBrand);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public IActionResult GetCarModelTypes([FromBody] TrustString trust)
        {
            var carBrand = _carService.getCarBody(trust);
            if (carBrand != null)
            {
                return new JsonResult(carBrand);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult GetCarModels([FromBody] ModelSamochoduDtoGetView model)
        {
            var carBrand = _carService.getCarModel(model);
            if (carBrand != null)
            {
                return new JsonResult(carBrand);
            }
            else
            {
                return NotFound();
            }

        }

        //adders

        [HttpPost]
        public IActionResult AddCar([FromBody] SamochodDtoAdd cartoadd)
        {
            if(ModelState.IsValid)
            {
                if (_carService.AddCar(cartoadd))
                {
                    return new JsonResult(true);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult AddBrand([FromBody] MarkaDtoAdd brand)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(_carService.AddBrand(brand));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult AddBody([FromBody] WersjeNadwoziaDtoAdd wersja)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(_carService.AddBody(wersja));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult AddCarModel([FromBody] ModelSamochoduDtoAdd model)
        {
            if (ModelState.IsValid)
            {
                return new JsonResult(_carService.AddModel(model));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //upadtes

        //deletes
        [HttpPost]
        public IActionResult Delete([FromBody] SamochodDtoDelete sam)
        {
            if (ModelState.IsValid)
            {
                if (_carService.DeleteCar(sam))
                {
                    return new JsonResult(true);
                }
            }
            return new JsonResult(false);
        }
    }
}
