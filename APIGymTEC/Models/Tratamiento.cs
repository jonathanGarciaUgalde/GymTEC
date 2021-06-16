using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSucursal { get; set; }
    }

    public class TratamientoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Tratamiento> GetAllTratamiento()
        {
            List<Tratamiento> tratamientos = new List<Tratamiento>();
            return tratamientos;
        }
        public void AddTratamiento(Tratamiento tratamiento)
        {

        }

        public void UpdateTratamiento(Tratamiento tratamiento)
        {

        }

        public Tratamiento GetTratamiento(int? id)
        {
            Tratamiento tratamiento = new Tratamiento();

            return tratamiento;
        }

        public void DeleteTratamiento(int? id)
        {

        }
    } 
}
