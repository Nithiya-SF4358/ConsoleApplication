using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafetaria
{
    public class cartItem
    {
        private static int s_itemId=100;

        public string ItemID{ get;}
        public new string OrderID { get; set; }
        public new string FoodID{get;set;}
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }

        
        public cartItem( string orderID, string foodID, double orderPrice, int orderQuantity)
        {
            s_itemId++;
            ItemID="ITID"+s_itemId;
            OrderID = orderID;
            FoodID = foodID;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }
        public cartItem( string itemId,string orderID, string foodID, double orderPrice, int orderQuantity)
        {
            ItemID=itemId;
            OrderID = orderID;
            FoodID = foodID;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }

    }
}

