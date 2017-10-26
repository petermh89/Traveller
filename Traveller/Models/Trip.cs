using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Traveller.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public string City { get; set; }
        public string Airline { get; set; }
        public string Lodging { get; set; }
        public State State { get; set; }
        public string Plans { get; set; }
      

        

    }
}


