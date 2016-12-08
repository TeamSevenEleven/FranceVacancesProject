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
using FranceVacances.ModelView;
using FranceVacances.Models;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FranceVacances.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Filters : Page
    {

        public Filters()
        {
            this.InitializeComponent();
            this.DataContext = new ModelView.ModelView();
            
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var RentalList = new ModelView.ModelView();
            var a = RentalList.Rentals;
            if(e.Parameter.ToString().ToUpper() == "SUMMER" || e.Parameter.ToString().ToUpper() == "WINTER")
            {
                var listItems = from rental in a
                                where rental.Season.ToUpper() == e.Parameter.ToString().ToUpper()
                                select rental;
                view.ItemsSource = listItems.ToList();

            } else
            {
                var listItems = from rental in a
                                where rental.Country.ToUpper() == e.Parameter.ToString().ToUpper()
                                select rental;
                view.ItemsSource = listItems.ToList();

                if (listItems.ToList().Count < 1)
                {
                    message.Text = "No results found";
                }

            }
         }

           



    

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            RentalModel clickedRental = e.ClickedItem as RentalModel;
            Frame.Navigate(typeof(RentalDetails), clickedRental);

        }
    }
}
