using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Traveller.Data;
using Traveller.Models;
using System.Data.SqlClient;
using System.IO;
using Microsoft.AspNetCore.Hosting;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Traveller.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationDbContext context;
        private IHostingEnvironment _environment;

        public UserController(ApplicationDbContext dbContext, IHostingEnvironment environment)
        {
            context = dbContext;
            _environment = environment;
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


        public IActionResult Edit(int tripId)
        {
            Trip myTripEdit = context.Trips.Single(t => t.ID == tripId);

            EditTripViewModel editTripViewModel = EditTripViewModel.EditTrip(myTripEdit);
            return View(editTripViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditTripViewModel editTripViewModel)
        {
            if (ModelState.IsValid)
            {
                Trip updateTrip = context.Trips.Single(t => t.ID == editTripViewModel.ID);
                context.Trips.Update(updateTrip);

                updateTrip.Name = editTripViewModel.Name;
                updateTrip.City = editTripViewModel.City;
                updateTrip.Airline = editTripViewModel.Airline;
                updateTrip.Lodging = editTripViewModel.Lodging;
                updateTrip.Plans = editTripViewModel.Plans;

                context.SaveChanges();
                return Redirect("/User/Index");

            }
            else
            {
                return View(editTripViewModel);
            }
        }


        public async Task<IActionResult> Search(string searchString)
        {
            var trips = from t in context.Trips
                         select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                trips = trips.Where(s => s.Name.Contains(searchString));
            }

            return View(await trips.ToListAsync());
        }



        //    public async Task<ActionResult> RenderImage(int id)
        //    {
        //        ApplicationUser User = context.Users.Single(u => u.Email == this.User.Identity.Name);

        //        ProfilePhoto item = await context.ProfilePhotos.FindAsync(id);

        //        byte[] photoBack = item.MyImage;

        //        return File(photoBack, "image/png");
        //    }


        //}

        public IActionResult New()
        {
            return View();
        }


        

    }
}

