using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class HorarioPorDia
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public int IdSucursal { get; set; }
    }


    public class HorarioPorDiaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<HorarioPorDia> GetAllHorarioPorDia()
        {
            List<HorarioPorDia>horariosPorDia = new List<HorarioPorDia>();
            return horariosPorDia;
        }
        public void AddHorarioPorDia(HorarioPorDia horarioPorDia)
        {

        }

        public void UpdateHorarioPorDia(HorarioPorDia horarioPorDia)
        {

        }

        public HorarioPorDia GetHorarioPorDia(int? id)
        {
            HorarioPorDia horarioPorDia = new HorarioPorDia();

            return horarioPorDia;
        }

        public void DeleteHorarioPorDia(int? id)
        {

        }
    }
}
