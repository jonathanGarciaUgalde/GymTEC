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
    public class PlanillaController : ControllerBase
    {



        PlanillaDataAccessLayer planillaDataAccessLayer = null;
        public PlanillaController()
        {
            planillaDataAccessLayer = new PlanillaDataAccessLayer();
        }


        // GET: api/<PlanillaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Planilla> planillas= planillaDataAccessLayer.GetAllPlanilla();
                return Ok(planillas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PlanillaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Planilla planilla= planillaDataAccessLayer.GetPlanilla(id);
                return Ok(planilla);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PlanillaController>
        [HttpPost]
        public ActionResult Post([FromBody] Planilla planilla)
        {
            try
            {
                planillaDataAccessLayer.AddPlanilla(planilla);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PlanillaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Planilla planilla)
        {
            try
            {
                planillaDataAccessLayer.UpdatePlanilla(planilla);
                return Ok(planilla);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PlanillaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Planilla planilla = new Planilla();
                planilla.Id = id;
                planillaDataAccessLayer.DeletePlanilla(planilla.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
    