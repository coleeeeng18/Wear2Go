using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleHomepage.Models;

namespace SampleHomepage.Controllers
{
    public class ShoppingCartController : Controller
    {
        ThesisEntities db = new ThesisEntities();

        public ActionResult ShoppingCart()
        {
            return View(db.Carts);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(int? id)
        {
            decimal? grandTotal;
            var product = db.products.Where(x => x.ProductID == id).FirstOrDefault();
            if (Session["cart"] == null)
            {
                grandTotal = 0m;
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart { CartID = cart.Count + 1, ProductID = id, Quantity = 1, ProductPrice = product.ProductPrice, ProductName = product.ProductName, product = db.products.Where(x => x.ProductID == id).FirstOrDefault() });
                grandTotal = cart.Sum(x => x.Total);
                Session["cart"] = cart;
                Session["grandTotal"] = grandTotal;
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session["cart"];
                var c = (from x in cart where x.ProductID == id select x).ToList();
                if (c.Count > 0)
                {
                    cart.Where(x => x.ProductID == id).Select(x => x).FirstOrDefault().Quantity++;
                }
                else
                {
                    cart.Add(new Cart { CartID = cart.Count + 1, ProductID = id, Quantity = 1, ProductPrice = product.ProductPrice, ProductName = product.ProductName, product = db.products.Where(x => x.ProductID == id).FirstOrDefault() });
                }
                grandTotal = cart.Sum(x => x.Total);
                Session["grandTotal"] = grandTotal;
            }

            return View("Index");
        }

        public ActionResult Delete(int? id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            cart.Remove(cart.Where(x => x.ProductID == id).FirstOrDefault());
            decimal? grandTotal;
            grandTotal = cart.Sum(x => x.Total);
            Session["grandTotal"] = grandTotal;
            return View("Index");
        }

        public ActionResult UpdateCart(FormCollection data)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = Convert.ToInt32(data[i]);
            }
            decimal? grandTotal = cart.Sum(x => x.Total);
            Session["cart"] = cart;
            Session["grandTotal"] = grandTotal;
            return View("Index");
        }

        public ActionResult CustomerDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(client client)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            decimal? grandTotal = cart.Sum(x => x.Total);

            db.clients.Add(client);
            db.SaveChanges();

            order o = new order();
            o.OrderDate = DateTime.Now;
            o.ClientID = db.clients.Select(x => x.ClientID).ToList().LastOrDefault();
            //o.ClientID = (WALA PA LAMAN SA DB MO TO :D)
            //o.PaymentID = (WALA PA LAMAN SA DB MO TO :D)

            db.orders.Add(o);
            foreach (var item in cart)
            {
                OrderDetail od = new OrderDetail();
                od.OrderID = o.OrderID;
                od.ProductID = item.ProductID;
                od.Quantity = item.Quantity;
                db.OrderDetails.Add(od);
                product p = db.products.Where(x => x.ProductID == item.ProductID).FirstOrDefault();
                p.Quantity -= item.Quantity;
            }


            db.SaveChanges();
            return View("Done", cart);
        }
        
    }
}
