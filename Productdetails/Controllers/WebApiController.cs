using Productdetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Productdetails.Controllers
{
    public class WebApiController : ApiController
    {
        SignupForm_TestEntities entities = new SignupForm_TestEntities();

        [Route("api/AjaxAPI/InsertProduct")]
        [HttpPost]
        public Product InsertCustomer(Product _product)
        {
            using (SignupForm_TestEntities entities = new SignupForm_TestEntities())
            {
                entities.Products.Add(_product);
                entities.SaveChanges();
            }

            return _product;
        }

        [Route("api/AjaxAPI/UpdateProduct")]
        [HttpPost]
        public bool UpdateCustomer(Product _product)
        {
          
                Product updatedproduct = (from c in entities.Products
                                            where c.Id == _product.Id
                                            select c).FirstOrDefault();
            updatedproduct.Name = _product.Name;
            updatedproduct.Description = _product.Description;
            updatedproduct.price = _product.price;
            updatedproduct.Quantity = _product.Quantity;

            entities.SaveChanges();

            return true;
        }

        [Route("api/AjaxAPI/DeleteProduct")]
        [HttpPost]
        public void DeleteCustomer(Product _product)
        {
            
                Product updatedproduct = (from c in entities.Products
                                     where c.Id == _product.Id
                                     select c).FirstOrDefault();
                entities.Products.Remove(updatedproduct);
                entities.SaveChanges();
        }
    }
}

