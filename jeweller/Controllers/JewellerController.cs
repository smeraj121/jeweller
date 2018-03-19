using jeweller.Models;
using jeweller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jeweller.Controllers
{

    public class JewellerController : Controller
    {

        private IJewellerHandle jewellerhandle;

        public JewellerController(IJewellerHandle jhandle)
        {
            this.jewellerhandle = jhandle;
        }

            
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Home");
            }
                return View();
        }

      

        [HttpPost]
        public ActionResult Auth(LoginModel log)
        {
            if (ModelState.IsValid)
            {
                var result = jewellerhandle.GetJeweller().Find(emodel => emodel.Username == log.Username);
                if (result != null)
                {
                    if (result.Password == log.Password)
                    {
                        Session["UserName"] = log.Username.ToString();
                        return RedirectToAction("Home");
                    }
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Home()
        {
            if (Session["UserName"] != null)
            {
                ModelState.Clear();
                return View(jewellerhandle.GetJeweller().Find(smodel => smodel.Username == Session["UserName"].ToString()));
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit()
        {
            return View(jewellerhandle.GetJeweller().Find(smodel => smodel.Username == Session["UserName"].ToString()));
        }

        [HttpPost]
        public ActionResult Edit(JewellerDetails jd)
        {
            if (ModelState.IsValid)
            {
                jewellerhandle.UpdateDetails(jd);
                return RedirectToAction("Home");
            }
            ViewBag.error = "Model State not valid";
            return View();
        }

        public ActionResult ViewProducts()
        {
            OrderHandle orderhandle = new OrderHandle();
            return View(orderhandle.GetProducts());
        }


        public ActionResult EditProducts(int id)
        {
            OrderHandle ch = new OrderHandle();
            Product product = ch.GetProducts().Find(cp => cp.Product_Id == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProducts(Product product)
        {
            OrderHandle orderhandle = new OrderHandle();
            orderhandle.EditProduct(product);
            return RedirectToAction("Receipt");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }


    //public class AuthOverride : IAuthorizationFilter
    //{
    //    public void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var result = jewellerhandle.GetJeweller().Find(emodel => emodel.Username == log.Username);
    //            if (result != null)
    //            {
    //                if (result.Password == log.Password)
    //                {
    //                    return //contx
    //                    Session["UserName"] = log.Username.ToString();
    //                    return RedirectToAction("Home");
    //                }
    //            }
    //        }

    //        //throw new NotImplementedException();
    //    }
    //}
}

