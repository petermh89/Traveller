using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traveller.Models
{
    public class EditTripViewModel : AddTripViewModel
    {
        public int ID { get; set; }



        public static EditTripViewModel EditTrip(Trip trip)
        {
            EditTripViewModel edit = new EditTripViewModel
            {
                ID = trip.ID,
                Name = trip.Name,
                City = trip.City,
                Airline = trip.Airline,
                Lodging = trip.Lodging,
                Plans = trip.Plans
            };
            return edit;

        }



    }
}
