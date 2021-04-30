using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using lr6.Models;

namespace lr6.DAO
{
    public class CargoDAO : DAO
    {
        public List<Cargos> GetAllRecords()
        {
            Connect();
            List<Cargos> recordList = new List<Cargos>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Cargo", sqlConnection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cargos cargo = new Cargos();
                    cargo.ID = Convert.ToInt32(reader["Id"]);
                    cargo.Full_name_client = reader["Full_name_client"].ToString();
                    cargo.Cargo_code = Convert.ToInt32(reader["Cargo_code"]);
                    cargo.Cargo_weight = Convert.ToInt32(reader["Cargo_weight"]);
                    cargo.Shiping_cost = Convert.ToDecimal(reader["Shiping_cost"]);
                    cargo.Departure_point = reader["Departure_point"].ToString();
                    cargo.Arrival_point = reader["Arrival_point"].ToString();
                    recordList.Add(cargo);
                }
                reader.Close();
            }
            catch (Exception)
            {
                Trace.WriteLine("Error connect to database");
            }
            finally
            {
                Disconnect();
            }
            return recordList;
        }
        public bool AddRecord(Cargos cargos)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Cargo (Full_name_client, Cargo_code, Cargo_weight, Shiping_cost, Departure_point, Arrival_point)" +
            "VALUES (@Full_name_client, @Cargo_code, @Cargo_weight, @Shiping_cost, @Departure_point, @Arrival_point)", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@Full_name_client", cargos.Full_name_client));
                cmd.Parameters.Add(new SqlParameter("@Cargo_code", cargos.Cargo_code));
                cmd.Parameters.Add(new SqlParameter("@Cargo_weight", cargos.Cargo_weight));
                cmd.Parameters.Add(new SqlParameter("@Shiping_cost", cargos.Shiping_cost));
                cmd.Parameters.Add(new SqlParameter("@Departure_point", cargos.Departure_point));
                cmd.Parameters.Add(new SqlParameter("@Arrival_point", cargos.Arrival_point));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        public bool EditRecord(Cargos cargos)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Cargo SET Full_name_client = @Full_name_client, Cargo_code = @Cargo_code, Cargo_weight = @Cargo_weight, Shiping_cost = @Shiping_cost, Departure_point = @Departure_point, Arrival_point = @Arrival_point", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@Full_name_client", cargos.Full_name_client));
                cmd.Parameters.Add(new SqlParameter("@Cargo_code", cargos.Cargo_code));
                cmd.Parameters.Add(new SqlParameter("@Cargo_weight", cargos.Cargo_weight));
                cmd.Parameters.Add(new SqlParameter("@Shiping_cost", cargos.Shiping_cost));
                cmd.Parameters.Add(new SqlParameter("@Departure_point", cargos.Departure_point));
                cmd.Parameters.Add(new SqlParameter("@Arrival_point", cargos.Arrival_point));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        public bool DeleteRecord(Cargos cargos)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Cargo WHERE Id = @id", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@id", cargos.ID));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }
}