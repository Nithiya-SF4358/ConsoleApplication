using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafetaria
{
    public enum Gender{Select, Male, Female, Transgender}
    public class PersonalDetails
    {
        //Property
        public string Name { get; set; }
        public string FatherName{ get; set; }
        public Gender Gender { get; set; }
        public long Mobile { get; set; }
        public string MailID { get; set; }
        //Constructors
        public PersonalDetails(string name, string fatherName, Gender getGender, long mobile, string mailID)
        {
            Name = name;
            FatherName = fatherName;
            Gender = getGender;
            Mobile = mobile;
            MailID = mailID;
        }
    }
}

