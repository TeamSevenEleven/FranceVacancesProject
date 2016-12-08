using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacances.Models;
using System.Collections.ObjectModel;
using FranceVacances.Views;

namespace FranceVacances.ModelView
{
    class ModelView
    {
        private static ObservableCollection<RentalModel> _rentals = new ObservableCollection<RentalModel>();
        public static ObservableCollection<RentalModel> Rentals
        {
            get { return _rentals; }
            set { _rentals = value; }
        }

        public ModelView ()
        {
            Dictionary<int, List<int>> dates = new Dictionary<int, List<int>>
            {
                {1, new List<int>{1,2,7} },
                {2, new List<int> {5,6,7,8,9} }
            };
            List<string> address = new List<string>();
            address.Add("Street 1");
            address.Add("4444");
            address.Add("Town");
            address.Add("France");
            Rentals.Add(new RentalModel(1,"Hotel 1", "Britain", 45645.45, 32,address, dates, "Summer", 3, "Something description",null, "http://www.ma.com/wp-content/uploads/2013/10/morris-adjmi-architects-wythe-hotel-3.jpg", null ));
            Rentals.Add(new RentalModel(2,"Hotel 2", "France", 150.32, 32, address, dates, "winter", 3, "Something asdasfasf fssfasg sfas fasfg asf agasfa fagsdfsa fsadfas fgasda asfs", null, "http://explorationsltd.com/wp-content/uploads/2013/04/lefaypool.jpg", null));
            Rentals.Add(new RentalModel(3,"Hotel 3", "France", 132, 32, address, dates, "winter", 3, "Something asdafsf", null, "http://www.thetimes.co.uk/tto/multimedia/archive/00379/120531599_cool_379417c.jpg", null));
            Rentals.Add(new RentalModel(4,"Hotel 4", "France", 15550.78, 32, address, null, "Summer", 3, "Something hhhhh", null,"/Images/image1.jpg", null));
            Rentals.Add(new RentalModel(5,"Hotel 5", "Spain", 15230.32, 32, address,dates, "winter", 3, "Something jjj", null, "http://www.w3schools.com/css/trolltunga.jpg", null));
            Rentals.Add(new RentalModel(6,"Hotel 6", "Spain", 15230.32, 32, address, dates, "winter", 3, "Something jjj", null, "http://www.w3schools.com/css/trolltunga.jpg", null));
            Rentals.Add(new RentalModel(7,"Hotel 7", "Spain", 15230.32, 32, address, dates, "winter", 3, "Something jjj", null, "http://www.w3schools.com/css/trolltunga.jpg", null));
            Rentals.Add(new RentalModel(8,"Hotel 8", "Spain", 15230.32, 32, address, dates, "winter", 3, "Something jjj", null, "http://www.w3schools.com/css/trolltunga.jpg", null));
            Rentals.Add(new RentalModel(9,"Hotel 9", "Spain", 15230.32, 32, address, dates, "winter", 3, "Something jjj", null, "http://www.w3schools.com/css/trolltunga.jpg", null));
            Rentals.Add(new RentalModel(10,"Hotel 10", "Spain", 15230.32, 32, address, dates, "winter", 3, "Something jjj", null, "http://www.w3schools.com/css/trolltunga.jpg", null));
        }


       
        



    }
}
