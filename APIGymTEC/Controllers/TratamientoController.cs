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
    public class TratamientoController : ControllerBase
    {
        TratamientoDataAccessLayer tratamientoDataAccessLayer = null;
        public TratamientoController()
        {
            tratamientoDataAccessLayer = new TratamientoDataAccessLayer();
        }

        // GET: api/<TratamientolController>
        [HttpGet("{id}")]
        public ActionResult GetTratamiento(int? id)
        {
            try
            {
                
                Tratamiento tratamiento = tratamientoDataAccessLayer.GetTratamiento(id);
             
                return Ok(tratamiento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<TratamientoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TratamientoController>
       
        [HttpPost]
        public ActionResult Post([FromBody] Tratamiento tratamiento)
        {
            try
            {
                tratamientoDataAccessLayer.AddTratamiento(tratamiento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // PUT api/<TratamientoController>/5
        [HttpPut("{id}")]
        public ActionResult UpDateTratamiento( [FromBody] Tratamiento tratamiento)
        {
            try
            {
                tratamientoDataAccessLayer.UpdateTratamiento(tratamiento);
                
                return Ok(tratamiento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TratamientoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                tratamientoDataAccessLayer.DeleteTratamiento(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
