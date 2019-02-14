using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleHomepage.Models
{
    public class ProductsCommentsModel
    {
        public product Product { get; set; }
        public List<comment> CommentList { get; set; }
    }
}