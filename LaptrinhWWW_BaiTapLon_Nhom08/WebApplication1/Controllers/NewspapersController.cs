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
using EntityFrameworks.AccessModel;
using EntityFrameworks.Model;

namespace WebApplication1.Controllers
{
    public class NewspapersController : ApiController
    {
        private NewsDBContext db = new NewsDBContext();

        // GET: api/Newspapers
        public IQueryable<Newspaper> GetNewspapers()
        {
            return db.Newspapers;
        }

        // GET: api/Newspapers/5
        [ResponseType(typeof(Newspaper))]
        public IHttpActionResult GetNewspaper(int id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return NotFound();
            }

            return Ok(newspaper);
        }

        // PUT: api/Newspapers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewspaper(int id, Newspaper newspaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newspaper.NewsId)
            {
                return BadRequest();
            }

            db.Entry(newspaper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewspaperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Newspapers
        [ResponseType(typeof(Newspaper))]
        public IHttpActionResult PostNewspaper(Newspaper newspaper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Newspapers.Add(newspaper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newspaper.NewsId }, newspaper);
        }

        // DELETE: api/Newspapers/5
        [ResponseType(typeof(Newspaper))]
        public IHttpActionResult DeleteNewspaper(int id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return NotFound();
            }

            db.Newspapers.Remove(newspaper);
            db.SaveChanges();

            return Ok(newspaper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewspaperExists(int id)
        {
            return db.Newspapers.Count(e => e.NewsId == id) > 0;
        }
    }
}