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
    public class TelefonoController : ControllerBase
    {
        TelefonoDataAccessLayer telefonoDataAccessLayer = null;
        public TelefonoController()
        {
            telefonoDataAccessLayer = new TelefonoDataAccessLayer();
        }

        // GET: api/<TelefonoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Telefono> telefonos = telefonoDataAccessLayer.GetAllTelefono();
                return Ok(telefonos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TelefonoController>/5
        [HttpGet("{IdSucursal}")]
        public ActionResult Get(int IdSucursal)
        {
            try
            {
                IEnumerable <Telefono> telefonos = telefonoDataAccessLayer.GetTelefono(IdSucursal);
                return Ok(telefonos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TelefonoController>
        [HttpPost]
        public ActionResult Post([FromBody] Telefono telefono)
        {
            try
            {
                telefonoDataAccessLayer.AddTelefono(telefono);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


















        // PUT api/<TelefonoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TelefonoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
