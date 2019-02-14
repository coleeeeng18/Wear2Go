using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SampleHomepage.Models
{
    public class Cart1
    {
        [Key]
        public string CartID { get; set; }
        public string ItemID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }

        public virtual product Prod { get; set; }
    }
}