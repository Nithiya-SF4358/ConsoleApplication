using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class UserDetails:PersonalDetails,IWallet
    {
        //Fields
        private static int s_userId=1000;

        //Property for the Interface
        public double WalletBalance { get; set; }
        //Property for the user details class
        public string UserId { get; }
        //Constructors

        public UserDetails(string name, int age, string city, long phoneNumber, double walletBalance) : base(name, age, city, phoneNumber)
        {
            s_userId++;
            UserId="UID"+s_userId;
            WalletBalance = walletBalance;
        }
        //Methods
        public double WalletRecharge(double recharge){
            return WalletBalance+=recharge;
        }
        public double DeductBalance(double total){
            return WalletBalance-=total;
        }
    }
}