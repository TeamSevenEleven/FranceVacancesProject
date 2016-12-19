using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacances.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string _name,string _password,DateTime _dateofbirth,string _email, string _phonenumber, ObservableCollection<RentalModel> _boughtOffers,double _topay)
        {
            Name = _name;
            Password = _password;
            DateOfBirth = _dateofbirth;
            Email = _email;
            PhoneNumber = _phonenumber;
            BoughtOffers = _boughtOffers;
            ToPay = _topay;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ObservableCollection<RentalModel> BoughtOffers
        {
            get;
            set;
        }
        public double ToPay { get; set; }
    }
}