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
    public class ClaseController : ControllerBase
    {
        ClaseDataAccessLayer claseDataAccessLayer = null;
        public ClaseController()
        {
            claseDataAccessLayer = new ClaseDataAccessLayer();
        }


        // GET api/<ClaseController>/ClasePorSucursal
        [HttpGet("ClasePorSucursal/{idSucursal}")]
        public ActionResult ClasePorSucursal(int idSucursal)
        {
            Console.Write(idSucursal);
            try
            {
                IEnumerable<ClaseCompleta> clases = claseDataAccessLayer.GetClasePorSucursal(idSucursal);
                return Ok(clases);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ClaseController>/ClasePorPeriodo
        [HttpPost("ClasePorPeriodo")]
        public ActionResult ClasePorPeriodo([FromBody] Clase clase)
        {
            try
            {
                IEnumerable<ClaseCompleta> clases = claseDataAccessLayer.GetClasePorPeriodo(clase);
                return Ok(clases);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ClaseController>/clasePorClase
        [HttpPost("ClasePorTipo")]
        public ActionResult ClasePorTipo(Servicio tipoClase)
        {
            try
            {
                IEnumerable<ClaseCompleta> clases = claseDataAccessLayer.GetClasePorTipo(tipoClase);
                return Ok(clases);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClaseController>
        [HttpPost]
        public ActionResult addClase([FromBody] Clase clase)
        {
            try
            {
                claseDataAccessLayer.AddClase(clase);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
