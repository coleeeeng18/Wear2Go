using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleHomepage.Models;
using System.IO;
using System.Data.Entity.Validation;

namespace SampleHomepage.Controllers
{
    public class HomeController : Controller
    {
        ThesisEntities db = new ThesisEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Add()
        {
            var model = new NewProduct()
            {
                GetProductCategory = GetProductCategory()
            };
            return View(model);
        }



        public ActionResult ProductCategory(int id)
        {
            return View(db.products.Where(m => m.CategoryID == id).ToList());
        }

        


        [HttpPost]
        public ActionResult Add(NewProduct model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    product product = new product();
                    product.ProductName = model.ProductName;
                    product.CategoryID = model.CategoryID;
                    product.ProductDescription = model.ProductDescription;
                    product.ProductPrice = model.ProductPrice;
                    HttpPostedFileBase file = Request.Files["image"];
                    product.ProductPicture = file.ContentLength != 0 ? ConvertToByte(file) : null;
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
                catch (DbEntityValidationException e)
    {
    foreach (var eve in e.EntityValidationErrors)
    {
        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            eve.Entry.Entity.GetType().Name, eve.Entry.State);
        foreach (var ve in eve.ValidationErrors)
        {
            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                ve.PropertyName, ve.ErrorMessage);
        }
    }
    throw;
}
            }
            else
            {
                model = new NewProduct()
                {
                    GetProductCategory = GetProductCategory()
                };
                return View(model);
            }


        }
        
        public ActionResult GetImage(int id)
        {
            byte[] image = db.products.Find(id).ProductPicture;
            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public byte[] ConvertToByte(HttpPostedFileBase image)
        {
            byte[] imagebytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imagebytes = reader.ReadBytes((int)image.ContentLength);
            return imagebytes;
        }

        public IEnumerable<SelectListItem> GetProductCategory()
        {
            return db.categories.Select(m => new SelectListItem { Text = m.CategoryName, Value = m.CategoryID.ToString() });
        }

  

        public ActionResult ViewProduct(int? id)
        {
            var p = db.products.Where(x => x.ProductID == id).FirstOrDefault();
            var ave = db.comments.Where(x => x.ProductID == id).Select(x => x.Rating).Average();
            int? average = Convert.ToInt32(ave);
            p.AverageRating = average;
            db.SaveChanges();

            ProductsCommentsModel pcm = new ProductsCommentsModel();
            pcm.Product = db.products.Find(id);
            pcm.CommentList = db.comments.Where(x => x.ProductID == id).ToList();
            return View(pcm);
        }

        [HttpPost]
        public ActionResult ViewProduct(FormCollection fc)
        {
            var fullName = fc["txtName"];
            var comment = fc["TxtComment"];
            var rating = Convert.ToInt32(fc["slctRating"]);
            var productId = Convert.ToInt32(fc["ID"]);

            comment c = new comment();
            c.FullName = fullName;
            c.Comments = comment;
            c.ThisDateTime = DateTime.Now;
            c.ProductID = productId;
            c.Rating = rating;
            db.comments.Add(c);
            db.SaveChanges();

            var p = db.products.Where(x => x.ProductID == productId).FirstOrDefault();
            var ave = db.comments.Where(x => x.ProductID == productId).Select(x => x.Rating).Average();
            int? average = Convert.ToInt32(ave);
            p.AverageRating = average;
            db.SaveChanges();

            ProductsCommentsModel pcm = new ProductsCommentsModel();
            pcm.Product = db.products.Find(productId);
            pcm.CommentList = db.comments.Where(x => x.ProductID == productId).ToList();
            return View(pcm);
        }

        public ActionResult AllProducts()
        {
            //nakakainis tong part na to hahahaha
            return View(db.products.ToList());
        }

        public ActionResult Delete(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult List()
        {
            return View(db.products.ToList());
        }


        public ActionResult Edit(int id)
        {
            return View(db.products.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(product model)
        {
            product product = db.products.Find(model.ProductID);
            product.ProductName = model.ProductName;
            product.ProductPrice = model.ProductPrice;
            product.ProductDescription = model.ProductDescription;
            product.Quantity = model.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Categories()
        {
            return View(db.categories.ToList());
        }

        public ActionResult ViewCategory(int id)
        {
            return View(db.categories.Find(id));
        }
        public ActionResult EditCategory(int id)
        {
            return View(db.categories.Find(id));
        }
        [HttpPost]
        public ActionResult EditCategory(category model)
        {
            category category = db.categories.Find(model.CategoryID);
            category.CategoryName = model.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            category category = db.categories.Find(id);
            db.categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}