using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleHomepage.Models
{
    public class Orderdetail1
    {
        public int OrderdetailID { get; set; }
        public int OrderID { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}