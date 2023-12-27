using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafetaria
{
    public class UserDetails : PersonalDetails, IBalance
    {
        //Fields

        private static int s_userId=1000;
        private static int s_workstationNumber=100;
        private static int _balance=0;
        //Properties
        public string UserID { get; set; }
        public string WorkStationNumber { get; }
        public double Balance { get; set; }
        public double  WalletBalance { get;set; }

        //Constructors
        public UserDetails(string name, string fatherName, Gender getGender, long mobile, string mailID, double _balance) : base(name, fatherName, getGender, mobile, mailID)
        {
            s_userId++;
            s_workstationNumber++;
            UserID = "SF" + s_userId;
            WorkStationNumber = "WS" + s_workstationNumber;
            Balance = _balance;
        }

        //Method: WalletRecharge, DeductAmount
        public  double WalletRecharge(double recharge){

            return WalletBalance+=recharge;
        }
        public void DeductAmount(){
            
        }
    }
}
