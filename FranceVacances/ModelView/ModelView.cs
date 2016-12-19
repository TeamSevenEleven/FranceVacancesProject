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
    
    public sealed class ModelView 
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
            Rentals.Add(new RentalModel(1, "Grand Palace", "Britain", 950.5, 32, address, new Dictionary<int, List<int>>
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
            Rentals.Add(new RentalModel(2,"Hotel 2", "France", 1360, 32, address, new Dictionary<int, List<int>>
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
            Rentals.Add(new RentalModel(3,"Hotel 3", "France", 200, 32, address, new Dictionary<int, List<int>>
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

            }, "summer", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.pageresource.com/wallpapers/wallpaper/fontainebleau-hotel-miami-beach-hd.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSoTkpmbNhS_vl_jM0d5qYo-g0bv4_FYSDh6Leuc1ofCrvoiCY1", "http://www.belcekiz.com/wp-content/uploads/pool-view-1920x750.jpg","http://www.thetimes.co.uk/tto/multimedia/archive/00379/120531599_cool_379417c.jpg" }, null));
            Rentals.Add(new RentalModel(4,"Hotel 4", "France", 320, 32, address, new Dictionary<int, List<int>>
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

            }, "Summer", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.belcekiz.com/wp-content/uploads/pool-view-1920x750.jpg","http://www.thetimes.co.uk/tto/multimedia/archive/00379/120531599_cool_379417c.jpg", "http://www.mrwallpaper.com/wallpapers/resort-villas-1366x768.jpg", "http://confidenceconcierge.com/wp-content/uploads/2016/05/villadenoche.jpg" }, null));
            Rentals.Add(new RentalModel(5,"Hotel 5", "Spain", 890.7, 32, address, new Dictionary<int, List<int>>
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

            }, "Summer", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://summerpalace.mitsishotels.com/sites/summerpalace.mitsishotels.com/files/summer-palace-mitsis-hotels-greece-home-facilities-7.jpg", "https://i.ytimg.com/vi/hDIKOdcj55M/maxresdefault.jpg", "https://www.purpletravel.co.uk/images/hotels_new/2630/Mitsis-Summer-Palace-9.jpg" }, null));
            Rentals.Add(new RentalModel(6,"Hotel 6", "Spain", 200, 32, address, new Dictionary<int, List<int>>
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

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "https://c2.staticflickr.com/6/5498/10651882845_0a44029947_b.jpg", "https://i.ytimg.com/vi/lZEbroQh3CU/maxresdefault.jpg", "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQf8-iyI-XZpds1VNYP7bkYKcxLpoafJ6J-06VvcZP-cf0qQFiu" }, null));
            Rentals.Add(new RentalModel(7,"Hotel 7", "Spain", 600, 32, address, new Dictionary<int, List<int>>
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

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://architectureimg.com/wp-content/uploads/2016/08/houses-swiss-village-snow-german-christmas-winter-town-wide-resolution-1920x1080.jpg", "https://upload.wikimedia.org/wikipedia/commons/5/50/GstaadPanoramaVillage.jpg"}, null));
            Rentals.Add(new RentalModel(8,"Hotel 8", "Spain", 1000, 32, address, new Dictionary<int, List<int>>
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

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "https://www.whistler.com/images/itineraries/winter/five-star-hotel.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwRW6Rr68kmLYxsOE6nxlUFsgMD7EAkGpWwTIcbkWt3SAdawOj", "https://www.google.dk/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwirqJfi84DRAhWBBywKHUKtAqEQjRwIBw&url=http%3A%2F%2Fboredinvancouver.com%2Flisting%2F10-best-weekend-trips-from-vancouver%2F&psig=AFQjCNHDtOVC5LztiTgBNiAyTJN-DDwd0w&ust=1482259086453563" }, null));
            Rentals.Add(new RentalModel(9,"Hotel 9", "Spain", 30, 32, address, new Dictionary<int, List<int>>
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

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.pageresource.com/wallpapers/wallpaper/fontainebleau-hotel-miami-beach-hd.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSoTkpmbNhS_vl_jM0d5qYo-g0bv4_FYSDh6Leuc1ofCrvoiCY1", "http://www.belcekiz.com/wp-content/uploads/pool-view-1920x750.jpg" }, null));
            Rentals.Add(new RentalModel(10,"Hotel 10", "Spain", 620, 32, address, new Dictionary<int, List<int>>
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

            }, "winter", 3, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. ", null, new List<string>() { "http://www.pixelstalk.net/wp-content/uploads/2016/10/Santorini-luxury-hotels-wallpaper-hd.jpg", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSBRCzEcB_YxmXw8HhkXZn84VeowX9XvL7vrRxFJpREDkSPM-BD", "https://4kwallpapers.co/wp-content/uploads/2015/07/santorini-cyclades-islands-aegean-sea-greece-ultra-hd-wallpaper.jpg" }, null));

        }
        
        




    }
}
