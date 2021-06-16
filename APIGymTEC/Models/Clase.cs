using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Clase
    {
        public int Id { get; set; } //PK
        public int Capacidad { get; set; }
        public bool EsGrupal { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public int Tipo { get; set; } //FK
        public string Empleado { get; set; } //FK
        public int IdSucursal { get; set; } // FK
    }

    public class ClaseDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Clase> GetAllClase()
        {
            List<Clase> clases = new List<Clase>();
            return clases;
        }
        public void AddClase(Clase clase)
        {

        }

        public void UpdateClase(Clase clase)
        {

        }

        public Clase GetClase(int? id)
        {
            Clase clase = new Clase();

            return clase;
        }

        public void DeleteClase(int? id)
        {

        }
    }

}
