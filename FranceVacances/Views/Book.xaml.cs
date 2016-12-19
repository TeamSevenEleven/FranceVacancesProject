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
using Windows.UI.Xaml.Media.Imaging;
using System.Text.RegularExpressions;
using Windows.UI.Popups;
using FranceVacances.Persistency;
using Windows.Storage;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FranceVacances.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Book : Page
    {
        private static ObservableCollection<User> _users = new ObservableCollection<User>();
        public static ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public double totaltopay
        {
            get; set;
        }
        RentalModel SentRental { get; set; }
        public Book()
        {
            this.InitializeComponent();
            this.DataContext = new ModelView.ModelView();
            Calendar.MinDate = DateTime.Now;
            Calendar.MaxDate = Calendar.MinDate.AddMonths(6);
            DateOfBirth.MaxDate = DateTime.Now;
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
            string Price = "Price per day: " + (sentRental.Price).ToString("N") + "$";
            price.Text = Price;

            BitmapImage temp = new BitmapImage(new Uri(sentRental.ThumbnailPath));
            image.Source = temp;

            UserHelper();
        }



        public async void UserHelper()
        {
            SaveUsers helper = new SaveUsers();
            bool isfile = File.Exists(ApplicationData.Current.LocalFolder.Path + @"/users.json");
            if (isfile==true)
                try
                {
                    if ((new FileInfo(ApplicationData.Current.LocalFolder.Path + @"/users.json").Length) < 500)
                    {
                        DefaultAccount();
                        await helper.SerializeUsers(Users);
                    }
                        Users = await helper.DeserializeUsers();
                }
                catch
                {
                    throw new Exception("An error was encountered while loading the users");
                }
            else
                try
                {
                    await helper.SerializeUsers(Users);
                    
                }
                catch
                {
                    throw new Exception("An error was encountered while saving the users");
                }
        }

        public static bool IsAccountAvailable(string _user, string _email)
        {
            foreach (var user in Users)
            {
                if (user.Name == _user || user.Email == _email)
                {
                    return false;
                }
            }
                return true;
        }

        public void Login(string _username,string _password)
        {
  
            User temp;
            foreach (var user in Users)
                if ((user.Name == _username) && (user.Password == _password))
                    {
                        temp = user;
                        foreach (var date in Calendar.SelectedDates)
                        {
                            ModelView.ModelView.Rentals[SentRental.id - 1].BookedDays[date.Month].Add(date.Day);
                            SentRental.BookedDays[date.Month].Add(date.Day);
                        }
                        temp.BoughtOffers.Add(SentRental);
                    Users.Remove(temp);
                    Users.Add(temp);
                    info.Text = "Purchase succesfull.";
                    SaveUsers userhelper = new SaveUsers();
                    userhelper.SerializeUsers(Users);
                    l_password.Visibility = Visibility.Collapsed;
                    l_username.Visibility = Visibility.Collapsed;
                    checkout.Visibility = Visibility.Collapsed;
                    toggleSwitch.Visibility = Visibility.Collapsed;
                    break;
                }
                else
                {
                    info.Text = "Username / password invalid.";
                }
            

        }
        public int CreateAccount(string _user, string _password,string _passwordCheck, string _email, string _phone,DateTime _dateofbirth)
        {
            if(IsAccountAvailable(_user,_email)==true)
            {
                ObservableCollection<RentalModel> _nopurchase = new ObservableCollection<RentalModel>();
                User temp;
                if (_user.Length == 0)
                    info.Text = "Please enter a Username.";
                else if ((_password != _passwordCheck) || (_password.Length == 0))
                    info.Text = "Please check the password.";
                else if ((_email.Length == 0) || (!Regex.IsMatch(_email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")))
                    info.Text = "Invalid E-Mail address.";
                else if (_phone.Length <= 6)
                    info.Text = "The phone number is invalid.";
                else
                {
                    foreach (var date in Calendar.SelectedDates)
                    {
                        ModelView.ModelView.Rentals[SentRental.id - 1].BookedDays[date.Month].Add(date.Day);
                        SentRental.BookedDays[date.Month].Add(date.Day);
                    }

                    ObservableCollection<RentalModel> boughtrentals = new ObservableCollection<RentalModel>();
                    boughtrentals.Add(SentRental);

                    temp = new User(_user, _password, _dateofbirth, _email, _phone, new ObservableCollection<RentalModel>(boughtrentals), totaltopay);
                    Users.Add(temp);


                    SaveRentals helper = new SaveRentals();
                    helper.SerializeRentals(ModelView.ModelView.Rentals);
                    SaveUsers userhelper = new SaveUsers();
                    userhelper.SerializeUsers(Users);
                    info.Text = "Purchase succesfull.";

                    RegisterView.Visibility = Visibility.Collapsed;
                    checkout.Visibility = Visibility.Collapsed;
                    toggleSwitch.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                info.Text = "The account already exists";
            }
            return 0;
        }
        private void DefaultAccount()
        {
            Users.Add(new User("adi97ida", "test", new DateTime(12 / 08 / 1997), "adi97ida@gmail.com", "71619045",new ObservableCollection<RentalModel>(), 0));
            Users.Add(new User("jeppe123", "test123", new DateTime(12 / 03 / 1995), "jeppe123@gmail.com", "13649045", new ObservableCollection<RentalModel>(),0));
            Users.Add(new User("adnantest", "123test", new DateTime(25 / 11 / 2000), "adnan@gmail.com", "42519045", new ObservableCollection<RentalModel>(),0));
        }

        private void checkout_Click(object sender, RoutedEventArgs e)
        {

            if(toggleSwitch.IsOn)
            {
                Login(l_username.Text, l_password.Text);
            }
            else
            {
                try
                {
                    string birth = DateOfBirth.Date.ToString();
                    DateTime _date = Convert.ToDateTime(birth);
                    CreateAccount(user.Text, pass.Text, passwordcheck.Text, email.Text, phone.Text, _date);
                }
                catch
                {
                    info.Text = "Please set the date of birth.";
                }
               
            }
            

 //           Frame.Navigate(typeof(Home), null);
        }

        private void bookDaysButton_Click(object sender, RoutedEventArgs e)
        {
            

        }


        private void clearbutton_Click(object sender, RoutedEventArgs e)
        {
            Calendar.SelectedDates.Clear();
        }

        private void Calendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            total.Text = "Total price: " + (sender.SelectedDates.Count * SentRental.Price).ToString("N") + "$";
            totaltopay = (sender.SelectedDates.Count * SentRental.Price);

        }

        private void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (toggleSwitch.IsOn == true)
            {
                RegisterView.Visibility = Visibility.Collapsed;
                loginView.Visibility = Visibility.Visible;
            }
            else
            {
                RegisterView.Visibility = Visibility.Visible;
                loginView.Visibility = Visibility.Collapsed;
            }
        }

        private void clearText(object sender, RoutedEventArgs e)
        {
            if (((sender as TextBox).Tag == null))
            {
                (sender as TextBox).Tag = (sender as TextBox).Text;
                (sender as TextBox).Text = string.Empty;
            }
        }

        private void restoreDefaultText(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = (sender as TextBox).Tag.ToString();
                (sender as TextBox).Tag = null;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
