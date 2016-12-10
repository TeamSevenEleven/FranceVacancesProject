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
using FranceVacances.Models;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FranceVacances.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RentalDetails : Page
    {
        public RentalDetails()
        {
            this.InitializeComponent();

        }

         RentalModel rentalObject {get;set;}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RentalModel clickedRental = e.Parameter as RentalModel;
            rentalObject = clickedRental;
            Country.Text = clickedRental.Country;
            Name.Text = clickedRental.Name;
            Season.Text = clickedRental.Season;
            Street.Text = clickedRental.Address[0];
            City.Text = clickedRental.Address[1];
            Zip.Text = clickedRental.Address[2];
            AddressCountry.Text = clickedRental.Address[3];

            

            foreach (string value in clickedRental.ImagePaths)
            {
                BitmapImage temp = new BitmapImage(new Uri(value));
                Image tempimg = new Image();
                tempimg.Source = temp;

                gallery.Items.Add(tempimg);
            }


            
//            gallery.SelectionChanged += FlipView_SelectionChanged;
 //           img.UriSource = new Uri(clickedRental.ImagePath);
 //           Image.Source = img;


            Price.Text = clickedRental.Price.ToString() + "$";
            Street.Text = clickedRental.Address[0];
            Description.Text = clickedRental.Description;

        }

        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            Frame.Navigate(typeof(Book),rentalObject);
        }
    }
}
