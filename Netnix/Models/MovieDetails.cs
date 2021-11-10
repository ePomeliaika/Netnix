using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netnix.Models
{
    public class MovieDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Director director { get; set; }

    }
}
