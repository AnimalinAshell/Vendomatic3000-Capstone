﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class BeverageItem : VendingMachineItem
    {
        public BeverageItem(string item, decimal price) : base(item, price)
        {
        }

        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }
    }
}
