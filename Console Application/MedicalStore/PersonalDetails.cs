using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class PersonalDetails
    {
        //Property for personal details class
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public long PhoneNumber { get; set; }
        //Constructors
        public PersonalDetails(string name, int age, string city, long phoneNumber)
        {
            Name = name;
            Age = age;
            City = city;
            PhoneNumber = phoneNumber;
        }


    }
}