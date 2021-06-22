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
    public class TratamientoController : ControllerBase
    {
        TratamientoDataAccessLayer tratamientoDataAccessLayer = null;
        public TratamientoController()
        {
            tratamientoDataAccessLayer = new TratamientoDataAccessLayer();
        }// inicializa  la capa de datos 

        // GET: api/<TratamientolController>
        // se recibe  de la pagina web  una peticion de obtener un tratamiento asociado con su ID  asociado a  una sicursal

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

        // POST api/<TratamientoController>
        // se recibe  de la pagina web  una peticion de insertar  un tratamiento asociado a  una sucursal
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
        // se recibe  de la pagina web  una peticion actualizar el tratamiento  asociado a  una sicursal
        [HttpPut("{id}")]
        public ActionResult UpDateTratamiento([FromBody] Tratamiento tratamiento)
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
        // se recibe  de la pagina web  una peticion de eliminar   un tratamiento  asociado a  una sucursal
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
