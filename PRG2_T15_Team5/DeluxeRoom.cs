using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T15_Team5
{
    class DeluxeRoom : HotelRoom
    {
        private bool additionalBed;

        public bool AdditionalBed
        {
            get { return additionalBed; }
            set { additionalBed = value; }
        }

        public DeluxeRoom() { }
        public DeluxeRoom(string r, string n, string b, double d, bool i, int o) : base(r, n, b, d, i, o) { }
      
        public override double CalculateCharges()
        {
            double charges = 0;
            if (additionalBed == true )
            {
                charges += 25;
            }
            else
            {
                charges += 0;
            }
            //return charges;

            if (BedConfiguration == "Twin")
            {
                DailyRate = 140;
            }
            else
            {
                DailyRate = 210;
            }
            Stay stay1 = new Stay();
            double cost = DailyRate + charges;
            return cost;



        }

        public override string ToString()
        {
            return base.ToString();
        }





    }
}
