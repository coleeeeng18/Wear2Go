using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleHomepage.Models
{
    public class Comments
    {
        public int CommentsID { get; set; }
        public string Comment { get; set; }
        public DateTime ThisDateTime { get; set; }
        public int Rating { get; set; }
    }
}