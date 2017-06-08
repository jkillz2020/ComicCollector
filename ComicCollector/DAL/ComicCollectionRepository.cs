using ComicCollector.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ComicCollector.DAL
{
    [RoutePrefix("api/comiccollections")]
    public class ComicCollectionRepository  
    {
        readonly ApplicationDbContext _context;
        private IRestClient _restClient;

        public ComicCollectionRepository(ApplicationDbContext context, IRestClient restClient)
        {
            _context = context;
            _restClient = restClient;

        }



        public ComicCollection Get(int id)
        {
            return _context.ComicCollection.Find(id);
        }

        public IEnumerable<ComicCollection> GetAll()
        {
            var request = new RestRequest("https://gateway.marvel.com:443/v1/public/series?titleStartsWith=wolverine&apikey=570494d5a6a681b21681b10b3bf4d61c", Method.GET);
            
                        var response = _restClient.Get<List<ComicCollection>>(request);

            return response.Data;

        }
    }
}