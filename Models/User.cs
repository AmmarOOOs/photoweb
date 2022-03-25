using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class User : IdentityUser
    {
        public string NationalNumber { get; set; }
        public string Address { get; set; }


    }
}
