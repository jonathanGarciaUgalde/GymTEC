using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Telefono
    {
        public int Tel { get; set; } //PK
        public int IdSucursal { get; set; } //FK
    }

    public class TelefonoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Telefono> GetAllTelefono()
        {
            List<Telefono> telefonos = new List<Telefono>();
            return telefonos;
        }
        public void AddTelefono(Telefono telefono)
        {

        }

        public void UpdateTelefono(Telefono telefono)
        {

        }

        public Telefono GetTelefono(int? id)
        {
            Telefono telefono = new Telefono();

            return telefono;
        }

        public void DeleteTelefono(int? id)
        {

        }
    }
}
