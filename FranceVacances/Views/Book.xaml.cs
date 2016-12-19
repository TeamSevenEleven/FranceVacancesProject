using FranceVacances.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FranceVacances.ModelView;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FranceVacances.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Book : Page
    {
        RentalModel SentRental { get; set; }
        public Book()
        {
            this.InitializeComponent();
            this.DataContext = new ModelView.ModelView();
            Calendar.MinDate = DateTime.Now;
            Calendar.MaxDate = Calendar.MinDate.AddMonths(6);


        }

        private void Calendar_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            foreach (var month in SentRental.BookedDays.Keys)
            {
                foreach (var day in SentRental.BookedDays[month])
                {
                    if (args.Item.Date.Month == month && args.Item.Date.Day == day)
                    {
                        args.Item.IsBlackout = true;
                        args.Item.Background = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                    }
                }
            }           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RentalModel sentRental = e.Parameter as RentalModel;
            SentRental = sentRental;
            title.Text = sentRental.Name;
            price.Text = sentRental.Price.ToString();


        }

        private void checkout_Click(object sender, RoutedEventArgs e)
        {
            BookingModel bookedOffer;
            bookedOffer = new BookingModel();
            bookedOffer.Id = SentRental.id;
            
            foreach (var date in Calendar.SelectedDates)
            {
                ModelView.ModelView.Rentals[SentRental.id - 1].BookedDays[date.Month].Add(date.Day);
    //            bookedOffer.BookedDays = 
            }

            Frame.Navigate(typeof(Home), null);
        }

        private void bookDaysButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Calendar.Visibility == Visibility.Visible)
                Calendar.Visibility = Visibility.Collapsed;
            else
                Calendar.Visibility = Visibility.Visible;
           
        }

        private void clearbutton_Click(object sender, RoutedEventArgs e)
        {
            Calendar.SelectedDates.Clear();
        }

        private void Calendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            total.Text = "Total price: " + (sender.SelectedDates.Count * SentRental.Price) + "$";
        }

        private void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (toggleSwitch.IsOn == true)
            {
                user.Visibility = Visibility.Collapsed;
                pass.Visibility = Visibility.Collapsed;
                email.Visibility = Visibility.Collapsed;
                phone.Visibility = Visibility.Collapsed;
                passwordcheck.Visibility= Visibility.Collapsed;
                DateOfBirth.Visibility = Visibility.Collapsed;
            }
            else
            {
                user.Visibility = Visibility.Visible;
                pass.Visibility = Visibility.Visible;
                email.Visibility = Visibility.Visible;
                phone.Visibility = Visibility.Visible;
                passwordcheck.Visibility = Visibility.Visible;
                DateOfBirth.Visibility = Visibility.Collapsed;
            }
        }
    }
}
