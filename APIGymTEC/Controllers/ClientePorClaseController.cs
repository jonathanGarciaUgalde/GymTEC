using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIGymTEC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIGymTEC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePorClaseController : ControllerBase
    {
        ClientePorClaseDataAccessLayer claseClienteDataAccessLayer = null;
        public ClientePorClaseController()
        {
            claseClienteDataAccessLayer = new ClientePorClaseDataAccessLayer();
        }


        // GET: api/ClientePorClase/ProximasActividades/*cedula*
        [HttpGet("ProximasActividades/{cedula}")]
        public ActionResult ProximasActividades(string cedula)
        {
            try
            {
                IEnumerable<ClaseCompleta> clases = claseClienteDataAccessLayer.actividadesProxima(cedula);
                return Ok(clases);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<ClientePorClaseController>
        [HttpPost]
        public ActionResult Post([FromBody] ClientePorClase clase)
        {
            try
            {
                claseClienteDataAccessLayer.AddClientePorClase(clase);
                return Ok(clase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




    }
}