using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveller.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Traveller.Models
{
    public class MyTripViewModel : AddTripViewModel
    {
        public int ID { get; set; }

        //public List<SelectListItem> MyStates { get; set; }

        public static MyTripViewModel ViewTrip(Trip trip)
        {
            MyTripViewModel myTrip = new MyTripViewModel
            {
                ID = trip.ID,
                Name = trip.Name,
                City = trip.City,
                Airline = trip.Airline,
                Lodging = trip.Lodging,
                Plans = trip.Plans,

            };

            return myTrip;

        }
    }
}
