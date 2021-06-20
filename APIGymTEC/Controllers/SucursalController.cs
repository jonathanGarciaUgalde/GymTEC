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
    public class SucursalController : ControllerBase
    {

        SucursalDataAccessLayer sucursalDataAccessLayer = null;
        public SucursalController()
        {
            sucursalDataAccessLayer = new SucursalDataAccessLayer();
        }




        // GET: api/<SucursalController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Sucursal>  sucursales = sucursalDataAccessLayer.GetAllSucursales();
                return Ok(sucursales);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SucursalController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Sucursal sucursal= sucursalDataAccessLayer.GetSucursal(id);
                return Ok(sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SucursalController>
        [HttpPost]
        public ActionResult Post([FromBody] Sucursal sucursal)
        {
            try
            {
                sucursalDataAccessLayer.AddSucursal(sucursal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<SucursalController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Sucursal sucursal)
        {
            try
            {
                sucursal.Id = id;
                sucursalDataAccessLayer.UpdateSucursal(sucursal);
                return Ok(sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SucursalController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                sucursal.Id = id;
                sucursalDataAccessLayer.DeleteSucursal(sucursal.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SucursalController>/5
        [HttpPut("ActivarSpa/{idSucursal}")]
        public ActionResult ActivarSpa(int idSucursal)
        {
            try
            {                
                sucursalDataAccessLayer.ActivarSpa(idSucursal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SucursalController>/5
        [HttpPut("ActivarTienda/{idSucursal}")]
        public ActionResult ActivarTienda(int idSucursal)
        {
            try
            {
                sucursalDataAccessLayer.ActivarTienda(idSucursal);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









    }
}
