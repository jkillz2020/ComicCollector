﻿using ComicCollector.Models;
using MarvelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComicCollector.Controllers
{
    public class ComicController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public Marvel _client = new Marvel("570494d5a6a681b21681b10b3bf4d61c", "e5b30ca536647fef3cc5ae8b0647a4853f468b59");

        // GET: api/Comic
        public IEnumerable<Comic> GetSeries(string characterName)
        {
            var seriesIds = _client.GetSeries(Title: characterName ?? "Wolverine").Select(x => x.Id);
            var comicsForSeries = _client.GetComics(Series: seriesIds);
            return comicsForSeries;
            
            //GetSeries(string Title = null, DateTime ? ModifiedSince = null, IEnumerable < int > Comics = null, IEnumerable < int > Stories = null, IEnumerable < int > Events = null, IEnumerable < int > Creators = null, IEnumerable < int > Characters = null, SeriesType ? Type = null, ComicFormat ? Contains = null, IEnumerable < OrderBy > Order = null, int ? Limit = null, int ? Offset = null)
            //return db.comic;
        }

        // GET: api/Comic/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comic
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Comic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comic/5
        public void Delete(int id)
        {
        }
    }
}