using ComicCollector.Controllers;
using ComicCollector.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ComicCollector.DAL
{
    [RoutePrefix("api/comiccollections")]
    public class ComicCollectionRepository : IComicCollectionRepository
    {
        readonly ApplicationDbContext _context;
        private IRestClient _restClient;

        public ComicCollectionRepository(ApplicationDbContext context, IRestClient restClient)
        {
            _context = context;
            _restClient = restClient;

        }



        public Comic Get(int id)
        {
            return _context.ComicCollection.Find(id);
        }

        public IEnumerable<Models.Comic> GetAll()
        {
            var request = new RestRequest("v1/public/series?titleStartsWith=wolverine&apikey=570494d5a6a681b21681b10b3bf4d61c", Method.GET);

            var response = _restClient.Get<List<Models.Comic>>(request);

            return response.Data;

        }

        public void Save(Models.Comic newComic)
        {
            _context.ComicCollection.Add(newComic);
            _context.SaveChanges();
        }

        //Controllers.Comic IComicCollectionRepository.Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<Controllers.Comic> IComicCollectionRepository.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}