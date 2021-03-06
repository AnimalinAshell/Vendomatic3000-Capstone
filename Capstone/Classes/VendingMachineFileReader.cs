﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineFileReader
    {
        private string FilePath;

        public VendingMachineFileReader(string filePath)
        {
            FilePath = filePath;
        }

        public  Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            using (StreamReader sr = new StreamReader("vendingmachine.csv"))
            {
                Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();
               
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] splitLine = line.Split('|');
                    List<VendingMachineItem> inventList = new List<VendingMachineItem>();

                    if (splitLine[0].Contains('A'))
                    {
                        ChipItem item = new ChipItem(splitLine[1], decimal.Parse(splitLine[2]));
                        inventList.Add(item);
                        inventory.Add(splitLine[0], inventList);
                    }
                    else if (splitLine[0].Contains('B'))
                    {
                        CandyItem item = new CandyItem(splitLine[1], decimal.Parse(splitLine[2]));
                        inventList.Add(item);
                        inventory.Add(splitLine[0], inventList);
                    }
                    else if (splitLine[0].Contains('C'))
                    {
                        BeverageItem item = new BeverageItem(splitLine[1], decimal.Parse(splitLine[2]));
                        inventList.Add(item);
                        inventory.Add(splitLine[0], inventList);
                    }
                    else
                    {
                        GumItem item = new GumItem(splitLine[1], decimal.Parse(splitLine[2]));
                        inventList.Add(item);
                        inventory.Add(splitLine[0], inventList);
                    }
                }
                return inventory;
            }
        }

    }
}
