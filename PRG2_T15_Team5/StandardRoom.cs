using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T15_Team5
{
    class StandardRoom : HotelRoom
    {
        private bool requireWifi;

        public bool RequireWifi
        {
            get { return requireWifi; }
            set { requireWifi = value; }
        }

        private bool requireBreakfast;

        public bool RequireBreakfast
        {
            get { return requireBreakfast; }
            set { requireBreakfast = value; }
        }

        public StandardRoom() : base() { }
        public StandardRoom(string t, string no, string c, double r, bool a, int o) : base()
        {
            // hi 
        }


    }
}
