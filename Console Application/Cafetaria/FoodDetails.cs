using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafetaria
{
    public class FoodDetails
    {
        //Fields
        private static int s_foodId=100;


        //Property
        public string FoodID { get; }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public int AvailableQuantity { get; set; }
        //constructors
        
        public FoodDetails(string foodName, double foodPrice, int availableQuantity)
        {
            s_foodId++;
            FoodID ="FID"+s_foodId;
            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuantity;
        }
}
}