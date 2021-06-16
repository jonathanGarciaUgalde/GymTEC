using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Puesto
    {
        public int Id { get; set; } //PK
        public int Cargo { get; set; } //FK
        public string Empleado { get; set; } // FK
    }


    public class PuestoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Puesto> GetAllPuesto()
        {
            List<Puesto> puestos = new List<Puesto>();
            return puestos;
        }
        public void AddPuesto(Puesto puesto)
        {

        }

        public void UpdatePuesto(Puesto puesto)
        {

        }

        public Puesto GetPuesto(int? id)
        {
            Puesto puesto = new Puesto();

            return puesto;
        }

        public void DeletePuesto(int? id)
        {

        }
    }
}
