using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string RecevierName { get; set; }

        public int RecevierNum { get; set; }
        public string RecevierAddress { get; set; }
        public  int BrunshId { get; set; }

        public Brunsh Brunsh { get; set; }


    
        public DateTime Order_Date { get; set; }
        public bool IsPaid { get; set; }
        public bool Issent { get; set; }

    }
}
