using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using lr6.Models;

namespace lr6.DAO
{
    public class TransportDAO : DAO
    {
        public List<Cars> GetAllTransport()
        {
            Connect();
            List<Cars> recordList = new List<Cars>();
            try
            {
                DataContext db = new DataContext(sqlConnection);
                Table<Transport> cars = db.GetTable<Transport>();

                foreach (var car in cars)
                {
                    Cars auto = new Cars();
                    auto.ID = Convert.ToInt32(car.Id);
                    auto.Brand = car.Brand.ToString();
                    auto.Load_capacity =Convert.ToInt32(car.Load_capacity);
                    auto.Condition = car.Condition.ToString();
                    auto.Location = car.Location.ToString();
                    auto.Number = car.Number.ToString();
                    auto.Fuel_consuption = Convert.ToInt32(car.Fuel_consuption);
                    auto.Group_Id = Convert.ToInt32(car.GroupId);
                    recordList.Add(auto);
                }
                
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
        public bool AddTransport(Cars auto)
        {
            bool result = true;
            Connect();
            try
            {
                DataContext db = new DataContext(sqlConnection);
                Table<Transport> cars = db.GetTable<Transport>();

                Transport data = new Transport {
                    Brand = auto.Brand, 
                    Load_capacity = auto.Load_capacity, 
                    Condition = auto.Condition, 
                    Location = auto.Location, 
                    Number = auto.Number, 
                    Fuel_consuption = auto.Fuel_consuption, 
                    GroupId = auto.Group_Id};

                db.GetTable<Transport>().InsertOnSubmit(data);
                db.SubmitChanges();
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
        public bool EditTransport(Cars auto, int selectedId)
        {
            bool result = true;
            Connect();
            try
            {
                DataContext db = new DataContext(sqlConnection);
                Table<Transport> cars = db.GetTable<Transport>();

                var selectedcar = from car in cars where car.Id == selectedId select auto;
                Transport data = (Transport)selectedcar;

                data.Brand = auto.Brand;
                data.Load_capacity = auto.Load_capacity;
                data.Condition = auto.Condition;
                data.Location = auto.Location;
                data.Number = auto.Number;
                data.Fuel_consuption = auto.Fuel_consuption;
                data.GroupId = auto.Group_Id;

                db.SubmitChanges();

                /*SqlCommand cmd = new SqlCommand("UPDATE Cargo SET Full_name_client = @Full_name_client, Cargo_code = @Cargo_code, Cargo_weight = @Cargo_weight, Shiping_cost = @Shiping_cost, Departure_point = @Departure_point, Arrival_point = @Arrival_point", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@Full_name_client", cargos.Full_name_client));
                cmd.Parameters.Add(new SqlParameter("@Cargo_code", cargos.Cargo_code));
                cmd.Parameters.Add(new SqlParameter("@Cargo_weight", cargos.Cargo_weight));
                cmd.Parameters.Add(new SqlParameter("@Shiping_cost", cargos.Shiping_cost));
                cmd.Parameters.Add(new SqlParameter("@Departure_point", cargos.Departure_point));
                cmd.Parameters.Add(new SqlParameter("@Arrival_point", cargos.Arrival_point));
                cmd.ExecuteNonQuery();*/
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
        public bool DeleteRecord(Cars auto)
        {
            bool result = true;
            Connect();
            try
            {
                
                SqlCommand cmd = new SqlCommand("DELETE FROM Cargo WHERE Id = @id", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@id", auto.ID));
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