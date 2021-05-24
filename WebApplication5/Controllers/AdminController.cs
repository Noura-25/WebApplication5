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

        //*********************************************************
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
    }
}