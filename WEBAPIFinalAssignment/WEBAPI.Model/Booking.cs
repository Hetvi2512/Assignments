using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.Model
{
    public partial class Booking
    {
        public int Room_Id { get; set; }
        public int bookingId { get; set; }
        public System.DateTime bookingDate { get; set; }
        public string statusOfBooking { get; set; }

        public virtual Room Room { get; set; }
    }
}
