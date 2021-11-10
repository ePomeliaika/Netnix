using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netnix.Models
{
    public class Movie
    {
        public string id { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
        public Director director { get; set; }

    }
}