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
            posts = db.Posts.ToList();
        }

        // GET: Customer
        public ActionResult Posts()
        {
            // lamda Exp : var_name => this Var_name
            var posts = getpost();

            return View(posts);
        }

        public IEnumerable<Post> getpost()
        {
            var posts = db.Posts.ToList();

            return posts;
        }

        public ActionResult Main()// viewer Read only posts  without any interaction
        {
            return View(db.Posts.Where(x => x.Approve == true).ToList());

        }
        public ActionResult viewerPage()// viewer layout to see all posts and interact  
        {


            return View(db.Posts.Where(x => x.Approve == true).ToList());
        }

        public ActionResult Details(int id) // view post 
        {

            var details = getpost().SingleOrDefault(c => c.post_id == id);
            if (details == null)
            {
                return HttpNotFound();
            }

            return View(details);
        }


        public ActionResult AddPosts(Post post)
        {


            db.Posts.Add(post);
            db.SaveChanges();

            return View();
        }

        //public ActionResult DisplayInfo()
        //{
        //    var Editor = db.Editors.Include(P=>P.username);
        //    //return View(Editor.ToList());
        //    return View();


        //}

        public ActionResult comment(Question question, int id)
        {
            //var details = db.Questions.FirstOrDefault(c => c.post_id == id);

            //if (details == null)
            //{
            //    return RedirectToAction("Main");
            //}
            //else
            //{
            //    question.post_id = id;

            //    db.Questions.Add(question);
            //    db.SaveChanges();
            //    return View("viewerpage");
            
                var details = getpost().SingleOrDefault(c => c.post_id == id);
            question.post_id = id;
            db.Questions.Add(question);
                db.SaveChanges();
                return View();

            }
        
        public ActionResult save(int id)
        {
            var saved = new Favorite();
            var post = db.Favorites.SingleOrDefault(c => c.post_id == id);
            if (post != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                saved.post_id = id;
                ViewBag.SuccessMessage = "Post Saved";
                db.Favorites.Add(saved);
                db.SaveChanges();
                return RedirectToAction("viewerPage");
            }
        }
        //public ActionResult likes(int id)
        //{
        //    var likes = new Post();
        //    var details = db.Posts.SingleOrDefault(c => c.post_id == id);
        //    if (details != null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        likes.post_id = id;
        //        details.Likes++;
        //        db.Posts.Add(likes);
        //        db.SaveChanges();
        //        return RedirectToAction("viewerPage");
        //    }

        //}
    }
}

