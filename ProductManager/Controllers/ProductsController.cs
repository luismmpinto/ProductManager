using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductManagerContext db = new ProductManagerContext();

        // GET: api/Products
        public IQueryable<ProductsModel> GetProducts()//This method will list the products inside the database.
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductsModel))]//This method will return the product data with the specified id
        public IHttpActionResult GetProducts(int id)
        {
            ProductsModel products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        /*This method will modify the data inside a specified id, must fulfill the specified conditions obviously.
          Data has to be inserted according to the model and be sure that there is no duplication of key values inside the database
        */
        public IHttpActionResult PutProducts(int id, ProductsModel products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.Id)
            {
                return BadRequest();
            }

            db.Entry(products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductsModel))]//This method will create a new product, is not to be specified since it is an automatic value
        public IHttpActionResult PostProducts(ProductsModel products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            { 
            db.Products.Add(products);
            db.SaveChanges();
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }
            

            return CreatedAtRoute("DefaultApi", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductsModel))]//This method will delete a specified ID from the database.
        public IHttpActionResult DeleteProducts(int id)
        {
            ProductsModel products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            db.SaveChanges();

            return Ok(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();//releases the connection to the db
            }
            base.Dispose(disposing);
        }

        private bool ProductsExists(int id)//Method is being used to check if there is an atempt to duplicate the ID's inside the db.
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}