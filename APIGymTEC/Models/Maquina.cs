using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Maquina
    {
        public string Serie { get; set; }
        public string Marca { get; set; }
        public int Costo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public int IdSucursal { get; set; }
    }


    public class MaquinaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Maquina> GetInventarioXtienda(int? id)
        {
            List<Maquina> maquinas = new List<Maquina>();



            try
            {
              

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(" uspGetAllMaquinas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSucursal", id);
                    
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
                            //  Serie ,Marca, Costo, Descripcion,Tipo, IdSucursal

                            Maquina maquina = new Maquina();
                            maquina.Serie = rdr["Serie"].ToString();
                            maquina.Marca = rdr["Marca"].ToString();
                            maquina.Costo = Convert.ToInt32(rdr["Costo"]);
                            maquina.Descripcion = rdr["Descripcion"].ToString();

                            maquina.Tipo = rdr["Tipo"].ToString();
                            maquina.Costo = Convert.ToInt32(rdr["Costo"]);
                            maquina.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);
                           maquinas.Add(maquina);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return maquinas;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void AddMaquina(Maquina maquina)
        {


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;

          
                     cmd.Parameters.AddWithValue(" @numero_serie ", maquina.Serie);
                    cmd.Parameters.AddWithValue("@marca ", maquina.Marca);
                    cmd.Parameters.AddWithValue("@costo", maquina.Costo);
                    cmd.Parameters.AddWithValue("@descripcion",maquina.Descripcion);
                    cmd.Parameters.AddWithValue("@tipo", maquina.Tipo);
                    cmd.Parameters.AddWithValue("@IdSucusali", maquina.IdSucursal);
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

    

    public void UpdateMaquina(Maquina maquina)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;
               
                    cmd.Parameters.AddWithValue("@marca ", maquina.Marca);
                    cmd.Parameters.AddWithValue("@costo", maquina.Costo);
                    cmd.Parameters.AddWithValue("@descripcion", maquina.Descripcion);
                    cmd.Parameters.AddWithValue("@Tipo", maquina.Tipo);
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

        public Maquina GetMaquina(int? codigo)

        {


            Maquina maquina = new Maquina();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@storedSerialNumber", codigo);

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
                            maquina.Serie = rdr["Serie"].ToString();
                            maquina.Marca = rdr["Marca"].ToString();
                            maquina.Costo = Convert.ToInt32(rdr["Costo"]);
                            maquina.Descripcion = rdr["Descripcion"].ToString();

                            maquina.Tipo = rdr["Tipo"].ToString();
                            maquina.Costo = Convert.ToInt32(rdr["Costo"]);
                            maquina.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);


                        }
                    }

                    return maquina;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMaquina(int? id)
        {


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCUDMaquina", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@numero_serie ", id);
                    cmd.Parameters.AddWithValue("@StatementType","DELETE");
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
