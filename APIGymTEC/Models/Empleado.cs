using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Empleado
    {
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdSucursal { get; set; }
    }

    public class EmpleadoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Empleado> GetAllEmpleado()
        {
            List<Empleado> empleados = new List<Empleado>();
            return empleados;
        }
        public void AddEmpleado(Empleado empleado)
        {

        }

        public void UpdateEmpleado(Empleado empleado)
        {

        }

        public Empleado GetEmpleado(int? id)
        {
            Empleado empleado = new Empleado();

            return empleado;
        }

        public void DeleteEmpleado(int? id)
        {

        }
    }
}
