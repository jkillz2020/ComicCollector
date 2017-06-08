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
using ComicCollector.Models;

namespace ComicCollector.Controllers
{
    public class ComicCollectionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ComicCollection _comicCollection;

        public ComicCollectionsController(ComicCollection comicCollection)
        {
            _comicCollection = comicCollection;
        }

        // GET: api/ComicCollections
        public IQueryable<ComicCollection> GetComicCollection()
        {
            return db.ComicCollection;
        }

        // GET: api/ComicCollections/5
        [ResponseType(typeof(ComicCollection))]
        public IHttpActionResult GetComicCollection(int id)
        {
            ComicCollection comicCollection = db.ComicCollection.Find(id);
            if (comicCollection == null)
            {
                return NotFound();
            }

            return Ok(comicCollection);
        }

        // PUT: api/ComicCollections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComicCollection(int id, ComicCollection comicCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comicCollection.ComicId)
            {
                return BadRequest();
            }

            db.Entry(comicCollection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComicCollectionExists(id))
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

        // POST: api/ComicCollections
        [ResponseType(typeof(ComicCollection))]
        public IHttpActionResult PostComicCollection(ComicCollection comicCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ComicCollection.Add(comicCollection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comicCollection.ComicId }, comicCollection);
        }

        // DELETE: api/ComicCollections/5
        [ResponseType(typeof(ComicCollection))]
        public IHttpActionResult DeleteComicCollection(int id)
        {
            ComicCollection comicCollection = db.ComicCollection.Find(id);
            if (comicCollection == null)
            {
                return NotFound();
            }

            db.ComicCollection.Remove(comicCollection);
            db.SaveChanges();

            return Ok(comicCollection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComicCollectionExists(int id)
        {
            return db.ComicCollection.Count(e => e.ComicId == id) > 0;
        }
    }
}