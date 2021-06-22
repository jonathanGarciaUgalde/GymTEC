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
    public class ProductoController : ControllerBase
    {

        ProductoDataAccessLayer productoDataAccessLayer = null;
        public ProductoController()
        {
            productoDataAccessLayer = new ProductoDataAccessLayer();
        }


        // GET api/<ProductoController>
        [HttpGet()]
        public ActionResult Get()
        {
            try
            {
                IEnumerable<Producto> productos = productoDataAccessLayer.GetProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<ProductoController>/5
        [HttpGet("{idSucursal}")]
        public ActionResult Getall(int idSucursal)
        {
            try
            {
                IEnumerable<Producto> productos = productoDataAccessLayer.GetAllProducto(idSucursal);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                productoDataAccessLayer.AddProducto(producto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public ActionResult updateProducto([FromBody] Producto producto)
        {
            try
            {

                productoDataAccessLayer.UpdateProducto(producto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*
                [HttpPost]
                public ActionResult updateStock([FromBody] Producto producto)
                {
                    try
                    {

                        productoDataAccessLayer.UpdateProducto(producto);
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }


        */

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {

                productoDataAccessLayer.DeleteProducto(id);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

