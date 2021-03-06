﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;


namespace DesignByContract
{
    class Account
    {
  
        public String name { get; set; }
   
        public double amount { get; set; }

        public Account(string name,  double amount)
        {
            this.name = name;
          
            this.amount = amount;
        }
   
        public override string ToString()
        {
            return  " Name : " + name + "; \t Amount :" + amount.ToString() +"\n";
        }

        public void Deposit(double d)
        {
            Contract.Requires(d >= 0);
            Contract.EnsuresOnThrow<Exception>(d<0);
            Contract.Ensures(Contract.OldValue(amount) + d == amount);
          //Contract.EnsuresOnThrow<Exception>(Contract.OldValue(amount) > this.amount);           
           //Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(), "Exception!!");
            amount += d;
        }

        public void Withdraw(double d)
        {
            Contract.Requires(d >=0 );
            Contract.Ensures(Contract.OldValue(amount) - d == amount);
            Contract.EnsuresOnThrow<Exception>(Contract.OldValue(amount) == amount);
            if (d > amount) throw new Exception();
            amount -= d;
        }
    }
    
}
