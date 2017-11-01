using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveller.Data.Models;

namespace Traveller.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetWithTag(string tag);
        GalleryImage GetById(int id);

    }
}
