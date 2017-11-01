using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveller.Data.Models;

namespace Traveller.Models
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
