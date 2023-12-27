using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCard
{
    public interface IBalance
    {
        //Properties
        public double Balance { get;set;}
        public void WalletRecharge(){

        }
        public void DeductBalance(){
            
        }
    }
}