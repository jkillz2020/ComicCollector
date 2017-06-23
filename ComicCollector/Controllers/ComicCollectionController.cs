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
using Microsoft.AspNet.Identity;

namespace ComicCollector.Controllers
{
    public class ComicCollectionController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/ComicCollections
        [HttpGet, Route("api/comiccollection")]
        public IQueryable<Comic> GetComicCollection()
        {
            var uid = User.Identity.GetUserId();
            return _db.ComicCollection.Where(comic => comic.Uid == uid);
        }

        // GET: api/ComicCollections/5
        [ResponseType(typeof(Models.Comic))]
        public IHttpActionResult GetComicCollection(int id)
        {
            Models.Comic comicCollection = _db.ComicCollection.Find(id);
            if (comicCollection == null)
            {
                return NotFound();
            }

            return Ok(comicCollection);
        }

        // PUT: api/ComicCollections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComicCollection(int id, Models.Comic comicCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comicCollection.ComicId)
            {
                return BadRequest();
            }

            _db.Entry(comicCollection).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
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
        [HttpPost, Route("api/comiccollection")]
        [ResponseType(typeof(Models.Comic))]
        public IHttpActionResult PostComicCollection(Comic comicCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            comicCollection.Uid = User.Identity.GetUserId();

            _db.ComicCollection.Add(comicCollection);
            _db.SaveChanges();

            var x= CreatedAtRoute("DefaultApi", new {controller = "findComic"} ,comicCollection);
            return x;
        }

        // DELETE: api/ComicCollections/5
        [ResponseType(typeof(Models.Comic))]
        [HttpDelete, Route("api/comiccollection/{id}")]
        public IHttpActionResult DeleteComicCollection(int id)
        {
            var comicCollection = _db.ComicCollection.Find(id);
            if (comicCollection == null)
            {
                return NotFound();
            }

            _db.ComicCollection.Remove(comicCollection);
            _db.SaveChanges();

            return Ok(comicCollection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComicCollectionExists(int id)
        {
            return _db.ComicCollection.Count(e => e.ComicId == id) > 0;
        }
    }
}