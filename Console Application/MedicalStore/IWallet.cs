using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public interface IWallet
    {
        //Property for the Interface
        public double WalletBalance { get; set; }
        //Methods
        public void WalletRecharge(){

        }
        public void DeductBalance(){
            
        }
    }
}