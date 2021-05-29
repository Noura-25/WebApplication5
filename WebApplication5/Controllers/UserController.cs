using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Register()
        {
            Viewer viewer = new Viewer();

            return View(viewer);
        }
        [HttpPost]
        public ActionResult Register(Viewer viewer, Admin admin, Editor editor)
        {
            

            if (db.Viewers.Any(X => X.username == viewer.username))
            {
                ViewBag.DuplicateMessage = "Username Already Exist";
                return View("Register", viewer);
            }
            if (viewer.Role == "Viewer")
            {

                db.Viewers.Add(viewer);

                db.SaveChanges();
            }
            else if (viewer.Role == "Admin")
            {

                db.Admins.Add(admin);

                db.SaveChanges();
            }



            else if (viewer.Role == "Editor")
            {

                db.Editors.Add(editor);

                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registeration is successful";
            return View("Register", new Viewer());
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Viewer viewer, Admin admin, Editor editor)
        {
            if (viewer.Role == "Admin")
            {
                var user = db.Admins.Where(x => x.Email == admin.Email && x.Password == viewer.Password && x.Role == viewer.Role).Count();
                if (user > 0)
                {
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Login successful";
                    return RedirectToAction("Dashboard");
                }
            }
            else if (viewer.Role == "Viewer")
            {
                var user = db.Viewers.Where(x => x.Email == viewer.Email && x.Password == viewer.Password && x.Role == viewer.Role).Count();
                if (user > 0)
                {
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Login successful";
                    return RedirectToAction("viewerPage", "Posts");

                }
            }
            else if (viewer.Role == "Editor")
            {
                var user = db.Editors.Where(x => x.Email == editor.Email && x.Password == viewer.Password && x.Role == viewer.Role).Count();
                if (user > 0)
                {
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Login successful";
                    return View("Editorlayout");

                }
            }

            else
            {
                ModelState.Clear();
                ViewBag.FailMessage = "Login Failed Check Your Information";


            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();


        }
        public ActionResult viewerlayout()
        {
            return View();
        }
        public ActionResult Editorlayout()
        {
            return View();



        }


        [HttpPost]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
            return View("Login");
        }

    }
}