using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T15_Team5
{
    class Guest
    {
        private string name;
        private string ppNumber;
        private Stay hotelStay;
        private Membership membership;
        private bool isCheckedIn;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PpNumber
        {
            get { return ppNumber; }
            set { ppNumber = value; }
        }

        public Stay Hotel
        {
            get { return hotelStay; }
            set { hotelStay = value; }
        }

        public Membership Membership
        {
            get { return membership; }
            set { membership = value; }
        }

        public bool IsCheckedIn
        {
            get { return isCheckedIn; }
            set { isCheckedIn = value; }
        }

        public Guest() { }
        public Guest(string n, string p, Stay s, Membership m, bool i)
        {
            name = n;
            ppNumber = p;
            hotelStay = s;
            membership = m;
            isCheckedIn = i;
        }


    }
}
