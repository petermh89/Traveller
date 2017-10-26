using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UserController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            
            ApplicationUser User = context.Users.Single(u => u.Email == this.User.Identity.Name);
    
            IList<Trip> myTrips = context.Trips.Where(u => u.User == User).Include(c => c.State).ToList();
            
            return View(myTrips);
        }

        public IActionResult MyTrip(int tripId)
        {
            Trip viewTrip = context.Trips.Single(t => t.ID == tripId);

            MyTripViewModel myTripView = MyTripViewModel.ViewTrip(viewTrip);
            return View(myTripView);
        }
    }
}
