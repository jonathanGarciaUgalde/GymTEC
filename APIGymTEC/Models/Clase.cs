using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Clase
    {
        public int Id { get; set; } //PK
        public int Capacidad { get; set; }
        public bool EsGrupal { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public int Tipo { get; set; } //FK
        public string Empleado { get; set; } //FK
        public int IdSucursal { get; set; } // FK
    }

    public class ClaseDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<ClaseCompleta> GetClasePorSucursal(int? idSucursal)
        {
            List<ClaseCompleta> clases = new List<ClaseCompleta>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspBusquedaClaseXSucursal", con);
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
                            ClaseCompleta claseCompleta = new ClaseCompleta();
                            claseCompleta.Capacidad = Convert.ToInt32(rdr["Capacidad"]);
                            claseCompleta.EsGrupal = (bool)rdr["EsGrupal"];
                            claseCompleta.Dia = rdr["Dia"].ToString();
                            claseCompleta.HoraInicio = rdr["HoraInicio"].ToString();
                            claseCompleta.HoraFinal = rdr["HoraFinal"].ToString();
                            claseCompleta.NombreServicio = rdr["NombreServicio"].ToString();
                            claseCompleta.NombreEmpleado = rdr["NombreEmpleado"].ToString();
                            claseCompleta.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);



                            clases.Add(claseCompleta);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return clases;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ClaseCompleta> GetClasePorTipo(string? tipo)
        {
            List<ClaseCompleta> clases = new List<ClaseCompleta>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspBusquedaClaseXTipo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoClase", tipo);

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
                            ClaseCompleta claseCompleta = new ClaseCompleta();
                            claseCompleta.Capacidad = Convert.ToInt32(rdr["Capacidad"]);
                            claseCompleta.EsGrupal = (bool)rdr["EsGrupal"];
                            claseCompleta.Dia = rdr["Dia"].ToString();
                            claseCompleta.HoraInicio = rdr["HoraInicio"].ToString();
                            claseCompleta.HoraFinal = rdr["HoraFinal"].ToString();
                            claseCompleta.NombreServicio = rdr["NombreServicio"].ToString();
                            claseCompleta.NombreEmpleado = rdr["NombreEmpleado"].ToString();
                            claseCompleta.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);



                            clases.Add(claseCompleta);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return clases;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void AddClase(Clase clase)
        {

        }

        public void UpdateClase(Clase clase)
        {

        }


        public void DeleteClase(int? id)
        {

        }
    }

}
