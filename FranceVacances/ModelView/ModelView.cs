using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacances.Models;
using System.Collections.ObjectModel;
using FranceVacances.Views;
using FranceVacances.Persistency;
using Windows.Storage;
using System.IO;

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
        public ModelView()
        {
            DataCreation();
        }

        public async void DataCreation()
        {
            SaveRentals helper = new SaveRentals();
            bool isfile = File.Exists(ApplicationData.Current.LocalFolder.Path + @"/offers.json");
            if ((isfile == true))
                try
                {
                    if ((new FileInfo(ApplicationData.Current.LocalFolder.Path + @"/offers.json").Length) < 500)
                    {
                        PopulateWithData();
                        await helper.SerializeRentals(Rentals);
                    }
                    Rentals = await helper.DeserializeRentals();
                }
                catch
                {
                    throw new Exception("An error was encountered while loading the data");
                }
            else
                try
                {

                    await helper.SerializeRentals(Rentals);
                }
                catch
                {
                    throw new Exception("An error was encountered while saving the data");
                }
}
        public static void PopulateWithData()
        {
            List<string> address = new List<string>();
            address.Add("Street 1");
            address.Add("4444");
            address.Add("Town");
            address.Add("France");
            Rentals.Add(new RentalModel(1, "Grand Palace", "Britain", 45645.45f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "Summer", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>()
            { "https://theluxurytravelexpert.files.wordpress.com/2015/11/banyan-tree-phuket.jpg",
                "https://theluxurytravelexpert.files.wordpress.com/2015/11/mandarin-oriental-bangkok.jpg",
                "https://theluxurytravelexpert.files.wordpress.com/2015/11/rayavadee-krabi.jpg" }, null ));
            Rentals.Add(new RentalModel(2,"Hotel 2", "France", 150.32f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://explorationsltd.com/wp-content/uploads/2013/04/lefaypool.jpg" }, null));
            Rentals.Add(new RentalModel(3,"Hotel 3", "France", 132f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.thetimes.co.uk/tto/multimedia/archive/00379/120531599_cool_379417c.jpg" }, null));
            Rentals.Add(new RentalModel(4,"Hotel 4", "France", 15550.78f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "Summer", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "/Images/image1.jpg" }, null));
            Rentals.Add(new RentalModel(5,"Hotel 5", "Spain", 15230.32f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.w3schools.com/css/trolltunga.jpg" }, null));
            Rentals.Add(new RentalModel(6,"Hotel 6", "Spain", 15230.32f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.w3schools.com/css/trolltunga.jpg" }, null));
            Rentals.Add(new RentalModel(7,"Hotel 7", "Spain", 15230.32f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.w3schools.com/css/trolltunga.jpg" }, null));
            Rentals.Add(new RentalModel(8,"Hotel 8", "Spain", 15230.32f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.w3schools.com/css/trolltunga.jpg" }, null));
            Rentals.Add(new RentalModel(9,"Hotel 9", "Spain", 15230.32f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.w3schools.com/css/trolltunga.jpg" }, null));
            Rentals.Add(new RentalModel(10,"Hotel 10", "Spain", 15230.32f, 32, address, new Dictionary<int, List<int>>
            {
                {1, new List<int>() },
                {2, new List<int>() },
                {3, new List<int>() },
                {4, new List<int>() },
                {5, new List<int>() },
                {6, new List<int>() },
                {7, new List<int>() },
                {8, new List<int>() },
                {9, new List<int>() },
                {10, new List<int>() },
                {11, new List<int>() },
                {12, new List<int>() },

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.w3schools.com/css/trolltunga.jpg" }, null));

        }
        
        




    }
}
