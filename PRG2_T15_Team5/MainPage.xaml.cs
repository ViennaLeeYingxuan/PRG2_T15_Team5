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
        List<HotelRoom> checkList = new List<HotelRoom>(); // never use until
        List<HotelRoom> selectedList = new List<HotelRoom>();
        List<HotelRoom> unavailList = new List<HotelRoom>();
        List<HotelRoom> resetList = new List<HotelRoom>();


        public MainPage()
        {
            this.InitializeComponent();
            //checkInDate.value
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
            memberStatusTxt.Text = "";
            pointAvilTxt.Text = "";
            redeemPoint.Text = "";
        }

        public void RefreshInvoice()
        {
            invoiceTxt.Text = "";
        }

        private void checkInBtn_Click(object sender, RoutedEventArgs e)
        {
            string name, passport, noAdults, noKids;

            name = guestNameTxt.Text.ToUpper().Trim();
            passport = passportNoTxt.Text.ToUpper().Trim();
            noAdults = numAdultTxt.Text;
            noKids = numChildTxt.Text;

            var checkIn = checkInDate.Date;
            var checkOut = checkOutDate.Date;

            if (name == "" || passport == "")
            {
                statusText.Text = "Please enter name and passport number";
            }
            else if (passport.Length != 9)
            {
                statusText.Text = "Please enter correct passport number";
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

                bool checker = true;

                Stay stay = new Stay(chkIN, chkOUT);

                for (int i = 0; i < guestList.Count; i++)
                {
                    if (name == guestList[i].Name && passport == guestList[i].PpNumber)
                    {
                        guestList[i].IsCheckedIn = true;
                        guestList[i].Hotel = stay;

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

                        checker = false;
                    }
                }

                if (checker == true)
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
                statusText.Text = "Checked in successfully";
                RefreshListViews();
                RefreshTextBox();
                unavailList.Clear();
            }

        }

        private void checkRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            string adult = numAdultTxt.Text;
            string kid = numChildTxt.Text;

            if (adult != "" && kid != "")
            {
                statusText.Text = "";
                int adultno = Convert.ToInt32(adult);
                int kidno = Convert.ToInt32(kid);

                var checkIn = checkInDate.Date;
                var checkOut = checkOutDate.Date;

                if (checkIn != null && checkOut != null)
                {
                    foreach (HotelRoom room in hotelList)
                    {
                        if (room.IsAvail == true)
                        {
                            availList.Add(room);
                            availableList.ItemsSource = availList;
                        }
                    }
                }
                else
                {
                    statusText.Text = "Please input date";
                }
            }
            else 
            {
                statusText.Text = "Please enter the number of adults and children.";
            }
        }   

        private void addRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            HotelRoom clicked = (HotelRoom)availableList.SelectedItem;
            if (clicked != null)
            {
                availableList.ItemsSource = null; 
                selectedList.Add(clicked);
                selectedRooms.ItemsSource = selectedList;

                RefreshListViews();
 
                if ( clicked is StandardRoom)
                {
                    StandardRoom room = (StandardRoom)clicked; // DOWNCASTING
                    if(bed.IsChecked == true)
                    {
                        statusText.Text = "Standard Room do not have the add bed feature";

                        selectedList.Remove(clicked);
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
                        selectedRooms.ItemsSource = selectedList;
                    }
                    if (breakfast.IsChecked == true)
                    {
                        statusText.Text = "Standard Room do not have the add breakfast feature";

                        selectedList.Remove(clicked);
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

        }

        private void availableList_SelectionChanged(object sender, SelectionChangedEventArgs e) // Press wrong
        {

        }

        private void removeRoomBtn_Click_1(object sender, RoutedEventArgs e)
        {
            HotelRoom clicked = (HotelRoom)selectedRooms.SelectedItem;
            if (clicked != null)
            {

                selectedRooms.ItemsSource = null;
                selectedList.Remove(clicked);
                selectedRooms.ItemsSource = selectedList;
                availList.Add(clicked);

                RefreshListViews();
            }

        }

        private void checkOutBtn_Click(object sender, RoutedEventArgs e)
        {
            
            string name = guestNameTxt.Text.ToUpper().Trim();
            string passportNo = passportNoTxt.Text.ToUpper().Trim();

            if (name == "" )
            {
                statusText.Text = "Enter name or passport number";
            }
            else
            {
                foreach (Guest guest in guestList)
                {

                    if (guest.Name == name || guest.PpNumber == passportNo)
                    {
                        statusText.Text = guest.Name;
                        selectedRooms.ItemsSource = null;
                        selectedRooms.ItemsSource = guest.Hotel.RoomList;

                        foreach (HotelRoom room in guest.Hotel.RoomList)
                        {

                            resetList.Add(room);

                        }

                        foreach (HotelRoom r in resetList)
                        {
                            r.IsAvail = true;

                            if (r is StandardRoom)
                            {
                                StandardRoom room = (StandardRoom)r;
                                room.RequireBreakfast = false;
                                room.RequireWifi = false;
                            }
                            else if (r is DeluxeRoom)
                            {
                                DeluxeRoom room = (DeluxeRoom)r;
                                room.AdditionalBed = false;
                            }

                            guest.Hotel = null;
                            guest.IsCheckedIn = false;

                            selectedRooms.ItemsSource = null;
                            availList.Add(r);
                            selectedList.Remove(r);
                            unavailList.Remove(r);
                            availableList.ItemsSource = availList;
                            RefreshListViews();
                            RefreshInvoice();
                            RefreshTextBox();

                            statusText.Text = "Checked out successfully";

                        }
                        break;
                    }
                    else
                    {
                        statusText.Text = "No guest exist";
                    }

                    //ADVANCE

                    guest.Hotel = null;

                    double difference = (guest.Hotel.CheckOutnDate - guest.Hotel.CheckInDate).Days;

                    for (int i = 0; i < guest.Hotel.RoomList.Count; i++)
                    {
                        double price = 0;

                        foreach (HotelRoom room in guest.Hotel.RoomList)
                        {
                            if (room is StandardRoom)
                            {
                                price += (room.CalculateCharges() * difference);
                                guest.Membership.Points += (int)price / 10;
                                pointAvilTxt.Text = guest.Membership.Points.ToString();
                            }
                            if (room is DeluxeRoom)
                            {
                                price += (room.CalculateCharges() * difference);
                                guest.Membership.Points += (int)price / 10;
                            }
                        }
                    }

                    if (guest.Membership.Points >= 100 && guest.Membership.Status != "Silver")
                    {
                        guest.Membership.Status = "Silver";

                    }
                    else if (guest.Membership.Points >= 200)
                    {
                        guest.Membership.Status = "Gold";
                    }
                    else
                    {
                        guest.Membership.Status = "Ordinary";
                    }

                    //ADVANCE

                    if (redeemPoint.Text == null)
                    {
                        redeemPoint.Text = "0";
                    }

                    string redeem = redeemPoint.Text;
                    int points = Convert.ToInt32(redeem);
                    guest.Membership.Points -= points;

                }
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshListViews();
            string searchName = guestNameTxt.Text.ToUpper().Trim();
            string searchPassportNo = passportNoTxt.Text.ToUpper().Trim();

            foreach (Guest guest in guestList)
            {
                if (guest.Name == searchName || guest.PpNumber == searchPassportNo)
                {
                    if (guest.IsCheckedIn == false)
                    {
                        statusText.Text = "You have not checked in any rooms";
                    }
                    else
                    {
                        statusText.Text = guest.Name;
                        selectedRooms.ItemsSource = null;
                        selectedRooms.ItemsSource = guest.Hotel.RoomList;

                        double difference = (guest.Hotel.CheckOutnDate - guest.Hotel.CheckInDate).Days;
                        string addrequest = "null";

                        for (int i = 0; i < guest.Hotel.RoomList.Count; i++)
                        {
                            double price = 0;


                            foreach (HotelRoom room in guest.Hotel.RoomList)
                            {
                                if (room is StandardRoom)
                                {
                                    StandardRoom standard = (StandardRoom)room;
                                    if (standard.RequireWifi is true)
                                    {
                                        addrequest = "Wifi";
                                    }
                                    else if (standard.RequireBreakfast is true)
                                    {
                                        addrequest = "Breakfast";
                                    }

                                    price += (room.CalculateCharges() * difference);

                                }
                                if (room is DeluxeRoom)
                                {
                                    DeluxeRoom deluxe = (DeluxeRoom)room;
                                    if (deluxe.AdditionalBed is true)
                                    {
                                        addrequest = "Additional Bed";
                                    }

                                    price += (room.CalculateCharges() * difference);
                                }

                                invoiceTxt.Text = $"Name: {guest.Name} \n Passport Number {guest.PpNumber} \n Number of Nights: {difference} \n Additional Request: {addrequest} \n Total Amount: $ {price} ";

                                if (guest.Membership.Points >= 200)
                                {
                                    memberStatusTxt.Text = "Gold";
                                    pointAvilTxt.Text = guest.Membership.Points.ToString();
                                }
                                else if (guest.Membership.Points >= 100)
                                {
                                    memberStatusTxt.Text = "Silver";
                                    pointAvilTxt.Text = guest.Membership.Points.ToString();
                                }
                                else
                                {
                                    memberStatusTxt.Text = "Ordinary";
                                    pointAvilTxt.Text = guest.Membership.Points.ToString();
                                }
                            }
                        }
                    }
                    break;
                }

                else
                {
                    statusText.Text = "No customer found";
                }

            }

        }

        private void display_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void redeemPointBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = guestNameTxt.Text.ToUpper().Trim();
            string passport = passportNoTxt.Text.ToUpper().Trim();
            string redeem = redeemPoint.Text;
            if (name == "")
            {
                statusText.Text = "Enter name or passport name";
            }
            else if (redeem == "")
            {
                redeem = "0";
            }
            else
            { 
                int points = Convert.ToInt32(redeem);
                foreach (Guest guest in guestList)
                {
                    if (name == guest.Name)
                    {
                        if (guest.Membership.Status != "ordinary")
                        {
                            statusText.Text = guest.Membership.Points.ToString();
                            string display = "";
                            if (guest.Membership.Points >= points)
                            {

                                TimeSpan days = guest.Hotel.CheckOutnDate.Date.Subtract(guest.Hotel.CheckInDate);
                                int n = (int)days.TotalDays;
                                double total = 0;
                                display += $"Number of nights: {n}\n";
                                foreach (HotelRoom room in guest.Hotel.RoomList)
                                {
                                    double rate = room.CalculateCharges();
                                    double cost = rate * n;
                                    double pointr = points / 10;
                                    total += cost - pointr;

                                    display += "additional requirements:\n";
                                    if (room is StandardRoom)
                                    {
                                        StandardRoom rm = (StandardRoom)room;
                                        if (rm.RequireBreakfast == true)
                                        {
                                            display += "require breakfast\n";
                                        }
                                        if (rm.RequireWifi == true)
                                        {
                                            display += "require wifi\n";
                                        }
                                    }
                                    else if (room is DeluxeRoom)
                                    {
                                        DeluxeRoom rm = (DeluxeRoom)room;
                                        if (rm.AdditionalBed == true)
                                        {
                                            display += "additional bed\n";
                                        }
                                    }
                                    else
                                    {
                                        display += "null";
                                    }
                                }
                                display += $"Total Cost: ${total}";
                                invoiceTxt.Text = display;
                                //int newpoints = guest.Membership.Points - points;
                                //string convert = newpoints.ToString();
                                //pointAvilTxt.Text = convert;
                                //redeemPoint.Text = "";
                                //statusText.Text = guest.Membership.Points.ToString();
                                guest.Membership.Points -= points;
                                pointAvilTxt.Text = guest.Membership.Points.ToString();

                                redeemPoint.Text = "";
                            }
                            else
                            {
                                statusText.Text = "Not enough points";
                            }
                        }
                    }
                }
            }
        }

        private void extendBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = guestName.Text;
            string passport = passportNoTxt.Text;

            foreach(Guest guest in guestList)
            {
                if (passport == guest.PpNumber || name == guest.Name)
                {
                    guest.Hotel.CheckOutnDate = guest.Hotel.CheckOutnDate.AddDays(1);
                    statusText.Text = "You just extended your stay by 1 day";

                    break;
                }
                else
                {
                    statusText.Text = "Unavailable";
                }
            }

        }
    }
}



