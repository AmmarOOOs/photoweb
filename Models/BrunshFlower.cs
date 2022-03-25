using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class BrunshFlower
    {
        public int Id { get; set; }
        public int Brunsh_Id { get; set; }
        public Brunsh Brunsh { get; set; }
        public int FlowerBou_Id { get; set; }
        public FlowerBou FlowerBou { get; set; }
    }
}
