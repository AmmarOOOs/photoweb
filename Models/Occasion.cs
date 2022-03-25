using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Occasion
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        

    }
}
