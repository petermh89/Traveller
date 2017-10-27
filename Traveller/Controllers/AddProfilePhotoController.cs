using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Traveller.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Traveller.Data;
using Microsoft.AspNetCore.Authorization;

namespace Traveller.Controllers
{
    [Authorize]
    public class AddProfilePhotoController : Controller
    {
        private ApplicationDbContext context;
        public AddProfilePhotoController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProfilePhoto photo, List<IFormFile> MyImage)
        {
            //ApplicationUser myUser = context.Users.Single(u => u.Email == this.User.Identity.Name);

            foreach (var item in MyImage)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        photo.MyImage = stream.ToArray();
                        

                    }
                }
            }

            if (photo.MyImage != null)
            {
                var userPhoto = new ProfilePhoto { ID = photo.ID, User = context.Users.Single(u => u.Email == this.User.Identity.Name), MyImage = photo.MyImage };
                context.ProfilePhotos.Add(userPhoto);
                context.SaveChanges();
                return Redirect("/Home/Index");
            }
            return View();
        }
    }
}