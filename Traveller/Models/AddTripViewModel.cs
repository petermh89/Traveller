using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveller.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Traveller.Models
{
    public class AddTripViewModel
    {
        [Required(ErrorMessage = "You must name your trip")]
        [Display(Name = "Trip Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a City")]
        public string City { get; set; }

        [Required(ErrorMessage = "You must enter an Airline")]
        [Display(Name = "Airline")]
        public string Airline { get; set; }

        [Required(ErrorMessage = "You must enter your Lodging")]
        [Display(Name = "Lodging")]
        public string Lodging { get; set; }

        [Required(ErrorMessage = "You must enter your Lodging")]
        [Display(Name = "State")]
        public int State { get; set; }

        
        
        public string User { get; set; }

        public List<SelectListItem> States { get; set; }

        public AddTripViewModel(IEnumerable<State> states)
        {

            States = new List<SelectListItem>();

            foreach(var state in states)
            {
                States.Add(new SelectListItem
                {
                    Value = state.ID.ToString(),
                    Text = state.Name
                });

            }


        }
        public AddTripViewModel() { }

        public static Trip CreateTrip(AddTripViewModel addTripViewModel,State ChooseState, ApplicationUser User)
        {
            Trip newTrip = new Trip
            {
                Name = addTripViewModel.Name,
                City = addTripViewModel.City,
                Airline = addTripViewModel.Airline,
                Lodging = addTripViewModel.Lodging,
                State = ChooseState,
                User = User
                
            };

            return newTrip;

        }
    }
}