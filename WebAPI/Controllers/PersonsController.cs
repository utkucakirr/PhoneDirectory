using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getpersons")]
        public IActionResult GetPersons()
        {
            var result = _personService.GetPersons();
            if (result!=null)
            {
                Logger.Info("Persons listed.");
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _personService.GetByName(name);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbynumber")]
        public IActionResult GetByNumber(long number)
        {
            var result = _personService.GetByNumber(number);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Person person)
        {
            var result = _personService.Add(person);
            //Logger.Info("Person added");
            if (result.Success)
            {
                Logger.Info("Person added succesfully");
                return Ok(result);
            }
            Logger.Error("Fail on adding person.(User error.)");
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Person person)
        {
            var result = _personService.Update(person);
            if (result.Success)
            {
                Logger.Info("Person updated succesfully");
                return Ok(result);
            }
            Logger.Error("Fail on updating person.(User error.)");
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Person person)
        {
            var result = _personService.Delete(person);
            if (result.Success)
            {
                Logger.Info("Person deleted succesfully");
                return Ok(result);
            }
            Logger.Error("Fail on deleting person.(User error.)");
            return BadRequest(result);
        }
    }
}
