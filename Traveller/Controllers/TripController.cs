using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Traveller.Data;
using Traveller.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Traveller.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationDbContext context;

        public TripController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            AddTripViewModel addTripViewModel = new AddTripViewModel();


            return View(addTripViewModel);
        }

        public IActionResult Add()
        {
            AddTripViewModel addTripViewModel = new AddTripViewModel(context.States.ToList());
            return View(addTripViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTripViewModel addTripViewModel)
        {

            if (ModelState.IsValid)
            {
                State ChooseState = context.States.Single(s => s.ID == addTripViewModel.State);
                ApplicationUser User = context.Users.Single(u => u.Email == this.User.Identity.Name);
                
                Trip newTrip = AddTripViewModel.CreateTrip(addTripViewModel, ChooseState, User);
                context.Trips.Add(newTrip);
                context.SaveChanges();

                return Redirect("/User");
            }

            return Redirect("/Trip/Add");
        }

    }
}
