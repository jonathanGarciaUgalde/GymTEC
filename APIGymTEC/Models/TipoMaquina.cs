using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public void AddTipoMaquina(TipoMaquina tipo) //CREATE
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDTipoMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo", tipo.Tipo);
                    cmd.Parameters.AddWithValue("@descripcion", tipo.Descripcion);
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

        public void UpdateTipoMaquina(TipoMaquina tipoMaquina)
        { 
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDTipoMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tipo", tipoMaquina.Tipo);
                    cmd.Parameters.AddWithValue("@Descripcion", tipoMaquina.Descripcion);
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
        public TipoMaquina GetTipoMaquina(string? tipo)
        {
            TipoMaquina tipoMaquina = new TipoMaquina();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspGetTipoMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
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
                            tipoMaquina.Tipo = rdr["Tipo"].ToString();
                            tipoMaquina.Descripcion = rdr["Descripcion"].ToString();
                        
                        }
                    }
                    return tipoMaquina;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteTipoMaquina(string? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDTipoMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo", id);
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
