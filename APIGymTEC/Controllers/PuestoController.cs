using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGymTEC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIGymTEC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {


        PuestoDataAccessLayer puestoDataAccessLayer = null;
        public PuestoController()
        {
            puestoDataAccessLayer = new PuestoDataAccessLayer();
        }

        // GET: api/<PuestoController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        // GET api/<PuestoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<PuestoController>
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<PuestoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Puesto puesto)
        {
            try
            {
                puestoDataAccessLayer.UpdatePuesto(puesto);
                return Ok(puesto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PuestoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
