using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traveller.Models
{
    public class GalleryDetailModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Url { get; set; }

        public List<string> Tags { get; set; }
    }
}
