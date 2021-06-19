using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Empleado
    {
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdSucursal { get; set; }
    }

    public class EmpleadoDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<EmpleadoCargo> GetAllEmpleado()
        {
            List<EmpleadoCargo> empleados = new List<EmpleadoCargo>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectEmpleado", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", "-1");

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
                            EmpleadoCargo empleadoCargo = new EmpleadoCargo();                            
                            empleadoCargo.Cedula = rdr["Cedula"].ToString();
                            empleadoCargo.Email = rdr["Email"].ToString();
                            empleadoCargo.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);
                            
                            empleadoCargo.IdPlanilla = Convert.ToInt32(rdr["IdPlanilla"]);
                            empleadoCargo.NombrePlanilla= rdr["NombrePlanilla"].ToString();
                           


                            empleados.Add(empleadoCargo);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public EmpleadoCargo GetEmpleado(string? cedula)
        {
            EmpleadoCargo empleadoCargo = new EmpleadoCargo();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspSelectEmpleado", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

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
                            empleadoCargo.Cedula = rdr["Cedula"].ToString();
                            empleadoCargo.Email = rdr["Email"].ToString();
                            empleadoCargo.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);

                            empleadoCargo.IdPlanilla = Convert.ToInt32(rdr["IdPlanilla"]);
                            empleadoCargo.NombrePlanilla = rdr["NombrePlanilla"].ToString();
                        }
                    }
                    return empleadoCargo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddEmpleado(EmpleadoCargo empleadoCargo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspInsertEmpleado", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Cedula", empleadoCargo.Cedula);
                    cmd.Parameters.AddWithValue("@Email", empleadoCargo.Email);
                    cmd.Parameters.AddWithValue("@Password", empleadoCargo.Password);
                    cmd.Parameters.AddWithValue("@IdSucursal", empleadoCargo.IdSucursal);
                    cmd.Parameters.AddWithValue("@Cargo", empleadoCargo.IdPlanilla);

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

        public void UpdateEmpleado(EmpleadoCargo empleadoCargo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateEmpleado", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cedula", empleadoCargo.Cedula);
                    cmd.Parameters.AddWithValue("@Email", empleadoCargo.Email);
                    cmd.Parameters.AddWithValue("@Password", empleadoCargo.Password);
                    cmd.Parameters.AddWithValue("@IdSucursal", empleadoCargo.IdSucursal);
                    cmd.Parameters.AddWithValue("@Cargo", empleadoCargo.IdPlanilla);
                    

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
        public void DeleteEmpleado(string? cedula)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspDeleteEmpleado", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
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
