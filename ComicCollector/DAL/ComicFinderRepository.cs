//using MarvelAPI;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ComicCollector.DAL
//{
//    public class ComicFinderRepository
//    {
//        public IEnumerable<Comic> Get()
//        {
//            var client = new RestClient("http://data.nashville.gov/");
//            var request = new RestRequest($"resource/8fb8-y573.json");

//            request.AddHeader("X-App-Token", "");
//            request.AddQueryParameter("myParam", "jkasdfjlk;adsfjk;lasfd;kjl");

//            var restResponse = client.Get<List<ApiComic>>(request);

//            if (restResponse.StatusCode != HttpStatusCode.OK) yield return null;

//            foreach (var comic in restResponse.Data)
//            {
//                var p = new Comic
//                {
//                    Title = comic.title,
//                    Description = comic.description,
//                    Stories = comic.stroies,
//                    Image = comic.thumbnail
//                };

//                yield return p;
//            }
//        }
//    }

//    public interface IComicFinderRepository
//    {
//        IEnumerable<Comic> Get();
//    }
//}
//}