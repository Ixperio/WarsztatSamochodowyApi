using Microsoft.AspNetCore.Mvc;
using WarsztatApi.Dto;
using WarsztatApi.Services.Interfaces;
using DB.Entities;
using System.Data;
using System;

namespace WarsztatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WorkController : ControllerBase
    {
        private readonly IPersonService _personsService;
        private readonly ICarService _carService;
        private MyDbContext _db;
        public WorkController(ICarService carService, IPersonService personService, MyDbContext db)
        {
            this._personsService = personService;
            this._carService = carService;
            _db = db;
        }

        //tests

        [HttpGet]
        public IActionResult Test()
        {
            var test = new Test() { Controller = true, Service = _carService.test(), Repository = _carService.testRepo() };
            return new JsonResult(test);
        }

        [HttpGet]
        public IActionResult ShowMyWorks(TrustString trs)
        {
            var userId = _personsService.getPersonIdByTrustString(trs.trustString);

            if(userId != null)
            {
                var res = _db.Works.Select(x => x.PersonWorkerId == userId).ToList();

                return new JsonResult(res);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        [HttpPost]
        public IActionResult AddWork(WorkDTOAdd trs)
        {

            var userId = _personsService.getPersonIdByTrustString(trs.trustString);

            if (userId != null)
            {
                var data = System.DateTime.Now;
                var newWork = new Zlecenie()
                {
                    OpisZdarzenia = trs.OpisZdarzenia,
                    dataPrzekazaniaPojazdu = trs.dataPrzekazaniaPojazdu,
                    dataWplyniecia = data, 
                    rodzajUslugiId = trs.rodzajUslugiId,
                    statusZleceniaId = 1,
                    SamochodId = trs.SamochodId
                };
                    
                _db.Works.Add(newWork);
                _db.SaveChanges();

                return new JsonResult(true);
            }
            else
            {
                return new JsonResult(false);
            }

        }

    }
}
