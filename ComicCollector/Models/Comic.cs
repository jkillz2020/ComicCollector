using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicCollector.Models
{
    public class Comic
    {
        [Key]
        public int ComicId { get; set; }
        public string Series { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IssueNumber { get; set; }
        public string Image { get; set; }
        public string Uid { get; set; }
    }
}