using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Model
{
    public class hotel
    {
        public int Hotel_Id { get; set; }
        public string Hotel_name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int pinCode { get; set; }
        public string contactNumber { get; set; }
        public string contactPerson { get; set; }
        public string website { get; set; }
        public string faceBook { get; set; }
        public string twitter { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public string updatedBy { get; set; }

     
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
