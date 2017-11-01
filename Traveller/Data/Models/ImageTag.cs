using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traveller.Data.Models
{
    public class ImageTag
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public GalleryImage ImageId { get; set; }
    }
}
