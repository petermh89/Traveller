using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Traveller.Models;

namespace Traveller.Data.Models
{
    public class GalleryImage
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }

        [NotMapped]
        public virtual IEnumerable<ImageTag> Tags { get; set; }
    }
}
