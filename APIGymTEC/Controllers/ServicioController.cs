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
    public class ServicioController : ControllerBase
    {

        ServicioDataAccessLayer servicioDataAccessLayer = null;
        public ServicioController()
        {
            servicioDataAccessLayer = new ServicioDataAccessLayer();
        }

        // GET: api/<ServicioController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Servicio> servicios = servicioDataAccessLayer.GetAllServicio();
                return Ok(servicios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Servicio servicio = servicioDataAccessLayer.GetServicio(id);
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ServicioController>
        [HttpPost]
        public ActionResult Post([FromBody] Servicio servicio)
        {
            try
            {
                servicioDataAccessLayer.AddServicio(servicio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ServicioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Servicio servicio)
        {
            try
            {
                servicio.Id = id;
                servicioDataAccessLayer.UpdateServicio(servicio);
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Servicio servicio= new Servicio();
                servicio.Id = id;
                servicioDataAccessLayer.DeleteServicio(servicio.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
