using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class ClientePorClase
    {
        public int Id { get; set; }
        public int Clase { get; set; }
        public string Cliente { get; set; }

    }
    //
    public class ClientePorClaseDataAccessLayer
    {
        string connectionString = ConnectionString.CName;


        public void AddClientePorClase(ClientePorClase clientePorClase)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspInsertarClientePorClase", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Clase", clientePorClase.Clase);
                    cmd.Parameters.AddWithValue("@Cliente", clientePorClase.Cliente);
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
        public IEnumerable<ClaseCompleta> actividadesProxima(string cedula)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    List<ClaseCompleta> clases = new List<ClaseCompleta>();
                    SqlCommand cmd = new SqlCommand("uspMostrarActividadesProximas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cliente", cedula);
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

    }


}