using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Traveller.Models
{
    public class UserPhoto
    {
        public int ID { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        public ApplicationUser User { get; set; }
        public string PhotoPath { get; set; }
    }
}
