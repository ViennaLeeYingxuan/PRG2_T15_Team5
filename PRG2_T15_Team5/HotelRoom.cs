﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T15_Team5
{
    abstract class HotelRoom
    {
        private string roomType;
        private string roomNumber;
        private string bedConfiguration;
        private double dailyRate;
        private bool isAvail;
        private int noOfOccupants;

        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public string BedConfiguration
        {
            get { return bedConfiguration; }
            set { bedConfiguration = value; }
        }

        public double DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }

        public bool IsAvail
        {
            get { return isAvail; }
            set { isAvail = value; }
        }

        public int NoOfOccupants
        {
            get { return noOfOccupants; }
            set { noOfOccupants = value; }
        }

        public HotelRoom() { }
        public HotelRoom(string t, string no, string c,double r, bool a, int o)
        {
            roomType = t;
            roomNumber = no;
            bedConfiguration = c;
            dailyRate = r;
            isAvail = a;
            noOfOccupants = o;
        }
    }
}
