using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacances.Models
{
    public class RentalModel
    {
        public RentalModel()
        {

        }

        public RentalModel(int _id, string _name, string _country, double _price, int _bookings, List<string> _address, Dictionary<int,List<int>> _BookedDays, string _season, byte _rooms, string _description, List<string> _tags,  List<string> _imagepaths, string _thumbnailpath)

        {
            id = _id;
            Name = _name;
            Country = _country;
            Price = _price;
            Bookings = _bookings;
            Address = _address;
            BookedDays =  _BookedDays;
            Season = _season;
            Rooms = _rooms;
            Description = _description;
            Tags = _tags;
            ImagePaths = _imagepaths;
            //            ThumbnailPath = _thumbnailpath;
            ThumbnailPath = _imagepaths[0];

        }
        
        public int id { get; set; }    
        public string Name { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public int Bookings { get; set; }

        public List<string> Address { get; set; }

        public Dictionary<int, List<int>> BookedDays { get; set; }
        public string Season { get; set; }
        public byte Rooms { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }

        public List<string> ImagePaths { get; set; }
        public string ThumbnailPath { get; set; }


        public override string ToString()
        {
            return $"{Name} in {Country}\n Season: {Season}";
        }

    }
}
