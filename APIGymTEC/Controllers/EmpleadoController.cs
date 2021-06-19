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
    public class EmpleadoController : ControllerBase
    {
        EmpleadoDataAccessLayer empleadoDataAccessLayer = null;
        public EmpleadoController()
        {
            empleadoDataAccessLayer = new EmpleadoDataAccessLayer();
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<EmpleadoCargo> empleados = empleadoDataAccessLayer.GetAllEmpleado();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{cedula}")]
        public ActionResult Get(string cedula)
        {
            try
            {
                EmpleadoCargo empleado = empleadoDataAccessLayer.GetEmpleado(cedula);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public ActionResult Post([FromBody] EmpleadoCargo empleado)
        {
            try
            {
                empleadoDataAccessLayer.AddEmpleado(empleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{cedula}")]
        public ActionResult Put(string cedula, [FromBody] EmpleadoCargo empleado)
        {
            try
            {
                empleado.Cedula = cedula;
                empleadoDataAccessLayer.UpdateEmpleado(empleado);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{cedula}")]
        public ActionResult Delete(string cedula)
        {
            try
            {
                Empleado empleado= new Empleado();
                empleado.Cedula = cedula;
                empleadoDataAccessLayer.DeleteEmpleado(empleado.Cedula);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
