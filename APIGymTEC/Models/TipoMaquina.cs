using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class TipoMaquina
    {
        public string Tipo { get; set; } //PK
        public string  Descripcion { get; set; } //FK
    }


    public class TipoMaquinaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<TipoMaquina> GetAllTipoMaquina()
        {
            List<TipoMaquina> tipoMaquinas = new List<TipoMaquina>();
            return tipoMaquinas;
        }
        public void AddTipoMaquina(TipoMaquina tipoMaquina)
        {

        }

        public void UpdateTipoMaquina(TipoMaquina tipoMaquina)
        {

        }

        public TipoMaquina GetTipoMaquina(int? id)
        {
            TipoMaquina tipoMaquina = new TipoMaquina();

            return tipoMaquina;
        }

        public void DeleteTipoMaquina(int? id)
        {

        }
    }
}
