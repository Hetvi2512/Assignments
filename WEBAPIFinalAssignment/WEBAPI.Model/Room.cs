using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Model
{
    
        public partial class Room
        {
            public int Hotels_Id { get; set; }
            public int Room_Id { get; set; }
            public string Room_Name { get; set; }

            public string Category { get; set; }
            public Nullable<int> Price { get; set; }
            public Nullable<bool> isActive { get; set; }
            public string createdBy { get; set; }
            public Nullable<System.DateTime> createdDate { get; set; }
            public string updatedBy { get; set; }
            public Nullable<System.DateTime> updatedDate { get; set; }

            public virtual Booking Booking { get; set; }
            public virtual hotel hotel { get; set; }

          
        }
    
}
