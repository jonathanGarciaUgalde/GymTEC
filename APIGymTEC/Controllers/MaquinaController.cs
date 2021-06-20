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
    public class MaquinaController : ControllerBase
    {

        MaquinaDataAccessLayer maquinaDataAccessLayer = null;
        public MaquinaController()
        {
            maquinaDataAccessLayer = new MaquinaDataAccessLayer();
        }



        // GET: api/<SucursalController>
        [HttpGet("{sucursal}")]
        public ActionResult GeInventario(int sucursal)
        {
            try
            {
                IEnumerable<Maquina> maquinas = maquinaDataAccessLayer.GetInventarioXtienda(sucursal);
                return Ok(maquinas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<MaquinaController>/5
        [HttpGet("{id}")]
        public ActionResult GetMaquina(int id)
        {
            try
            {
                IEnumerable<Sucursal> maquina = (IEnumerable<Sucursal>)maquinaDataAccessLayer.GetMaquina(id);
                return Ok(maquina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MaquinaController>
        [HttpPost]
        public ActionResult InsertMaquina([FromBody] Maquina maquina)
        {
            try
            {
                maquinaDataAccessLayer.AddMaquina(maquina);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<MaquinaController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateMaquina(int id, [FromBody]Maquina maquina)
        {
            try
            {

                maquinaDataAccessLayer.UpdateMaquina(maquina);
                return Ok(maquina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MaquinaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                maquinaDataAccessLayer.DeleteMaquina(id);
               
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
