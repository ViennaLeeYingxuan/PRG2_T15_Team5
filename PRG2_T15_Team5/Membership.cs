using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T15_Team5
{
    class Membership
    {
        private string status;
        private int points;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        //constructor

        public Membership() { }
        public Membership(string s, int p)
        {
            status = s;
            points = p;
        }

        public override string ToString()
        {
            return "Status: " + status + "\n" + "Points " + points;
        }

        //public double EarnPoints ()
        //{ }

        //public int RedeemPoints ()
        //{ }

    }
}
