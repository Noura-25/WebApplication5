using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        /*public ActionResult AdminProfile(int id)
        {
            var admin = getAdmins().SingleOrDefault(c => c.ID == id );
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }*/
        public ActionResult Admins()
        {
            // lamda Exp : var_name => this Var_name
            var admins = getAdmins().ToList();

            return View(admins);
        }
        public IEnumerable<Admin> getAdmins()
        {
            var admins = db.Admins.ToList();

            return admins;
        }
        /*public ActionResult EditAdminProfile(string username)
        {
            var admin = db.Admins.Single(c => c.username.Equals(username));

            return View(admin);
        }

        [HttpPost]
        public ActionResult EditAdminProfile(Admin admin)
        {
            //validation
            try
            {
                var AdminDB = db.Admins.Single(c => c.username.Equals(admin.username));
                if (TryUpdateModel(AdminDB))
                {
                    AdminDB.username = admin.username;
                    AdminDB.Photo = admin.Photo;
                    AdminDB.PhoneNO = admin.PhoneNO;
                    AdminDB.LastName = admin.LastName;
                    AdminDB.FirstName = admin.FirstName;
                    AdminDB.Email = admin.Email;

                    db.SaveChanges();
                    return RedirectToAction("AdminProfile");
                }
                return View(AdminDB);
            }
            catch
            {
                return View();
            }
        }*/

        //*******************************************************************
        //*******************************************************************
        //*******************************************************************

        // List all viewers
        public ActionResult Viewers()
        {
            // lamda Exp : var_name => this Var_name
            var viewers = getViewers().ToList();

            return View(viewers);
        }

        public IEnumerable<Viewer> getViewers()
        {
            var viewers = db.Viewers.ToList();

            return viewers;
        }
        //Add Viewer
        public ActionResult AddViewer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddViewer(Viewer viewer)
        {
            try
            {
                db.Viewers.Add(viewer);
                db.SaveChanges();
                return RedirectToAction("Viewers");
            }
            catch
            {
                return View();
            }
        }
        //Delete Viewer
        [HttpGet]
        public ActionResult DeleteViewer(int id)
        {
            var viewer = db.Viewers.Single(c => c.ID == id);
            db.Viewers.Remove(viewer);
            db.SaveChanges();

            return RedirectToAction("Viewers");
        }
        //*******************************************************************
        //*******************************************************************
        //*******************************************************************

        // list all Editors
        public ActionResult Editors()
        {
            // lamda Exp : var_name => this Var_name
            var editors = getEditors().ToList();

            return View(editors);
        }

        public IEnumerable<Editor> getEditors()
        {
            var editors = db.Editors.ToList();

            return editors;
        }
        //Add Editor
        public ActionResult AddEditor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEditor(Editor editor)
        {
            try
            {
                db.Editors.Add(editor);
                db.SaveChanges();
                return RedirectToAction("Editors");
            }
            catch
            {
                return View();
            }
        }
        //Delete Editor
        [HttpGet]
        public ActionResult DeleteEditor(int id)
        {
            var editor = db.Editors.Single(c => c.ID == id);
            db.Editors.Remove(editor);
            db.SaveChanges();

            return RedirectToAction("Editors");
        }
        //*******************************************************************
        //*******************************************************************
        //*******************************************************************

        //Control Posts

        public ActionResult Posts()
        {
            // lamda Exp : var_name => this Var_name
            var posts = getPosts().Where(y => y.Approve == true);

            return View(posts);
        }

        public IEnumerable<Post> getPosts()
        {
            var posts = db.Posts.ToList();

            return posts;
        }
        //post details
        public ActionResult PostDetails(int id)
        {
            var post = getPosts().SingleOrDefault(c => c.post_id == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }
        //Edit post
        [HttpGet]
        public ActionResult EditPost(int id)
        {
            var post = db.Posts.Single(c => c.post_id == id);
            
            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost(Post post)
        {
            //validation
            try
            {
                var PostDB = db.Posts.Single(c => c.post_id == post.post_id);
                if (TryUpdateModel(PostDB))
                {
                    PostDB.Approve = post.Approve;
                    PostDB.ArticleBody = post.ArticleBody;
                    PostDB.ArticleTitle = post.ArticleTitle;
                    PostDB.Date = post.Date;
                    PostDB.Dislikes = post.Dislikes;
                    PostDB.Editors = post.Editors;
                    PostDB.Favorites = post.Favorites;
                    PostDB.image = post.image;
                    PostDB.Likes = post.Likes;
                    PostDB.post_id = post.post_id;
                    PostDB.Questions = post.Questions;
                    PostDB.Type = post.Type;
                    PostDB.Viewers = post.Viewers;
                    db.SaveChanges();
                    return RedirectToAction("Posts");
                }
                return View(PostDB);
            }
            catch
            {
                return View();
            }
        }
        //Delete Post
        [HttpGet]
        public ActionResult DeletePost(int id)
        {
            var post = getPosts().SingleOrDefault(c => c.post_id == id);
            db.Posts.Remove(post);
            db.SaveChanges();

            return RedirectToAction("Posts");
        }
        //Add Post
        public ActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            try
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Posts");
            }
            catch
            {
                return View();
            }
        }
        //*******************************************************************
        //*******************************************************************
        //*******************************************************************

        //List Post's Request
        public ActionResult PostRequest()
        {
            var posts = getPosts().Where(y => y.Approve == null);

            return View(posts);
        }
    }
}