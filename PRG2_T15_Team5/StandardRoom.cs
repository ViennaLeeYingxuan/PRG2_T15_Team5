﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T15_Team5
{
    class StandardRoom : HotelRoom 
    {
        private bool requireWifi;
        private bool requireBreakfast;
        
        
        public bool RequireWifi
        {
            get { return requireWifi; }
            set { requireWifi = value; }
        }

        public bool RequireBreakfast
        {
            get { return requireBreakfast; }
            set { requireBreakfast = value; }
        }

        public StandardRoom() : base() { }
        public StandardRoom(string t, string n, string b, double d, bool i, int o) : base(t, n, b, d, i, o) { }

        public override double CalculateCharges()
        {
            double charges = 0;
            if (requireWifi == true && requireBreakfast == true)
            {
                charges += 30;
            }
            if (requireWifi == true)
            {
                charges += 10;
            }
            if (requireBreakfast == true)
            {
                charges += 20;
            }
            else
            {
                charges += 0;
            }
            
            if (BedConfiguration == "Twin")
            {
                DailyRate = 140;
            }
            else
            {
                DailyRate = 210;
            }
            Stay stay1 = new Stay();
            double cost = DailyRate * stay1.CalculateTotal();
            return cost;
        }


        public override string ToString()
        {
            return base.ToString();
        }

    }
}
