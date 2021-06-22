using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    //En esta Clase se  realiza  la construccion del modelo que se encarga de las gestiones  de los tratamientos  que
    // insertan  en diversas  sucursales
    // ademas  se puden realizar  consultas  sobre los tratamientos,
    // además de los tratamientos asociados a sucursal
    public class Tratamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSucursal { get; set; }

    }
    public class TratamientoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        /*
       Metodo que  permite  al admimistrador  agragar tratamientos  a las tiendas existentes
       recibe  un objeto d tipo tratamientos  y lo envia a la capa de datos a ser insertado 
       y mediante el procedimiento almacenado respectivo se
       manda a obtener insertar  la maquina asosciada a esa tienda en la base de datos
       */
        public void AddTratamiento(Tratamiento tratamiento)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspCRUDTratamiento", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", tratamiento.Nombre);
                    cmd.Parameters.AddWithValue("@idSucursal", tratamiento.IdSucursal);
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
        /*
             Metodo que  permite  al admimistrador  poder realizar actualizaciones los tratamientosexistentes
             recibe recibe  los valores autorizados para editar  y los actualiza
               mediante el procedimiento almacenado respectivo se
             manda a obtener actualizar los tratamientos  que tienen esa identificación
             */
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

        /*
            Metodo que  permite  al admimistrador obtener el tratamiento
           recibe el identificador y retorna los parametros  asociados a ese tratamiento
            */
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
                            tratamiento.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);
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
        /*
           Metodo que  permite  al adminstradorr eliminar tramientos insertando identificadores validos
           */
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
