using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicCollector.Models
{
    public class ComicCollection
    {
        [Key]
        public int ComicId { get; set; }
        public string Series { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public int Issue { get; set; }
    }
}