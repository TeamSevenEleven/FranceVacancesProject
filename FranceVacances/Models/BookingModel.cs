using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacances.Models
{
    public class BookingModel
    {
        public BookingModel()
        {

        }
        public BookingModel(int _id, List<DateTime> _bookedDays,string _comments)
        {
            Id = _id;
            BookedDays = _bookedDays;
            Comments = _comments;
        }
        public int Id { get; set; }
        public List<DateTime> BookedDays { get; set; }
        public string Comments { get; set; }
    }
}