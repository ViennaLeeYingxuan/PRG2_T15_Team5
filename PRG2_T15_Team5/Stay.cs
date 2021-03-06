﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T15_Team5
{
    class Stay 
    {
        private List<HotelRoom> roomList = new List<HotelRoom>();
        private DateTime checkInDate;
        private DateTime checkOutDate;

        public List<HotelRoom> RoomList
        {
            get { return roomList; }
            set { roomList = value; }
        }

        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }

        public DateTime CheckOutnDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }

        public Stay() { }
        public Stay(DateTime In, DateTime Out)
        {
            checkInDate = In;
            checkOutDate = Out;
        }

        public void AddRoom(HotelRoom r)
        {
            roomList.Add(r);
        }

        
        public double CalculateTotal()
        {
            RoomList.Count();
            string days = (checkOutDate - checkInDate).TotalDays.ToString();
            int date = Convert.ToInt32(days);
            int final = RoomList.Count() * date;
            return final;
            
        }
        

    }
}
