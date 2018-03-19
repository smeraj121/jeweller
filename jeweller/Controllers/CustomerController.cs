using jeweller.Models;
using jeweller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jeweller.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerHandle customerhandle;
       
        public CustomerController(ICustomerHandle c_handle)
        {
            customerhandle = c_handle;
        }

        public ActionResult Receipt()
        {
            ModelState.Clear();
            return View(customerhandle.GetCustomers());
        }

        [HttpPost]
        public ActionResult Receipt(string name)
        {
            ModelState.Clear();
            List<CustomerModel> SearchResults = customerhandle.SearchCustomers(name);
            return View(SearchResults);
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(CustomerModel cm)
        {
            if (ModelState.IsValid)
            {
                if (customerhandle.AddCustomer(cm))
                {
                    ModelState.Clear();
                }
            }
            return View();
        }


        public ActionResult EditCustomer(int id)
        {
            return View(customerhandle.GetCustomers().Find(cm => cm.Cust_Id == id));
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerModel cm)
        {
            if (ModelState.IsValid)
            {
                customerhandle.UpdateCustomerDetails(cm);
                return RedirectToAction("Receipt");
            }
            ViewBag.error = "Model State not valid";
            return View();
        }

        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                if (customerhandle.DeleteCustomer(id))
                {
                    ViewBag.AlertMsg = "Customer Deleted Successfully";
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Receipt");
        }

        public ActionResult CreateBill(int id)
        {
            combined c = new combined();
            c.customer = customerhandle.GetCustomers().Find(cm => cm.Cust_Id == id);
            return View(c);
        }

        [HttpPost]
        public ActionResult CreateBill(combined Products, int id)
        {
            //if (ModelState.IsValid)
            //{
            Product product = Products.productmodel;
            OrderHandle orderhandle = new OrderHandle();
            orderhandle.AddProduct(product, id);
            //}
            return RedirectToAction("Receipt");
        }

        public ActionResult GetOrders(int id)
        {
            OrderHandle orderhandle = new OrderHandle();
            return View(orderhandle.GetOrders(id));
        }

        public ActionResult ViewProducts()
        {
            OrderHandle orderhandle = new OrderHandle();
            return View(orderhandle.GetProducts());
        }


        public ActionResult Order_Product_Details(int id)
        {
            OrderHandle ch = new OrderHandle();
            return View(ch.GetProducts().Find(cp => cp.Product_Id == id));

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

    }
}