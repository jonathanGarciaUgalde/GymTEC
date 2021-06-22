﻿using APIGymTEC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIGymTEC.Models
{
    public class Planilla
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public int Mensual { get; set; }
        public int Hora { get; set; }
        public int Clase { get; set; }
        public int Cantidad { get; set; }
        public string Cedula { get; set; }
        public int IdSucursal { get; set; }
    }


    public class PlanillaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Planilla> GetAllPlanilla()
        {
            List<Planilla> planillas = new List<Planilla>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("obtenerPlanilla", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", -1);

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
                            Planilla planilla = new Planilla();
                            planilla.Id = Convert.ToInt32(rdr["Id"]);
                            planilla.Cargo = rdr["Cargo"].ToString();

                            planilla.Mensual = Convert.ToInt32(rdr["Mensual"]);
                            planilla.Hora = Convert.ToInt32(rdr["Hora"]);
                            planilla.Clase = Convert.ToInt32(rdr["Clase"]);

                            planilla.Cantidad = Convert.ToInt32(rdr["Cantidad"]);
                            planilla.Cedula = rdr["Cedula"].ToString();
                            planilla.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);

                            planillas.Add(planilla);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return planillas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Planilla GetPlanilla(int? id)
        {
            Planilla planilla = new Planilla();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("obtenerPlanilla", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

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
                            planilla.Id = Convert.ToInt32(rdr["Id"]);
                            planilla.Cargo = rdr["Cargo"].ToString();

                            planilla.Mensual = Convert.ToInt32(rdr["Mensual"]);
                            planilla.Hora = Convert.ToInt32(rdr["Hora"]);
                            planilla.Clase = Convert.ToInt32(rdr["Clase"]);

                            planilla.Cantidad = Convert.ToInt32(rdr["Cantidad"]);
                            planilla.Cedula = rdr["Cedula"].ToString();
                            planilla.IdSucursal = Convert.ToInt32(rdr["IdSucursal"]);

                        }
                    }
                    return planilla;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CalculoPlanilla> GetCalculoPlanilla(string cargo) 
        {
            List<CalculoPlanilla> planillas = new List<CalculoPlanilla>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("planilla", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cargo", cargo);

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
                            CalculoPlanilla planilla = new CalculoPlanilla();

                            planilla.Monto = Convert.ToInt32(rdr["Monto"]);


                            planillas.Add(planilla);
                        }
                    }

                    rdr.Close();
                    con.Close();
                    return planillas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public void AddPlanilla(Planilla planilla)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertPlanilla", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cargo", planilla.Cargo);

                    cmd.Parameters.AddWithValue("@Mensual", planilla.Mensual);
                    cmd.Parameters.AddWithValue("@Hora", planilla.Hora);
                    cmd.Parameters.AddWithValue("@Clase", planilla.Clase);

                    cmd.Parameters.AddWithValue("@Cantidad", planilla.Cantidad);
                    cmd.Parameters.AddWithValue("@Cedula", planilla.Cedula);
                    cmd.Parameters.AddWithValue("@IdSucursal", planilla.IdSucursal);

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

        public void UpdatePlanilla(Planilla planilla)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("actualizarPlanilla", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", planilla.Id);
                    cmd.Parameters.AddWithValue("@Cargo", planilla.Cargo);

                    cmd.Parameters.AddWithValue("@Mensual", planilla.Mensual);
                    cmd.Parameters.AddWithValue("@Hora", planilla.Hora);
                    cmd.Parameters.AddWithValue("@Clase", planilla.Clase);

                    cmd.Parameters.AddWithValue("@Cantidad", planilla.Cantidad);
                    cmd.Parameters.AddWithValue("@Cedula", planilla.Cedula);
                    cmd.Parameters.AddWithValue("@IdSucursal", planilla.IdSucursal);

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

        public void DeletePlanilla(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("eliminarPlanilla", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
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
