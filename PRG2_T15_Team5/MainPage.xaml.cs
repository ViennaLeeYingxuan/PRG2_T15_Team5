using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PRG2_T15_Team5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Guest> guestList = new List<Guest>();
        List<Stay> roomList = new List<Stay>();
        List<HotelRoom> hotelList = new List<HotelRoom>();
        public MainPage()
        {
            this.InitializeComponent();
            InItData();
            AddGuest();

        }

        public void InItData()
        {
            // Rooms
            
            HotelRoom room1 = new StandardRoom("Standard Room", "101", "Single", 90, true, 0);
            HotelRoom room2 = new StandardRoom("Standard Room", "102", "Single", 90, true, 0);

            HotelRoom room3 = new StandardRoom("Standard Room", "201", "Twin", 110, true, 0);
            HotelRoom room4 = new StandardRoom("Standard Room", "202", "Twin", 110, true, 0);
            HotelRoom room5 = new StandardRoom("Standard Room", "203", "Twin", 110, true, 0);

            HotelRoom room6 = new StandardRoom("Standard Room", "301", "Triple", 120, true, 0);
            HotelRoom room7 = new StandardRoom("Standard Room", "302", "Triple", 120, true, 0);

            HotelRoom room8 = new DeluxeRoom("Deluxe Room", "204", "Twins", 140, true, 0);
            HotelRoom room9 = new DeluxeRoom("Deluxe Room", "205", "Twins", 140, true, 0);
            HotelRoom room10 = new DeluxeRoom("Deluxe Room", "303", "Triple", 210, true, 0);
            HotelRoom room11 = new DeluxeRoom("Deluxe Room", "304", "Triple", 210, true, 0);

            hotelList.Add(room1);
            hotelList.Add(room2);
            hotelList.Add(room3);
            hotelList.Add(room4);
            hotelList.Add(room5);
            hotelList.Add(room6);
            hotelList.Add(room7);
            hotelList.Add(room8);
            hotelList.Add(room9);
            hotelList.Add(room10);
            hotelList.Add(room11);

        }

        public void AddGuest()
        {

        }

        private void checkInBtn_Click(object sender, RoutedEventArgs e)
        {
            string name, nric, noAdults, noKids;
            name = guestNameTxt.Text;
            nric = passportNoTxt.Text;

            noAdults = numAdultTxt.Text;
            noKids = numChildTxt.Text;
            //checkIn = checkInDate;
            //checkOut = ;

        }

        private void checkRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            List<String> availList = new List<string>();
            foreach (HotelRoom room in hotelList)
            {    
                if ( room.IsAvail == true)
                {
                    availList.Add(room.RoomType + "\t" + room.RoomNumber + "\t" + room.BedConfiguration + "\t" + "$" + room.DailyRate);
                }
            }
            availableList.ItemsSource = availList;
        }




    }
}
