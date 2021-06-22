using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGymTEC.Models;
using Microsoft.AspNetCore.Mvc;
/*
        Capa que permite  enviar  y recibir datos metiante el protocolo http y comunica los diferentes  tipos de 
        metodos de la capa de datos de clase con su consumer en angular
            */
namespace APIGymTEC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaController : ControllerBase
    {
        // comunicación con capa de  datos
        MaquinaDataAccessLayer maquinaDataAccessLayer = null;
        public MaquinaController()
        {
            maquinaDataAccessLayer = new MaquinaDataAccessLayer();
        }
        // GET: api/<SucursalController>
        // se recibe  de la pagina web  una peticion de obtener  el  inventario  asociado a  una sicursal
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
        // se recibe  de la pagina web  una peticion de obtener   una maquina especifica asociada a  una sicursal

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
        // se recibe  de la pagina web  una peticion de Insertar   una maquina asociada  a una sucursal
        // actualiza inventario de igual manera 
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
        // se recibe  de la pagina web  una peticion de actualizar   una maquina asociada  a una sucursal
        // actualiza inventario de igual manera 

        [HttpPut("{id}")]
        public ActionResult UpdateMaquina(int id, [FromBody] Maquina maquina)
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
        // se recibe  de la pagina web  una peticion de eliminar   una maquina asociada  a una sucursal
        // actualiza inventario de igual manera 
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
