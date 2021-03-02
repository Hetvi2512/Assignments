using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAssignment.Models
{
    public class Passenger
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
    }
}