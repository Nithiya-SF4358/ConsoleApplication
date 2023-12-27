using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVacccinationDrive
{
    public enum  DoseNumber{select, one , two,  three}
    public class Vaccination
    {
        private static int s_VaccinationID = 3000;
        //properties
        public string VaccinationID { get; }
        public string RegisterNumber { get; set; }
        public string VaccineID { get; set; }
        public DoseNumber DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }

        //constructor
        public Vaccination(String registerNumber, string vaccineID, DoseNumber doseNumber, DateTime vaccinateddate)
        {
            s_VaccinationID++;
            VaccinationID =  "VID" + s_VaccinationID;
            RegisterNumber = registerNumber;
            VaccineID = vaccineID;
            DoseNumber = doseNumber;
            VaccinatedDate = vaccinateddate;
        }
    }
}