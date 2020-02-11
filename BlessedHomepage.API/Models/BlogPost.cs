using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlessedHomepage.API.Models
{
    public class BlogPost
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ExternalLink { get; set; }

        public DateTime PostedAt { get; set; }
    }
}
