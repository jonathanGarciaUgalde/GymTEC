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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public int IdSucursal { get; set; }
        public int IdPlanilla { get; set; }
        public string Cargo { get; set; }

        public string Password { get; set; } // Para el insert me parece

    }
}
