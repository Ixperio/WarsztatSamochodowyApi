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

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personsService;

        public PersonsController(IPersonService personService) {
            this._personsService = personService;
        }

        // GET: api/Persons/Test
        [HttpGet]
        public IActionResult Test()
        {
            var data = "Success";
            return new JsonResult(data);
        }

        //getters
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {

            var userLogged = _personsService.getLoggedUser(login.Email, login.Password);

            if(userLogged != null && userLogged.Id > 0)
            {

                var trustString = _personsService.getTrustStringByUser(userLogged.Id);

                if(!string.IsNullOrEmpty(trustString.trustString))
                {
                    return new JsonResult(trustString);
                }
                else
                {
                    return new JsonResult(null);
                }
              
            }
            else
            {
                return new JsonResult(null);
            }
        } 

        [HttpPost]
        public IActionResult GetUserData([FromBody] TrustString trustString)
        {
            var user = _personsService.getUserByTrustString(trustString.trustString);

            if (user != null)
            {
                return new JsonResult(user);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult GetUserType([FromBody] TrustString trustString)
        {
            var userType = _personsService.getUserTypeByTrustString(trustString.trustString);
            if(userType != null)
            {
                return new JsonResult(userType);
            }
            else
            {
                return NotFound();
            }
        }

        //setters

        [HttpPost]
        public IActionResult Register([FromBody] UserDtoRegister userDtoRegister)
        {
            if (ModelState.IsValid)
            {
               
               bool result = _personsService.addNewUser(userDtoRegister);

                if(result)
                {
                    return new JsonResult(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        //updates
        [HttpPut]
        public IActionResult UpdateName([FromBody] UserDtoUpdateName name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserName(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateSurname([FromBody] UserDtoUpdateSurname name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserSurname(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateEmail([FromBody] UserDtoUpdateEmail name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserEmail(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdatePassword([FromBody] UserDtoUpdatePassword name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserPassword(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdatePhone([FromBody] UserDtoUpdatePhone name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserPhone(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateBirthday([FromBody] UserDtoUpdateBirthday name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserBirthday(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateAdress([FromBody] UserDtoUpdateAdress name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserAdress(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdatePost([FromBody] UserDtoUpdatePost name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserPost(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateCity([FromBody] UserDtoUpdateCity name)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(name.trustString);
                if (user != null)
                {
                    if (_personsService.updateUserCity(name))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult UserDelete([FromBody] UserDtoDelete userDl)
        {
            if (ModelState.IsValid)
            {
                var user = _personsService.getUserByTrustString(userDl.trustString);
                if (user != null)
                {
                    if (_personsService.deleteUser(userDl))
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
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
