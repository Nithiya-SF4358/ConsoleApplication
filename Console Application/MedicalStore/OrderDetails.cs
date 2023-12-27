using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    //enum class
    public enum OrderStatus{Default,Purchased,Cancelled}
    public class OrderDetails
    {
        //Fields
        private static int s_orderId=2000;

        //property
        public string OrderId { get;}
        public new string UserId{get;set;}
        public new string MedicineID { get; set; }
        public int MedicineCount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate{ get; set; }
        public OrderStatus Status { get; set; }
        //Constructors
        
        public OrderDetails( string userId,string medicineID, int medicineCount, double totalPrice, DateTime orderDate, OrderStatus status)
        {
            s_orderId++;
            OrderId = "OID"+s_orderId;
            UserId=userId;
            MedicineID = medicineID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Status = status;
        }
        

        
    }
}