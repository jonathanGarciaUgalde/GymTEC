using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_Tec_Cliente.Models { 
 [BsonIgnoreExtraElements]
public class Cliente
    {
    [BsonId]

    public double Cedula { get; set;}
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public double Edad { get; set; }
        public string Nacimiento { get; set; }
        public double Peso { get; set; }
        public double IMC { get; set; }
        public string Direccion { get; set; }

        public string Correo { get; set; }
        public double Pass { get; set; }

       
    }
}
