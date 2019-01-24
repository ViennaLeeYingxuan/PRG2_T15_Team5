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
        List<HotelRoom> availList = new List<HotelRoom>();
        List<Guest> guestList = new List<Guest>();
        List<Stay> roomList = new List<Stay>();
        List<HotelRoom> hotelList = new List<HotelRoom>();
        List<HotelRoom> checkList = new List<HotelRoom>();
        List<HotelRoom> selectedList = new List<HotelRoom>();
        

        public MainPage()
        {
            this.InitializeComponent();
            InItData();
            

        }

        public void InItData()
        {
            // Rooms
            
            HotelRoom room1 = new StandardRoom("Standard Room", "101", "Single", 90, true, 1);
            HotelRoom room2 = new StandardRoom("Standard Room", "102", "Single", 90, true, 1);

            HotelRoom room3 = new StandardRoom("Standard Room", "201", "Twin", 110, true, 2);
            HotelRoom room4 = new StandardRoom("Standard Room", "202", "Twin", 110, true, 2);
            HotelRoom room5 = new StandardRoom("Standard Room", "203", "Twin", 110, true, 2);

            HotelRoom room6 = new StandardRoom("Standard Room", "301", "Triple", 120, true, 3);
            HotelRoom room7 = new StandardRoom("Standard Room", "302", "Triple", 120, true, 3);

            HotelRoom room8 = new DeluxeRoom("Deluxe Room", "204", "Twins", 140, true, 3);
            HotelRoom room9 = new DeluxeRoom("Deluxe Room", "205", "Twins", 140, true, 3);
            HotelRoom room10 = new DeluxeRoom("Deluxe Room", "303", "Triple", 210, true, 4);
            HotelRoom room11 = new DeluxeRoom("Deluxe Room", "304", "Triple", 210, true, 4);

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

            Membership member1 = new Membership("GOLD", 280);
            DateTime start1 = new DateTime(2019, 01, 26);
            DateTime end1 = new DateTime(2019, 02, 02);
            Stay stay1 = new Stay(start1, end1);
            Guest guest1 = new Guest("Amelia", "S1234567A", stay1 , member1, true);

            Membership member2 = new Membership("Ordinary", 0);
            DateTime start2 = new DateTime(2019, 01, 25);
            DateTime end2 = new DateTime(2019, 01, 31);
            Stay stay2 = new Stay(start2, end2);
            Guest guest2 = new Guest("Bob", "G1234567A", stay2, member2, true);

            Membership member3 = new Membership("Silver", 190);
            DateTime start3 = new DateTime(2019, 02, 1);
            DateTime end3 = new DateTime(2019, 02, 06);
            Stay stay3 = new Stay(start3, end3);
            Guest guest3 = new Guest("Cody", "G2345678A", stay3, member3, true);

            Membership member4 = new Membership("GOLD", 10);
            DateTime start4 = new DateTime(2019, 01, 28);
            DateTime end4 = new DateTime(2019, 02, 10);
            Stay stay4 = new Stay(start4, end4);
            Guest guest4 = new Guest("Edda", "S3456789A", stay3, member3, true);

            guestList.Add(guest1);
            guestList.Add(guest2);
            guestList.Add(guest3);
            guestList.Add(guest4);



        }

        public void RefreshListViews()
        {
            availableList.ItemsSource = null;
            availableList.ItemsSource = availList;
            selectedRooms.ItemsSource = null; //this line not used yet but yc used it in the check in button that we have not done
            selectedRooms.ItemsSource = selectedList;
        }

        

        private void checkInBtn_Click(object sender, RoutedEventArgs e)
        {
            string name, passport, noAdults, noKids;
            //DateTime checkIn, checkOut;

            name = guestNameTxt.Text;
            passport = passportNoTxt.Text;
            noAdults = numAdultTxt.Text;
            noKids = numChildTxt.Text;

            var checkIn = checkInDate.Date;
            DateTime chkIN = checkIn.Value.DateTime;
            var checkOut = checkOutDate.Date;
            DateTime chkOUT = checkOut.Value.DateTime;

            //guest.stay.roomlist
            // use addroom on stay

            if(selectedList != null)
            {
                foreach (Guest g in guestList)
                {
                    if (name == g.Name)
                    {


                    }
                }
            }
            else
            {
                statusText.Text = "Please select a room.";
            }
            










            //checkIn = checkInDate;
            //checkOut = ;

            // isavail = false
            // room assigned under a name
            // remove from selected list
            // > than a room
        }

        private void checkRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (HotelRoom room in hotelList)
            {    
                if ( room.IsAvail == true)
                {
                    availList.Add(room);
                    //availList.Add(room.RoomType + "\t" + room.RoomNumber + "\t" + room.BedConfiguration + "\t" + "$" + room.DailyRate);
                }
            }
            availableList.ItemsSource = availList;
        }

        private void addRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            HotelRoom clicked = (HotelRoom)availableList.SelectedItem;
            if (clicked != null)
            {
                availableList.ItemsSource = null;
                selectedList.Add(clicked);
                selectedRooms.ItemsSource = selectedList;
                availList.Remove(clicked);

                RefreshListViews();

                // for remove button is oppside

                //standard room: wifi + breakfast 
                if( clicked is StandardRoom)
                {
                    StandardRoom room = (StandardRoom)clicked; // DOWNCASTING
                    if(bed.IsChecked == true)
                    {
                        statusText.Text = "Standard Room do not have the add bed feature";
                        
                    }
                    if (wifi.IsChecked == true && breakfast.IsChecked == true)
                    {
                        room.RequireWifi = true;
                        room.RequireBreakfast = true;
                    }
                    if(wifi.IsChecked == true && breakfast.IsChecked == false)
                    {
                        room.RequireWifi = true;
                        room.RequireBreakfast = false;
                    }
                    if (wifi.IsChecked == false && breakfast.IsChecked == true)
                    {
                        room.RequireWifi = false;
                        room.RequireBreakfast = true;
                    }
                    if (wifi.IsChecked == false && breakfast.IsChecked == false)
                    {
                        room.RequireWifi = false;
                        room.RequireBreakfast = false;
                    }
                    
                    

                }
                if( clicked is DeluxeRoom)
                {
                    DeluxeRoom room = (DeluxeRoom)clicked; // DOWNCASTING
                    if (wifi.IsChecked == true)
                    {
                        statusText.Text = "Deluxe Room do not have the add wifi feature";

                    }
                    if (breakfast.IsChecked == true)
                    {
                        statusText.Text = "Standard Room do not have the add breakfast feature";

                    }
                    if (bed.IsChecked == true)
                    {
                        room.AdditionalBed = true;

                    }
                    if (bed.IsChecked == false)
                    {
                        room.AdditionalBed = false;

                    }

                }
                



            }

            //foreach (HotelRoom rm in availableList.SelectedItem)

            //if (clicked != null /*&& clicked == StandardRoom*/)
            //{
                //checkList.Remove(clicked);
                //selectedList.Add(clicked.ToString());

                //selectedRooms.ItemsSource = selectedList;

                //availableList.ItemsSource = null;
                //availableList




         
        }

        private void availableList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void removeRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            HotelRoom clicked = (HotelRoom)selectedRooms.SelectedItem;
            if (clicked != null)
            {
                selectedRooms.ItemsSource = null; //this line i not sure, yc nvr use
                selectedList.Remove(clicked);
                selectedRooms.ItemsSource = selectedList;
                availList.Add(clicked);

                RefreshListViews();
            }

        }
    }
}
