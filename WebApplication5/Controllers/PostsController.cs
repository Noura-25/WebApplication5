using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class PostsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Editor



        public IEnumerable<Post> posts { get; set; }

        public PostsController()
        {
           posts= db.Posts.ToList();
        }

        // GET: Customer
        public ActionResult Posts()
        {
            // lamda Exp : var_name => this Var_name
            var posts= getpost();

            return View(posts);
        }

        public IEnumerable<Post> getpost()
        {
            var posts = db.Posts.ToList();

            return posts;
        }
















        public ActionResult AddPosts(Post post)
        {


            db.Posts.Add(post);
            db.SaveChanges();

            return View();
        }
        public ActionResult DisplayInfo()
        {
            var Editor = db.Editors.Include(P=>P.username);
            //return View(Editor.ToList());
            return View();


        }
    }
    }
      