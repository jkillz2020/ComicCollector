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
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ComicCollections
        [HttpGet, Route("api/comiccollection")]
        public IQueryable<Comic> GetComicCollection()
        {
            return db.ComicCollection;
        }

        // GET: api/ComicCollections/5
        [ResponseType(typeof(Models.Comic))]
        public IHttpActionResult GetComicCollection(int id)
        {
            Models.Comic comicCollection = db.ComicCollection.Find(id);
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
        [HttpPost, Route("api/comiccollection")]
        [ResponseType(typeof(Models.Comic))]
        public IHttpActionResult PostComicCollection(Comic comicCollection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var uid = User.Identity.GetUserId<int>();
            //comicCollection.Uid = uid;
            comicCollection.Uid = int.Parse(User.Identity.GetUserId());

            db.ComicCollection.Add(comicCollection);
            db.SaveChanges();

            ////var x= CreatedAtRoute("DefaultApi", new {id = comicCollection.ComicId }, comicCollection);
            var x= CreatedAtRoute("DefaultApi", new {controller = "findComic"} ,comicCollection);
            return x;
        }

        // DELETE: api/ComicCollections/5
        [ResponseType(typeof(Models.Comic))]
        [HttpDelete, Route("api/comiccollection/Comics.Id")]
        public IHttpActionResult DeleteComicCollection(int id)
        {
            var comicCollection = db.ComicCollection.Find(id);
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