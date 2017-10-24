using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveller.Data;
using Traveller.Models;

namespace Traveller.Controllers
{

    public class StateController : Controller
    {
        private readonly ApplicationDbContext context;

        public StateController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            Dictionary<string, string> los = new Dictionary<string, string>();
            los.Add("AL", "Alabama");
            los.Add("AK", "Alaska");
            los.Add("AZ", "Arizona");
            los.Add("AR", "Arkansas");
            los.Add("CA", "California");
            los.Add("CO", "Colorado");
            los.Add("CT", "Connecticut");
            los.Add("DC", "District Of Columbia");
            los.Add("FL", "Florida");
            los.Add("DE", "Delaware");
            los.Add("GA", "Georgia");
            los.Add("HI", "Hawaii");
            los.Add("ID", "Idaho");
            los.Add("IL", "Illinois");
            los.Add("IN", "Indiana");
            los.Add("IA", "Iowa");
            los.Add("KS", "Kansas");
            los.Add("KY", "Kentucky");
            los.Add("LA", "Louisiana");
            los.Add("ME", "Maine");
            los.Add("MD", "Maryland");
            los.Add("MA", "Massachusetts");
            los.Add("MI", "Michigan");
            los.Add("MN", "Minnesota");
            los.Add("MS", "Mississippi");
            los.Add("MO", "Missouri");
            los.Add("MT", "Montana");
            los.Add("NE", "Nebraska");
            los.Add("NV", "Nevada");
            los.Add("NH", "New Hampshire");
            los.Add("NJ", "New Jersey");
            los.Add("NM", "New Mexico");
            los.Add("NY", "New York");
            los.Add("NC", "North Carolina");
            los.Add("ND", "North Dakota");
            los.Add("OH", "Ohio");
            los.Add("OK", "Oklahoma");
            los.Add("OR", "Oregon");
            los.Add("PA", "Pennsylvania");
            los.Add("RI", "Rhode Island");
            los.Add("SC", "South Carolina");
            los.Add("SD", "South Dakota");
            los.Add("TN", "Tennessee");
            los.Add("TX", "Texas");
            los.Add("UT", "Utah");
            los.Add("VT", "Vermont");
            los.Add("VA", "Virginia");
            los.Add("WA", "Washington");
            los.Add("WV", "West Virginia");
            los.Add("WI", "Wisconsin");
            los.Add("WY", "Wyoming");

            foreach (KeyValuePair<string, string> state in los)
            {

                State myState = new State
                {

                    Name = state.Value,
                    Abbreviation = state.Key
                };
                context.States.Add(myState);
                context.SaveChanges();

            }
            return View();
        }

    }
}

