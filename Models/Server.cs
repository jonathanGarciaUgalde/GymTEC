using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_Tec_Cliente.Models
{
    public class Server
    {
        public Server()
        {
            initServer();
            initCluster();
            initDataBase();

        }

        public string initServer() {
            return "mongodb + srv://root:root@cluster0.38ggm.mongodb.net/test";
        }
        public string initCluster() {
            return "GymTEC";
        }
        public string initDataBase() {
            return "clientes";
        }

        
    }
}
