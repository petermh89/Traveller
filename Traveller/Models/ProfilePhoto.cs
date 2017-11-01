using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Traveller.Models
{
    public class ProfilePhoto
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }

        public byte[] MyImage { get; set; }

        


    }
}
