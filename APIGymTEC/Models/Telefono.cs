using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Telefono
    {
        public int Tel { get; set; } //PK
        public int IdSucursal { get; set; } //FK
    }

    public class TelefonoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Telefono> GetAllTelefono()
        {
            List<Telefono> telefonos = new List<Telefono>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectTelefono", con);
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
                            Telefono telefono = new Telefono();
                            telefono.Tel = Convert.ToInt32(rdr["Tel"]);
                            telefono.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);


                            telefonos.Add(telefono);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return telefonos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<Telefono> GetTelefono(int? IdSucursal)
        {
            List<Telefono> telefonos = new List<Telefono>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectTelefono", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSucursal", IdSucursal);

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
                            Telefono telefono = new Telefono();
                            telefono.Tel = Convert.ToInt32(rdr["Tel"]);
                            telefono.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);


                            telefonos.Add(telefono);
                        }
                    }


                    rdr.Close();
                    con.Close();
                    return telefonos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddTelefono(Telefono telefono)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspInsertTelefono", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@Id", sucursal.Id);
                    cmd.Parameters.AddWithValue("@Tel", telefono.Tel);
                    cmd.Parameters.AddWithValue("@IdSucursal", telefono.IdSucursal);


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











        public void UpdateTelefono(Telefono telefono)
        {

        }

        public void DeleteTelefono(int? id)
        {

        }
    }
}
