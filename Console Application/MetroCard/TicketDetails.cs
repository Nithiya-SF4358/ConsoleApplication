using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class TicketDetails
    {
        private static int s_ticketId=101;

        public string TicketID { get;}
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int TicketPrice { get; set; }
        //Constructors
        
        public TicketDetails( string fromLocation, string toLocation, int ticketPrice)
        {
            TicketID = "MR"+s_ticketId;
            s_ticketId++;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice;
        }

    }
}
