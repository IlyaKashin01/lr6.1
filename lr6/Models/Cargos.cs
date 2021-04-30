using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lr6.Models
{
    public class Cargos
    {
        public int ID { get; set; }
        public string Full_name_client { get; set; }
        public int Cargo_code { get; set; }
        public int Cargo_weight { get; set; }
        public Decimal Shiping_cost { get; set; }
        public string Departure_point { get; set; }
        public string Arrival_point { get; set; }

    }
}