using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVacccinationDrive
{
    public enum Gender{Select, Male, Female, Others}
    public class BeneficiaryRegistration
    {
        private static int s_RegisterNumber = 1000;

        //properties
        public string RegisterNumber { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber  { get; set; }
        public string City { get; set; }

        //constructor
        public BeneficiaryRegistration(string name, int age, Gender gender, long mobileNumber, string city)
        {
            s_RegisterNumber++;
            RegisterNumber = "BID" + s_RegisterNumber;
            Name = name;
            Age = age;
            Gender = gender;
            MobileNumber = mobileNumber;
            City = city;
        }
    }
}