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
using Traveller.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Traveller.Controllers
{

    //[Authorize]
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        public GalleryController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages;
        }

        public GalleryImage GetById(int id)
        {
            return _ctx.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }



        public IActionResult Index()
        {
            var imageList = GetAll();
           
            var model = new GalleryIndexModel()
            {
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var image = GetById(id);
            var model = new GalleryDetailModel()
            {
                ID = image.ID,
                Title = image.Title,
                CreatedOn = image.Created,
                Url = image.Url
                //Tags = image.Tags.Selct(t => t.Description).ToList()
            };
            return View(model);
        }
    }
}