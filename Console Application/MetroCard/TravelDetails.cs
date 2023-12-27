using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class TravelDetails
    {
        //Fields
        private static int s_travelId=101;
        
        private static int s_cardNumber=101;

        //Properties
        public string TravelId { get; }
        public string CardNumber { get;}
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Date { get; set; }
        public int TravelCost { get; set; }
        //Constructors
        
        public TravelDetails(string fromLocation, string toLocation, DateTime date, int travelCost)
        {
            
            TravelId ="TID"+s_travelId;
            s_travelId++;
            CardNumber ="CMRL"+s_cardNumber;
            s_cardNumber++;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            Date = date;
            TravelCost = travelCost;
        }

    }
}
