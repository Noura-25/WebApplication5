using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class EditorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Editor
        public ActionResult AddPosts(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();

            return View();
        }
    }
}