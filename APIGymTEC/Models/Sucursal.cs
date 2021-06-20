using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using APIGymTEC.Utility;

namespace APIGymTEC.Models
{
    public class Sucursal
    {
        public int Id { get; set; }
        public bool Tienda { get; set; }
        public bool Spa { get; set; }
        public int Capacidad { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string FechaApertura { get; set; }
        public string Horario { get; set; }

    }
    
    public class SucursalDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Sucursal> GetAllSucursales() //GET 
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectSucursal", con);
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
                            Sucursal sucursal = new Sucursal();
                            sucursal.Id = Convert.ToInt32(rdr["Id"]);
                            sucursal.Nombre = rdr["Nombre"].ToString();
                            sucursal.Capacidad = Convert.ToInt32(rdr["Capacidad"]);
                            sucursal.Provincia = rdr["Provincia"].ToString();
                            sucursal.Canton = rdr["Canton"].ToString();
                            sucursal.Distrito = rdr["Distrito"].ToString();
                            sucursal.Tienda = (bool)rdr["Tienda"];
                            sucursal.Spa = (bool)rdr["Spa"];
                            sucursal.FechaApertura = rdr["FechaApertura"].ToString();
                            sucursal.Horario = rdr["Horario"].ToString();


                            sucursales.Add(sucursal);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return sucursales;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Sucursal GetSucursal(int? id) // GET
        {
            Sucursal sucursal = new Sucursal();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectSucursal", con);
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
                            sucursal.Id = Convert.ToInt32(rdr["Id"]);
                            sucursal.Nombre = rdr["Nombre"].ToString();
                            sucursal.Capacidad = Convert.ToInt32(rdr["Capacidad"]);
                            sucursal.Provincia = rdr["Provincia"].ToString();
                            sucursal.Canton = rdr["Canton"].ToString();
                            sucursal.Distrito = rdr["Distrito"].ToString();
                            sucursal.Tienda = (bool)rdr["Tienda"];
                            sucursal.Spa = (bool)rdr["Spa"];
                            sucursal.FechaApertura = rdr["FechaApertura"].ToString();
                            sucursal.Horario = rdr["Horario"].ToString();
                        }
                    }
                    return sucursal;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddSucursal(Sucursal sucursal) //CREATE
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspInsertarSucursal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
<<<<<<< Updated upstream
                    
                    cmd.Parameters.AddWithValue("@Tienda", false);
                    cmd.Parameters.AddWithValue("@Spa", false);
=======

                    //cmd.Parameters.AddWithValue("@Id", sucursal.Id);
                    cmd.Parameters.AddWithValue("@Tienda", sucursal.Tienda);
                    cmd.Parameters.AddWithValue("@Spa", sucursal.Spa);
>>>>>>> Stashed changes
                    cmd.Parameters.AddWithValue("@Capacidad", sucursal.Capacidad);
                    cmd.Parameters.AddWithValue("@Nombre", sucursal.Nombre);
                    cmd.Parameters.AddWithValue("@Provincia", sucursal.Provincia);
                    cmd.Parameters.AddWithValue("@Canton", sucursal.Canton);
                    cmd.Parameters.AddWithValue("@Distrito", sucursal.Distrito);
                    cmd.Parameters.AddWithValue("@FechaApertura", sucursal.FechaApertura);
                    cmd.Parameters.AddWithValue("@Horario", sucursal.Horario);


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

        public void UpdateSucursal(Sucursal sucursal) // UPDATE
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateSucursal", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", sucursal.Id);
                    cmd.Parameters.AddWithValue("@Capacidad", sucursal.Capacidad);
                    cmd.Parameters.AddWithValue("@Nombre", sucursal.Nombre);
                    cmd.Parameters.AddWithValue("@Provincia", sucursal.Provincia);
                    cmd.Parameters.AddWithValue("@Canton", sucursal.Canton);
                    cmd.Parameters.AddWithValue("@Distrito", sucursal.Distrito);
                    cmd.Parameters.AddWithValue("@FechaApertura", sucursal.FechaApertura);
                    cmd.Parameters.AddWithValue("@Horario", sucursal.Horario);

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
    
        public void DeleteSucursal(int? id) //DELETE
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspDeleteSucursal", con);
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
