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
            address.Add("Street");
            address.Add("Zip");
            address.Add("City");
            address.Add("Country");

                
            Rentals.Add(new RentalModel(1, "The Palace Hotel", "Britain", 950.5, 32, address, new Dictionary<int, List<int>>
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
            }, "Summer", 3, "The hotel includes a leisure club with swimming pool, sauna, solarium, beauty salon and gym. ", null, new List<string>()
            { "https://theluxurytravelexpert.files.wordpress.com/2015/11/banyan-tree-phuket.jpg",
                "https://theluxurytravelexpert.files.wordpress.com/2015/11/mandarin-oriental-bangkok.jpg",
                "https://theluxurytravelexpert.files.wordpress.com/2015/11/rayavadee-krabi.jpg" }, null));

            Rentals.Add(new RentalModel(2, "Hotel de la rue de Lille", "France", 150, 32, address, new Dictionary<int, List<int>>
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

            }, "Winter", 3, "Includes Free Wifi, Air Conditioning and access to the Hotel's Bar. Hotel is also 0.7 km from Paris center!", null, new List<string>() { "http://explorationsltd.com/wp-content/uploads/2013/04/lefaypool.jpg" }, null));

            Rentals.Add(new RentalModel(3, "Gustave", "France", 200, 32, address, new Dictionary<int, List<int>>
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
            }, "Summer", 3, "Gustave is a pleasant hotel situated in a peaceful street close to the Eiffel Tower. Includes Free Wifi, Air Conditioning and access to the Hotel's Bar.", null, new List<string>() { "http://www.pageresource.com/wallpapers/wallpaper/fontainebleau-hotel-miami-beach-hd.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSoTkpmbNhS_vl_jM0d5qYo-g0bv4_FYSDh6Leuc1ofCrvoiCY1", "http://www.belcekiz.com/wp-content/uploads/pool-view-1920x750.jpg", "http://www.thetimes.co.uk/tto/multimedia/archive/00379/120531599_cool_379417c.jpg" }, null));

            Rentals.Add(new RentalModel(4, "Excelsior Latin", "France", 225.5, 32, address, new Dictionary<int, List<int>>
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

            }, "Summer", 3, "Experience Notre Dame within an easy walking distance of 0.8 km from the Hotel", null, new List<string>() { "http://www.belcekiz.com/wp-content/uploads/pool-view-1920x750.jpg", "http://www.thetimes.co.uk/tto/multimedia/archive/00379/120531599_cool_379417c.jpg", "http://www.mrwallpaper.com/wallpapers/resort-villas-1366x768.jpg", "http://confidenceconcierge.com/wp-content/uploads/2016/05/villadenoche.jpg" }, null));

            Rentals.Add(new RentalModel(5, "Barcelona Universal Hotel ", "Spain", 200, 32, address, new Dictionary<int, List<int>>
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

            }, "Summer", 3, "Barcelona Universal Hotel is positioned in central Barcelona and includes a rooftop pool and a rooftop terrace, a fitness center and a coffee bar.", null, new List<string>() { "http://summerpalace.mitsishotels.com/sites/summerpalace.mitsishotels.com/files/summer-palace-mitsis-hotels-greece-home-facilities-7.jpg", "https://i.ytimg.com/vi/hDIKOdcj55M/maxresdefault.jpg", "https://www.purpletravel.co.uk/images/hotels_new/2630/Mitsis-Summer-Palace-9.jpg" }, null));

            Rentals.Add(new RentalModel(6, "Olivia Plaza Hotel ", "Spain", 200, 32, address, new Dictionary<int, List<int>>
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

            }, "Winter", 3, "This 4-star hotel offers 24-hour room service and massage services.", null, new List<string>() { "https://c2.staticflickr.com/6/5498/10651882845_0a44029947_b.jpg", "https://i.ytimg.com/vi/lZEbroQh3CU/maxresdefault.jpg", "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQf8-iyI-XZpds1VNYP7bkYKcxLpoafJ6J-06VvcZP-cf0qQFiu" }, null));

            Rentals.Add(new RentalModel(7, "H10 Metropolitan", "Spain", 110, 32, address, new Dictionary<int, List<int>>
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

            }, "Winter", 3, "Conveniently located in the heart of the city, this 4-star hotel makes for an excellent base in Barcelona.", null, new List<string>() { "http://architectureimg.com/wp-content/uploads/2016/08/houses-swiss-village-snow-german-christmas-winter-town-wide-resolution-1920x1080.jpg", "https://upload.wikimedia.org/wikipedia/commons/5/50/GstaadPanoramaVillage.jpg" }, null));

            Rentals.Add(new RentalModel(8, "Hotel 1898", "Spain", 200, 32, address, new Dictionary<int, List<int>>
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
            }, "Winter", 3, "Hotel 1898 is conveniently set in Barcelona and features a sauna, a rooftop terrace and a rooftop pool. It is close to Placa de Catalunya, dining options and shops. ", null, new List<string>() { "https://www.whistler.com/images/itineraries/winter/five-star-hotel.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwRW6Rr68kmLYxsOE6nxlUFsgMD7EAkGpWwTIcbkWt3SAdawOj", "https://www.google.dk/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwirqJfi84DRAhWBBywKHUKtAqEQjRwIBw&url=http%3A%2F%2Fboredinvancouver.com%2Flisting%2F10-best-weekend-trips-from-vancouver%2F&psig=AFQjCNHDtOVC5LztiTgBNiAyTJN-DDwd0w&ust=1482259086453563" }, null));

            Rentals.Add(new RentalModel(9, "Oriente Atiram", "Spain", 90, 32, address, new Dictionary<int, List<int>>
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
            }, "Winter", 3, "Centrally located, Oriente Atiram allows for easy access to Barcelona's main tourist and retail hot spots. Just a short stroll from La Rambla, it provides air-conditioned rooms with complimentary wireless internet. ", null, new List<string>() { "http://www.pageresource.com/wallpapers/wallpaper/fontainebleau-hotel-miami-beach-hd.jpg", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSoTkpmbNhS_vl_jM0d5qYo-g0bv4_FYSDh6Leuc1ofCrvoiCY1", "http://www.belcekiz.com/wp-content/uploads/pool-view-1920x750.jpg" }, null));

            Rentals.Add(new RentalModel(10, "Barcelo Raval", "Spain", 210, 32, address, new Dictionary<int, List<int>>
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
            }, "Winter", 3, "Conveniently situated in the heart of Barcelona, Barcelo Raval provides free Wi-Fi in all areas, a sauna and a rooftop pool. Surrounded by local bars and restaurants, it is less than a 10-minute stroll from Paral-lel Metro Station. ", null, new List<string>() { "http://www.pixelstalk.net/wp-content/uploads/2016/10/Santorini-luxury-hotels-wallpaper-hd.jpg", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSBRCzEcB_YxmXw8HhkXZn84VeowX9XvL7vrRxFJpREDkSPM-BD", "https://4kwallpapers.co/wp-content/uploads/2015/07/santorini-cyclades-islands-aegean-sea-greece-ultra-hd-wallpaper.jpg" }, null));

            Rentals.Add(new RentalModel(11, "Grand Hotel de la Ville", "Italy", 210, 32, address, new Dictionary<int, List<int>>
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
            }, "Winter", 3, "Beautiful hotel, wonderful staff and good food with a beautiful view of the ocean.", null, new List<string>() { "http://s-ec.bstatic.com/images/hotel/840x460/158/15821445.jpg", "http://t-ec.bstatic.com/images/hotel/840x460/168/16870115.jpg", "http://t-ec.bstatic.com/images/hotel/840x460/168/16870129.jpg" }, null));

            Rentals.Add(new RentalModel(12, "Hotel Croatia", "Croatia", 169, 32, address, new Dictionary<int, List<int>>
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
            }, "Summer", 3, "Excellent accommodation and facillities. Great breakfastm set in idyllic small habour town on the Adriatic.", null, new List<string>() { "http://t-ec.bstatic.com/images/hotel/840x460/184/18468967.jpg", "http://t-ec.bstatic.com/images/hotel/840x460/184/18468961.jpg", "http://s-ec.bstatic.com/images/hotel/840x460/407/4070168.jpg" }, null));
        }




    }
}
