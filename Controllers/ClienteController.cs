using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Gym_Tec_Cliente.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym_Tec_Cliente.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        Server service = new Server();

        
        [HttpPost]
        public async Task<IActionResult>insertCliente(Cliente cliente){

                MongoClient dbClient = new MongoClient(service.initServer());
                var db = dbClient.GetDatabase(service.initCluster());
                var col = db.GetCollection<BsonDocument>(service.initDataBase());
                string encryptedPass = MD5Encoding.MD5Encryption(cliente.Pass);
          
            BsonDocument doc = new BsonDocument
            {
                {"_id",cliente.Cedula},
                {"nombre", cliente.Nombre},
                {"apellidos", cliente.Apellidos},
                {"edad", cliente.Edad},
                {"nacimiento", cliente.Nacimiento},
                {"peso", cliente.Peso},
                 {"IMC", cliente.IMC},
                { "correo",cliente.Correo},
                { "direccion",cliente.Direccion},
                {"pass", encryptedPass}
            };

            try
            {
                col.InsertOne(doc);
                return Ok();
            }
            catch {
                return BadRequest();
            }
        }
        [HttpPost("{cedula}")]
        public async Task<IActionResult> getClienteData(int cedula)
        {
            try
            {
                MongoClient dbClient = new MongoClient(service.initServer());
                var db = dbClient.GetDatabase(service.initCluster());
              
                var builder = Builders<Cliente>.Filter;
                var filter1 = builder.Eq(u => u.Cedula, cedula);
             
                var fullFilter = builder.And(new[] { filter1 });
                var col = db.GetCollection<Cliente>(service.initDataBase());
               

                var client = col.Find(fullFilter).FirstOrDefault().ToJson();
                return Ok(client);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
