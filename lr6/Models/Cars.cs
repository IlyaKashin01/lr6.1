using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lr6.Models
{
    public class Cars
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public int Load_capacity { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public string Number { get; set; }
        public int Fuel_consuption { get; set; }
        public int Group_Id { get; set; }

    }
}