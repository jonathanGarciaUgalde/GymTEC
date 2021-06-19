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
    public class HorarioPorDiaController : ControllerBase
    {

        HorarioPorDiaDataAccessLayer horarioPorDiaDataAccessLayer = null;
        public HorarioPorDiaController()
        {
            horarioPorDiaDataAccessLayer = new HorarioPorDiaDataAccessLayer();
        }


        // GET: api/<HorarioPorDiaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<HorarioPorDia> horarioPorDia = horarioPorDiaDataAccessLayer.GetAllHorarioPorDia();
                return Ok(horarioPorDia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<HorarioPorDiaController>/5
        [HttpGet("{idSucursal}")]
        public ActionResult Get(int idSucursal)
        {
            try
            {
                IEnumerable<HorarioPorDia> horariosPorDia = horarioPorDiaDataAccessLayer.GetHorarioPorDia(idSucursal);
                return Ok(horariosPorDia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<HorarioPorDiaController>
        [HttpPost]
        public ActionResult Post([FromBody] HorarioPorDia horarioPorDia)
        {
            try
            {
                horarioPorDiaDataAccessLayer.AddHorarioPorDia(horarioPorDia);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }











        // PUT api/<HorarioPorDiaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<HorarioPorDiaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
