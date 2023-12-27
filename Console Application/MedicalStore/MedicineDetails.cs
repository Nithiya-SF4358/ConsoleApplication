using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class MedicineDetails
    {
        //Fields
        private static int s_medicineID=100;
        //Properties
        public string MedicineID { get; }
        public string MedicineName { get; set; }
        public int AvailableCount { get; set; }
        public double Price { get; set; }
        public DateTime DateOfExpiry { get; set; }
        //Constructors
        
        public MedicineDetails(string medicineName, int availableCount, double price, DateTime dateOfExpiry)
        {
            s_medicineID++;
            MedicineID = "MD"+s_medicineID;
            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;
        }


       
    }
}