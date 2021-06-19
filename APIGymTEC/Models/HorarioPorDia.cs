using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class HorarioPorDia
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public int IdSucursal { get; set; }
    }


    public class HorarioPorDiaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<HorarioPorDia> GetAllHorarioPorDia()
        {
            List<HorarioPorDia> horariosPorDia = new List<HorarioPorDia>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectHorarios", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSucursal", "-1");

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
                            HorarioPorDia horarioPorDia= new HorarioPorDia();

                            horarioPorDia.Id = Convert.ToInt32(rdr["Id"]);                            
                            horarioPorDia.Dia = rdr["Dia"].ToString();
                            horarioPorDia.HoraApertura = rdr["HoraApertura"].ToString();
                            horarioPorDia.HoraCierre = rdr["HoraCierre"].ToString();
                            horarioPorDia.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);

                            horariosPorDia.Add(horarioPorDia);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return horariosPorDia;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<HorarioPorDia> GetHorarioPorDia(int? idSucursal)
        {
            List<HorarioPorDia> horariosPorDia = new List<HorarioPorDia>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectSucursal", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);

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
                            HorarioPorDia horarioPorDia = new HorarioPorDia();

                            horarioPorDia.Id = Convert.ToInt32(rdr["Id"]);
                            horarioPorDia.Dia = rdr["Dia"].ToString();
                            horarioPorDia.HoraApertura = rdr["HoraApertura"].ToString();
                            horarioPorDia.HoraCierre = rdr["HoraCierre"].ToString();
                            horarioPorDia.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);

                            horariosPorDia.Add(horarioPorDia);
                        }
                    }
                    return horariosPorDia;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddHorarioPorDia(HorarioPorDia horarioPorDia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspInsertHorarioPorDia", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Dia", horarioPorDia.Dia);
                    cmd.Parameters.AddWithValue("@HoraApertura", horarioPorDia.HoraApertura);
                    cmd.Parameters.AddWithValue("@HoraCierre", horarioPorDia.HoraCierre);
                    cmd.Parameters.AddWithValue("@IdSucursal", horarioPorDia.IdSucursal);


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


        public void UpdateHorarioPorDia(HorarioPorDia horarioPorDia)
        {

        }


        public void DeleteHorarioPorDia(int? id)
        {

        }
    }
}
