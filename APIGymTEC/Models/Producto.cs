using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }        
        public int Costo { get; set; }
        public int IdSucursal { get; set; }
    }

    public class ProductoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Producto> GetAllProducto()
        {
            List<Producto> productos = new List<Producto>();
            return productos;
        }
        public void AddProducto(Producto producto)
        {

        }

        public void UpdateProducto(Producto producto)
        {

        }

        public Producto GetProducto(int? id)
        {
            Producto producto = new Producto();

            return producto;
        }

        public void DeleteProducto(int? id)
        {

        }
    }


}
