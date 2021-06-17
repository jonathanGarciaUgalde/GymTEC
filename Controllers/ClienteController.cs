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
        public async Task<IActionResult> insertCliente(Cliente cliente)
        {

            MongoClient dbClient = new MongoClient(service.initServer());
            var db = dbClient.GetDatabase(service.initCluster());
            var col = db.GetCollection<BsonDocument>(service.initDataBase());
            string encryptedPass = MD5Encoding.MD5Encryption(cliente.Pass);

            BsonDocument doc = new BsonDocument
            {
                {"cedula",cliente.Cedula},
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
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]

        //https://localhost:*puerto*/api/Cliente/LoginCliente
        //{  "User":*correo*, "Pass":*contraseña*}


        public async Task<IActionResult>LoginCliente(LoginInfo usuario)
        {
            var connectionString = service.initServer();
            var mongoClient = new MongoClient(connectionString);
            var dataBase = mongoClient.GetDatabase(service.initCluster());
            var collection = dataBase.GetCollection<BsonDocument>(service.initDataBase());
            var filter1 = Builders<BsonDocument>.Filter.Eq("correo", usuario.User);
            var filter2 = Builders<BsonDocument>.Filter.Eq("pass", MD5Encoding.MD5Encryption( usuario.Pass));
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var document = collection.Find(filter1 & filter2).Project(projection).FirstOrDefault();
            List<Object> respuesta = new List<Object>();
            if (document != null)
            {
                var correo = document.GetValue("correo").AsString;
                var pass = document.GetValue("pass").AsString;
                if (correo.Equals(usuario.User) && pass.Equals(MD5Encoding.MD5Encryption(usuario.Pass)))
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
                return Ok(false);


        }

        //https://localhost:*puerto*/api/Cliente/GetCliente/*numero de cedula*
        [HttpPost("{cedula}")]
        public async Task<IActionResult> GetCliente(int cedula)
        {
            var connectionString = service.initServer();
            var mongoClient = new MongoClient(connectionString);
            var dataBase = mongoClient.GetDatabase(service.initCluster());
            var collection = dataBase.GetCollection<BsonDocument>(service.initDataBase());
            var filter1 = Builders<BsonDocument>.Filter.Eq("cedula", cedula);

            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var document = collection.Find(filter1).Project(projection).FirstOrDefault();
            Cliente cliente = new Cliente()
            {
                Cedula = document.GetValue("cedula").AsInt32,
                Nombre = document.GetValue("nombre").AsString,
                Apellidos = document.GetValue("apellidos").AsString,
                Edad = document.GetValue("edad").AsInt32,
                Nacimiento = document.GetValue("nacimiento").AsString,
                IMC = document.GetValue("IMC").AsDouble,
                Correo = document.GetValue("correo").AsString,
                Direccion = document.GetValue("direccion").AsString };

            
            return Ok(cliente);


        }
    }
}
