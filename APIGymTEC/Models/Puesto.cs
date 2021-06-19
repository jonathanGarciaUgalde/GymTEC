using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Puesto
    {
        public int Id { get; set; } //PK
        public int Cargo { get; set; } //FK
        public string Empleado { get; set; } // FK
    }


    public class PuestoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Puesto> GetAllPuesto()
        {
            List<Puesto> puestos = new List<Puesto>();
            return puestos;
        }
        public void AddPuesto(Puesto puesto)
        {

        }

        public void UpdatePuesto(Puesto puesto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateSucursal", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", puesto.Id);
                    cmd.Parameters.AddWithValue("@Empleado", puesto.Empleado);
                    cmd.Parameters.AddWithValue("@Cargo", puesto.Cargo);

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

        public Puesto GetPuesto(int? id)
        {
            Puesto puesto = new Puesto();

            return puesto;
        }

        public void DeletePuesto(int? id)
        {

        }
    }
}
