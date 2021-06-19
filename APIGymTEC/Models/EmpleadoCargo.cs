using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class EmpleadoCargo
    {
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdSucursal { get; set; }

        public int IdPlanilla { get; set; }
        public string NombrePlanilla { get; set; }
    }
}
