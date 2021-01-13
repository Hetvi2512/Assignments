using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Model
{
   public class roombyPincode
    {
        public string Room_Name { get; set; }
        public string Category { get; set; }
        public Nullable<int> Price { get; set; }
        public string createdBy { get; set; }
        public string Hotel_name { get; set; }
        public string City { get; set; }
        public int pinCode { get; set; }
    }
}
