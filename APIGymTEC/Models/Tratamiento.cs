using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSucursal { get; set; }

    }
    public class TratamientoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

     
        public void AddTratamiento(Tratamiento tratamiento)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCRUDTratamiento", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre",tratamiento.Nombre );
                    cmd.Parameters.AddWithValue("@idSucursal",tratamiento.IdSucursal);
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

        public void UpdateTratamiento(Tratamiento tratamiento)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCRUDTratamiento", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", tratamiento.Nombre);
                    cmd.Parameters.AddWithValue("@StatementType", "DELETE");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tratamiento GetTratamiento(int? id)
      
        {
            Tratamiento tratamiento = new Tratamiento();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCRUDTratamiento", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@StatementType", "GET");
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
                            tratamiento.Id = Convert.ToInt32(rdr["Id"]);
                            tratamiento.Nombre = rdr["Nombre"].ToString();
                            tratamiento.IdSucursal= Convert.ToInt32(rdr["IdSucursal"]);
                            
                        }
                    }
                    return tratamiento;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteTratamiento(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCRUDTratamiento", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@StatementType", "DELETE");
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
