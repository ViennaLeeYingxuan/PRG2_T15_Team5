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
        // 2 lines above not sure

        /*
        public override double CalculateCharges()
        {
            if 
        }
        */
        
        
        

    }
}
