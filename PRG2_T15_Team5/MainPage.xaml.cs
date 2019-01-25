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
        List<HotelRoom> unavailList = new List<HotelRoom>();


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
            Membership member2 = new Membership("Ordinary", 0);
            Membership member3 = new Membership("Silver", 190);
            Membership member4 = new Membership("GOLD", 10);

            DateTime start1 = new DateTime(2019, 01, 26);
            DateTime end1 = new DateTime(2019, 02, 02);
            Stay stay1 = new Stay(start1, end1);
            Guest guest1 = new Guest("AMELIA", "S1234567A", stay1 , member1, true);
           
            DateTime start2 = new DateTime(2019, 01, 25);
            DateTime end2 = new DateTime(2019, 01, 31);
            Stay stay2 = new Stay(start2, end2);
            Guest guest2 = new Guest("BOB", "G1234567A", stay2, member2, true);
            
            DateTime start3 = new DateTime(2019, 02, 1);
            DateTime end3 = new DateTime(2019, 02, 06);
            Stay stay3 = new Stay(start3, end3);
            Guest guest3 = new Guest("CODY", "G2345678A", stay3, member3, true);

            DateTime start4 = new DateTime(2019, 01, 28); 
            DateTime end4 = new DateTime(2019, 02, 10);
            Stay stay4 = new Stay(start4, end4);
            Guest guest4 = new Guest("EDDA", "S3456789A", stay3, member3, true);

            guestList.Add(guest1);
            guestList.Add(guest2);
            guestList.Add(guest3);
            guestList.Add(guest4);

            stay1.AddRoom(room1);
            stay2.AddRoom(room7);
            stay3.AddRoom(room4);
            stay4.AddRoom(room10);

        }

        public void RefreshListViews()
        {
            availableList.ItemsSource = null;
            availableList.ItemsSource = availList;
            selectedRooms.ItemsSource = null; //this line not used yet but yc used it in the check in button that we have not done
            selectedRooms.ItemsSource = selectedList;
        }

        public void RefreshTextBox()
        {
            guestNameTxt.Text = "";
            passportNoTxt.Text = "";
            numAdultTxt.Text = "";
            numChildTxt.Text = "";
        }

        

        private void checkInBtn_Click(object sender, RoutedEventArgs e)
        {
            string name, passport, noAdults, noKids;
            //DateTime checkIn, checkOut;

            name = guestNameTxt.Text.ToUpper();
            passport = passportNoTxt.Text.ToUpper();
            noAdults = numAdultTxt.Text;
            noKids = numChildTxt.Text;

            var checkIn = checkInDate.Date;
           // DateTime chkIN = checkIn.Value.DateTime;
            var checkOut = checkOutDate.Date;
           // DateTime chkOUT = checkOut.Value.DateTime;

            //guest.stay.roomlist 
            // use addroom on stay


            if (name == "" || passport == "")
            {
                statusText.Text = "Please enter name and passport number";
            }
            else if (noAdults == "" || noKids == "")
            {
                statusText.Text = "Please enter Number of pax";
            }
            else if (selectedList == null)
            {
                statusText.Text = "Please select room.";
            }
            else if (checkIn == null || checkOut == null)
            {
                statusText.Text = "Please enter date.";
            }
            else
            {
                DateTime chkIN = checkIn.Value.DateTime;
                DateTime chkOUT = checkOut.Value.DateTime;

                //HotelRoom clicked = (HotelRoom)selectedRooms.SelectedItem ;
                
                //availList.Remove(clicked);
                //selectedList.Remove(clicked);

                Stay stay = new Stay(chkIN, chkOUT);

                for(int i=0; i < guestList.Count; i++)
                {
                    if (name == guestList[i].Name && passport == guestList[i].PpNumber)
                    {
                        
                        guestList[i].IsCheckedIn = true;
                        guestList[i].Hotel = stay;
                        
                        foreach( HotelRoom room in selectedList)
                        {
                            unavailList.Add(room);
                            
                        }
                        foreach( HotelRoom room in unavailList)
                        {
                            room.IsAvail = false;
                            stay.AddRoom(room);
                            selectedList.Remove(room);
                        }

                        
                        
                        statusText.Text = "Checked in successfully";

                    }
                    else
                    {
                        
                        Membership member = new Membership("Ordinary", 0);
                        Guest guest = new Guest(name, passport, stay, member, true);
                        guestList.Add(guest);

                        foreach (HotelRoom room in selectedList)
                        {
                            unavailList.Add(room);

                        }
                        foreach (HotelRoom room in unavailList)
                        {
                            room.IsAvail = false;
                            stay.AddRoom(room);
                            selectedList.Remove(room);
                        }

                        

                    }
                    RefreshListViews();
                    RefreshTextBox();

                }
            }
            //validate the textbox!!!!!
            

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
                //availList.Remove(clicked);

                RefreshListViews();


                // for remove button is oppside

                //standard room: wifi + breakfast 
                if ( clicked is StandardRoom)
                {
                    StandardRoom room = (StandardRoom)clicked; // DOWNCASTING
                    if(bed.IsChecked == true)
                    {
                        statusText.Text = "Standard Room do not have the add bed feature";

                        selectedList.Remove(clicked);
                        //availList.Add(clicked);
                        selectedRooms.ItemsSource = selectedList;

                    }
                    else if (wifi.IsChecked == true && breakfast.IsChecked == true)
                    {
                        room.RequireWifi = true;
                        room.RequireBreakfast = true;

                        availList.Remove(clicked);
                    }
                    else if(wifi.IsChecked == true && breakfast.IsChecked == false)
                    {
                        room.RequireWifi = true;
                        room.RequireBreakfast = false;

                        availList.Remove(clicked);
                    }
                    else if (wifi.IsChecked == false && breakfast.IsChecked == true)
                    {
                        room.RequireWifi = false;
                        room.RequireBreakfast = true;

                        availList.Remove(clicked);
                    }
                    else if (wifi.IsChecked == false && breakfast.IsChecked == false)
                    {
                        room.RequireWifi = false;
                        room.RequireBreakfast = false;

                        availList.Remove(clicked);

                    }                   
                }

                if( clicked is DeluxeRoom)
                {
                    DeluxeRoom room = (DeluxeRoom)clicked; // DOWNCASTING
                    if (wifi.IsChecked == true)
                    {
                        statusText.Text = "Deluxe Room do not have the add wifi feature";

                        selectedList.Remove(clicked);
                        //availList.Add(clicked);
                        selectedRooms.ItemsSource = selectedList;
                    }
                    if (breakfast.IsChecked == true)
                    {
                        statusText.Text = "Standard Room do not have the add breakfast feature";

                        selectedList.Remove(clicked);
                        //availList.Add(clicked);
                        selectedRooms.ItemsSource = selectedList;
                    }
                    if (bed.IsChecked == true)
                    {
                        room.AdditionalBed = true;

                        availList.Remove(clicked);
                    }
                    if (bed.IsChecked == false)
                    {
                        room.AdditionalBed = false;

                        availList.Remove(clicked);
                    }

                }
                RefreshListViews();
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

        private void availableList_SelectionChanged(object sender, SelectionChangedEventArgs e) // Press wrong
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

        private void checkOutBtn_Click(object sender, RoutedEventArgs e)
        {
            string name, passport;

            name = guestNameTxt.Text;
            passport = passportNoTxt.Text;

            foreach (Guest g in guestList)
            {
                if (passport == g.PpNumber)
                {
                    if(g.IsCheckedIn == false)
                    {
                        statusText.Text = "You have not checked in";
                    }
                    else
                    {
                        g.IsCheckedIn = false;
                        //g.Hotel.RoomList.Remove();

                    }        

                }
                /*else
                {

                    stay.AddRoom(clicked);

                    Membership member = new Membership("Ordinary", 0);
                    Guest guest = new Guest(name, passport, stay, member, true);
                    guestList.Add(guest);

                }*/
            }



        }
    }
}
