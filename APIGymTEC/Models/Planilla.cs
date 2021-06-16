using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Planilla
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Mensual { get; set; }
        public int Hora { get; set; }
        public int Clase { get; set; }
        public int IdSucursal { get; set; }
    }


    public class PlanillaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Planilla> GetAllPlanilla()
        {
            List<Planilla> planillas = new List<Planilla>();
            return planillas;
        }
        public void AddPlanilla(Planilla planilla)
        {

        }

        public void UpdatePlanilla(Planilla planilla)
        {

        }

        public Planilla GetPlanilla(int? id)
        {
            Planilla planilla = new Planilla();

            return planilla;
        }

        public void DeletePlanilla(int? id)
        {

        }
    }
}
