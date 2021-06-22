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
    public class TipoMaquinaController : ControllerBase
    {
        //se inicializa  la capa de datos  para recibir o enviar datos a la base de datos 
        TipoMaquinaDataAccessLayer tipoMaquinaDataAccessLayer = null;
        public TipoMaquinaController()
        {
            tipoMaquinaDataAccessLayer = new TipoMaquinaDataAccessLayer();
        }



        // GET api/<TipoMaquinaController>/*tipo*
        //
        // devuelve el tipo de maquina 
        [HttpGet("{tipo}")]

        public ActionResult GetTipoMaquina(string? tipo)
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
        // se  recibe en moldelo del tipo de maquina y se inserta
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
        // se actualizan los tipos de maquina
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
        // se eliminas los tipos de maquina,
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