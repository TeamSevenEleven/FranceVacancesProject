using System;
using System.Collections.Generic;
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
        public User(string _name,string _password,DateTime _dateofbirth,string _email, int _phonenumber, Dictionary<int,double> _boughtOffers)
        {
            Name = _name;
            Password = _password;
            DateOfBirth = _dateofbirth;
            Email = _email;
            PhoneNumber = _phonenumber;
            BoughtOffers = _boughtOffers;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public Dictionary<int, double> BoughtOffers { get; set; }
    }
}