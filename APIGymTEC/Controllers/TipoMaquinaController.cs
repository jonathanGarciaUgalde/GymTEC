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
    public class TipoMaquinaController : ControllerBase
    {
        TipoMaquinaDataAccessLayer tipoMaquinaDataAccessLayer = null;
        public TipoMaquinaController()
        {
            tipoMaquinaDataAccessLayer = new TipoMaquinaDataAccessLayer();
        }



        // GET api/<TipoMaquinaController>/*tipo*

        [HttpGet("{tipo}")]
        public ActionResult GetMaquina(string? tipo)
        {
            try
            {
                IEnumerable<TipoMaquina> tipoMaquina = (IEnumerable<TipoMaquina>)tipoMaquinaDataAccessLayer.GetTipoMaquina(tipo);
                return Ok(tipoMaquina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] TipoMaquina tipo)
        {
            try
            {
                tipoMaquinaDataAccessLayer.AddTipoMaquina(tipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<TipoMaquinaController>/5
        [HttpPut]
        public ActionResult UpdateTipoMaquina([FromBody] TipoMaquina tipo)
        {
            try
            {
                tipoMaquinaDataAccessLayer.UpdateTipoMaquina(tipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TipoMaquinaController>/tipo
        [HttpDelete("{tipo}")]
        public ActionResult Delete(string tipo)
        {
            try
            {
                tipoMaquinaDataAccessLayer.DeleteTipoMaquina(tipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}