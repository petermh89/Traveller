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
            Trip myTrip = context.Trips.Find( m => m. == )
            return View();
        }
    }
}
