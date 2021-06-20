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

        public IEnumerable<Tratamiento> GetAllTratamiento()
        {
            List<Tratamiento> tratamientos = new List<Tratamiento>();
            return tratamientos;
        }
        public void AddTratamiento(Tratamiento tratamiento)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(" uspInsertarTratamiento", con);
                    cmd.CommandType = CommandType.StoredProcedure; @idTratamiento DECIMAL,
    // @nombreTratamiento VARCHAR(MAX),
    //@idSpa VARCHAR(MAX),
    //@existeSpa BIT OUTPUT
    //@existeTratamiento BIT OUTPUT
                    cmd.Parameters.AddWithValue("@nombre ", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@Costo", producto.Costo);
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
    

        public void UpdateTratamiento(Tratamiento tratamiento)
        {

        }

        public Tratamiento GetTratamiento(int? id)
        {
            Tratamiento tratamiento = new Tratamiento();

            return tratamiento;
        }

        public void DeleteTratamiento(int? id)
        {

        }
    } 
}
