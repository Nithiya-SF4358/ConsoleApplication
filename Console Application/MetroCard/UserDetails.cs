using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public class UserDetails:PersonalDetails,IBalance
    {
        private static int s_cardNumber=101;

        //Properties
        public double Balance { get;set;}
        public string CardNumber { get; }

        //Constructors
        
        public UserDetails(string userName, long phone,double balance) : base(userName, phone)
        {
            Balance=balance;
            CardNumber="CMRL"+s_cardNumber;
            s_cardNumber++;
        }

        public void WalletRecharge(){

        }
        public void DeductBalance(){
            
        }
    }
}