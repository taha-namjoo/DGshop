using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degishop.Models
{
    public class PC_AND_Laptop
    {
        public int Id { get; set; }
        public string model_name { get; set; }
        public string Cost { get; set; }
        public string details { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string  Graphic { get; set; }
        public virtual Brands Brands { get; set; }
        public int BrandsId { get; set; }


    }
}
