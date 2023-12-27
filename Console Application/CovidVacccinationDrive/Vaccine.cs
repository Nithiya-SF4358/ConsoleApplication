using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVacccinationDrive
{
    public enum VaccineName{ Covishield, Covaccine}
    public class Vaccine
    {
        private static int s_VaccineID = 2000;
        
        public string VaccineID { get; }
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        public Vaccine(VaccineName vaccineName, int noOfDoseAvailablle)
        {
            s_VaccineID++;
            VaccineID = "CID" + s_VaccineID;
            VaccineName = vaccineName;
            NoOfDoseAvailable = noOfDoseAvailablle;
        }
    }
}