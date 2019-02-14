using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleHomepage.Models;

namespace SampleHomepage.Controllers
{
    public class Item
    {
        private product pr = new product();

        public product Pr
        {
            get { return pr; }
            set { pr = value; }
        }
        private int quantity;

        public Item(product p, int quantity)
        {
            this.pr = p;
            this.quantity = quantity;
        }
    }
}