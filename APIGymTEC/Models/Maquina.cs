using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Maquina
    {
        public string Serie { get; set; }
        public string Marca { get; set; }
        public int Costo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int IdSucursal { get; set; }
    }


    public class MaquinaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Maquina> GetAllMaquina()
        {
            List<Maquina> maquinas = new List<Maquina>();
            return maquinas;
        }
        public void AddMaquina(Maquina maquina)
        {

        }

        public void UpdateMaquina(Maquina maquina)
        {

        }

        public Maquina GetMaquina(int? id)
        {
            Maquina maquina = new Maquina();

            return maquina;
        }

        public void DeleteMaquina(int? id)
        {

        }
    }
}
