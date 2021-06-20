using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class ClaseCompleta
    {
        public int IdSucursal { get; set; }//FROM CLASE
        public int Capacidad { get; set; }//FROM CLASE
        public bool EsGrupal { get; set; }//FROM CLASE
        public string Dia { get; set; }//FROM CLASE
        public string HoraInicio { get; set; }//FROM CLASE
        public string HoraFinal { get; set; } //FROM CLASE
        public string NombreServicio { get; set; } // FROM SERVICIO
        public string NombreEmpleado { get; set; } // FROM EMPLEADO

    }
}
