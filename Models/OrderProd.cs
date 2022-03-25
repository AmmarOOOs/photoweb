using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class OrderProd
    {
        [Required]
        public int Id { get; set; }

        public int Order_Id { get; set; }
        public Order Order { get; set; }

       
        public int FlowerBou_Id { get; set; }
        public FlowerBou FlowerBou { get; set; }

    }
}
