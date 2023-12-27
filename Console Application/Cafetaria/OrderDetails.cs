using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafetaria
{
    public enum OrderStatus{Default, Initiated, Ordered, Cancelled}
    public class OrderDetails
    {
        private static int s_orderId=1000;
        public string OrderId { get;}
        public new string UserID { get; set; }
        public DateOnly OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        
        public OrderDetails(string userID, DateOnly orderDate, double totalPrice, OrderStatus status)
        {
            s_orderId++;
            OrderId = "OID"+s_orderId;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            Status = status;
        }
        public OrderDetails(string orderId, string userID, DateOnly orderDate, double totalPrice, OrderStatus status)
        {
            OrderId = orderId;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            Status = status;
        }


    }
}

