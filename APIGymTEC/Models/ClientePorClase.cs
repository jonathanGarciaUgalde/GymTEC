using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class ClientePorClase
    {
        public int Id { get; set; }
        public int Clase { get; set; }
        public string Cliente { get; set; }
        
    }

    public class ClientePorClaseDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<ClientePorClase> GetAllClientePorClase()
        {
            List<ClientePorClase> clientesPorClase = new List<ClientePorClase>();
            return clientesPorClase;
        }
        public void AddClientePorClase(ClientePorClase clientePorClase)
        {

        }

        public void UpdateClientePorClase(ClientePorClase clientePorClase)
        {

        }

        public ClientePorClase GetClientePorClase(int? id)
        {
            ClientePorClase clientePorClase = new ClientePorClase();

            return clientePorClase;
        }

        public void DeleteClientePorClase(int? id)
        {

        }
    }
}
