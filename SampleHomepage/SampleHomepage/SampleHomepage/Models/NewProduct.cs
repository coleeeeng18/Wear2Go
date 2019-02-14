using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleHomepage.Models
{
    public class NewProduct
    {
        public int ProductID { get; set; }
        public int SizeID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public Nullable<decimal> ProductPrice { get; set; }
        public byte[] ProductPicture { get; set; }
        public string ProductDescription { get; set; }
        public byte[] Active { get; set; }
        public string PhotoString { get;set;}
        public IEnumerable<SelectListItem> GetProductCategory { get; set; }
        public IEnumerable<SelectListItem> GetProductSize { get; set; }
    }
}