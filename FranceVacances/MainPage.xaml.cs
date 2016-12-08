using FranceVacances.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FranceVacances.Models;
using FranceVacances.ModelView;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FranceVacances
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow); //content under appbar

            


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            EmbeddedFrame.Navigate(typeof(Home), null);
        }



        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as HyperlinkButton;
            var check = button.Content as TextBlock;
            
            switch (check.Text)
            {
                default:
                    break;

                case "About":
                    {
                        Popup1.IsOpen = true;
                        EmbeddedFrame.Opacity = 0.3;
                        break; 
                    }
                case "Summer":
                    EmbeddedFrame.Navigate(typeof(Filters), "Summer");
                    break;
                case "Winter":
                    EmbeddedFrame.Navigate(typeof(Filters), "Winter");
                    break;
                case "Italy":
                    EmbeddedFrame.Navigate(typeof(Filters), "Italy");
                    break;
                case "France":
                    EmbeddedFrame.Navigate(typeof(Filters), "France");
                    break;
                case "Spain":
                    EmbeddedFrame.Navigate(typeof(Filters), "Spain");
                    break;
                case "England":
                    EmbeddedFrame.Navigate(typeof(Filters), "England");
                    break;
            }
        }

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            Button but = new Button();
            but = sender as Button;

            switch (but.Name.ToString())
            {
                default:
                    break;

                case "Forward":
                    if (EmbeddedFrame.CanGoForward)
                    {
                        EmbeddedFrame.GoForward();
                    }

                    break;
                case "Back":
                    if (EmbeddedFrame.CanGoBack)
                    {
                        EmbeddedFrame.GoBack();
                    }
                    break;

                case "Home":
                    EmbeddedFrame.Navigate(typeof(Home), null);
                    break;

                case "AppBar":
                        if (!this.TopAppBar.IsOpen)
                    {
                        this.TopAppBar.IsOpen = true;
                    }
                    else
                    {
                        this.TopAppBar.IsOpen = false;
                    }
                    break;
            }
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                //sender.ItemsSource = dataset;
                var modelViewInstance = new ModelView.ModelView();
                var RentalList = modelViewInstance.Rentals;
                var listItems = from rent in RentalList
                                where rent.Season.ToUpper().Contains(sender.Text.ToString().ToUpper()) ||
                                       rent.Name.ToUpper().Contains(sender.Text.ToString().ToUpper()) ||
                                       rent.Country.ToUpper().Contains(sender.Text.ToString().ToUpper()) ||
                                       rent.Description.ToUpper().Contains(sender.Text.ToString().ToUpper()) ||
                                       rent.Country.ToUpper().Contains(sender.Text.ToString().ToUpper())
                                select rent;
                sender.ItemsSource = listItems.ToList();



            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
                var input = args.ChosenSuggestion as RentalModel;
                EmbeddedFrame.Navigate(typeof(RentalDetails), input);
            }
            else
            {
                // Use args.QueryText to determine what to do.
                EmbeddedFrame.Navigate(typeof(Filters),args.QueryText);
            }
        }


        private void ClosePopUp_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
            EmbeddedFrame.Opacity = 1;
        }

        private void EmbeddedFrame_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Popup1.IsOpen = false;
            EmbeddedFrame.Opacity = 1;
        }
    }
}
