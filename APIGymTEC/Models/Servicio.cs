using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Servicio
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdSucursal { get; set; } //FK
    }

    public class ServicioDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Servicio> GetAllServicio()
        {
            List<Servicio> servicios = new List<Servicio>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectServicios", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", -1);

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
                            Servicio servicio = new Servicio();

                            servicio.Id = Convert.ToInt32(rdr["Id"]);
                            servicio.Nombre = rdr["Nombre"].ToString();
                            servicio.Nombre = rdr["Descripcion"].ToString();
                            servicio.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);


                            servicios.Add(servicio);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return servicios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Servicio GetServicio(int? id)
        {
            Servicio servicio = new Servicio();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectServicios", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

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
                            servicio.Id = Convert.ToInt32(rdr["Id"]);
                            servicio.Nombre = rdr["Nombre"].ToString();
                            servicio.Nombre = rdr["Descripcion"].ToString();
                            servicio.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);
                        }
                    }
                    return servicio;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddServicio(Servicio servicio)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspInsertServicio", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", servicio.Descripcion);
                    cmd.Parameters.AddWithValue("@IdSucursal", servicio.IdSucursal);


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

        public void UpdateServicio(Servicio servicio)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateServicio", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", servicio.Id);
                    cmd.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", servicio.Descripcion);
                    //cmd.Parameters.AddWithValue("@IdSucursal", servicio.IdSucursal);

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


        public void DeleteServicio(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspDeleteServicio", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
