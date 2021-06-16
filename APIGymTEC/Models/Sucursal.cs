using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using APIGymTEC.Utility;

namespace APIGymTEC.Models
{
    public class Sucursal
    {
        public int Id { get; set; }
        public bool Tienda { get; set; }
        public bool Spa { get; set; }
        public int Capacidad { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

    }


    public class SucursalDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Sucursal> GetAllSucursales()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            return sucursales;
        }
        public void AddSucursal(Sucursal sucursal)
        {

        }

        public void UpdateStudent(Sucursal sucursal)
        {

        }

        public Sucursal GetSucursal(int? id)
        {
            Sucursal sucursal= new Sucursal();

            return sucursal;
        }

        public void DeleteSucursal(int? id)
        {

        }
    }
}
