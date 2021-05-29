using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class savedposts
    {
        public savedposts(Post p, IEnumerable<Favorite> s)
        {
            P = p;
            S = s;
        }

        public List<Post> postlist { get; set; }
        public List< Favorite >favlist { get; set; }
        public Post P { get; }
        public IEnumerable<Favorite> S { get; }
    }

}