using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Servicio
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdSucursal { get; set; } //FK
    }

    public class ServicioDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Servicio> GetAllServicio()
        {
            List<Servicio> servicios = new List<Servicio>();
            return servicios;
        }
        public void AddServicio(Servicio servicio)
        {

        }

        public void UpdateServicio(Servicio servicio)
        {

        }

        public Servicio GetServicio(int? id)
        {
            Servicio servicio = new Servicio();

            return servicio;
        }

        public void DeleteServicio(int? id)
        {

        }
    }
}
