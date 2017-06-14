using ComicCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicCollector.Controllers
{
    interface IComicCollectionRepository
    {
        void Save(Comic newComic);
        Comic Get(int id);
        IEnumerable<Comic> GetAll();
    }

}
