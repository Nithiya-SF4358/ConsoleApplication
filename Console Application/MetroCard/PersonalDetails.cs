using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class PersonalDetails
    {
        //Properties
        public string UserName { get; set; }
        public long Phone { get; set; }
        //Constructors
        public PersonalDetails(string userName, long phone)
        {
            UserName = userName;
            Phone = phone;
        }
    }
}