using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_11.Models.Requests;
using apbd_11.Models.Responses;
using apbd_11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsServiceDb doctorsServiceDb;

        public DoctorsController(IDoctorsServiceDb serviceDb)
        {
            doctorsServiceDb = serviceDb;
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            if (doctorsServiceDb.getDoctor(id) == null) { 
                return BadRequest("Doctor doesnt exists");
            }
            return Ok(doctorsServiceDb.getDoctor(id));

        }

        [HttpPost("insert")]
        public IActionResult InsertDoctor(InsertDoctorRequest request)
        {
            return Ok(doctorsServiceDb.InsertDoctor(request));
        }

        [HttpPost("update")]
        public IActionResult UpdateDoctor(UpdateDoctorRequest request)
        {
            var response = doctorsServiceDb.UpdateDoctor(request);
            if (response == null) return BadRequest("Such doctor doesnt exists");
            return Ok(response);
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var response = doctorsServiceDb.DeleteDoctor(id);
            if (response == null) return BadRequest("Such doctor doesnt exists");
            return Ok(response);
        }
    }
}