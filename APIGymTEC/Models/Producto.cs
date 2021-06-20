using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APIGymTEC.Utility;

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

        public IEnumerable<Producto> GetAllProducto(int? id)
        {
            List<Producto> productos = new List<Producto>();



            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetallProductos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSucursal", id);

                    con.Open();

                    SqlDataReader rdr = null;

                    try
                    {
                        rdr = cmd.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }


                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Producto prodcuto = new Producto();
                            prodcuto.Codigo = rdr["Codigo"].ToString();
                            prodcuto.Nombre = rdr["Nombre"].ToString();
                            prodcuto.Descripcion = rdr["Descripcion"].ToString();
                            
                            prodcuto.Costo = Convert.ToInt32(rdr["Costo"]);
                            prodcuto.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);
                            productos.Add(prodcuto);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return productos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddProducto(Producto producto)
        {


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //@codigo_barras ,@nombre  ,@descripcion,@cantidad ,@costo ,@idSucursal 
                    //cmd.Parameters.AddWithValue("@Id", sucursal.Id);
                    cmd.Parameters.AddWithValue("@codigo_barras", producto.Codigo);
                    cmd.Parameters.AddWithValue("@nombre ", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Costo", producto.Costo);
                    cmd.Parameters.AddWithValue("@idSucusal", producto.IdSucursal);
                    cmd.Parameters.AddWithValue("@StatementType", "INSERT");

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void UpdateProducto(Producto producto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //@codigo_barras ,@nombre  ,@descripcion,@cantidad ,@costo ,@idSucursal 
                    //cmd.Parameters.AddWithValue("@Id", sucursal.Id);

                    cmd.Parameters.AddWithValue("@nombre ", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);                    
                    cmd.Parameters.AddWithValue("@Costo", producto.Costo);
                    cmd.Parameters.AddWithValue("@StatementType", "UPDATE");

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public Producto GetProducto(int? codigo)
        {
           
            Producto producto = new Producto();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@code", codigo);

                    con.Open();

                    SqlDataReader rdr = null;

                    try
                    {
                        rdr = cmd.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    if (rdr.HasRows)
                    {
                        
                        while (rdr.Read())
                        {
                            producto.Codigo = rdr["Codigo"].ToString();
                            producto.Nombre = rdr["Nombre"].ToString();
                            producto.Descripcion = rdr["Descripcion"].ToString();
                            producto.Costo = Convert.ToInt32(rdr["Costo"]);
                            producto.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);

                           
                        }
                    }
                  
                    return producto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public List <Producto> GetAllProductoXSucursal(int? sucursal)

        {
            List<Producto> productos = new List<Producto>();
            Producto producto = new Producto();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetallProductos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSucursal", sucursal);

                    con.Open();

                    SqlDataReader rdr = null;

                    try
                    {
                        rdr = cmd.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    if (rdr.HasRows)
                    {

                        while (rdr.Read())
                        {
                            producto.Codigo = rdr["Codigo"].ToString();
                            producto.Nombre = rdr["Nombre"].ToString();
                            producto.Descripcion = rdr["Descripcion"].ToString();                            
                            producto.Costo = Convert.ToInt32(rdr["Costo"]);
                            producto.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);
                            productos.Add(producto);

                        
                        }
                    }
                    rdr.Close();
                    con.Close();
                    return productos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProducto(string? codigo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo_barras", codigo);
                    cmd.Parameters.AddWithValue ("@StatementTypecodigo_barras", "DELETE");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void UpdateStockProducto(int? stock,string? codigo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateStockProducto", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                  
                    cmd.Parameters.AddWithValue("@codigo ",codigo);
                    cmd.Parameters.AddWithValue("@stock", stock);
                  

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
