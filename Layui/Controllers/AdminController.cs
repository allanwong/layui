using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Layui.Models;
using Layui.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Layui.Controllers
{
    public class AdminController : Controller
    {
        private Entities db = new Entities();
        private ApplicationDbContext adb = new ApplicationDbContext();
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Admin/List
        public ActionResult List()
        {
            string sqlstr = @"SELECT Post.Id,Post.Type,Post.Title,Post.PostTime,Post.CommNums,
AspNetUsers.UserName,Categories.Name as CategoryName
FROM (Post LEFT JOIN AspNetUsers ON AspNetUsers.Id = Post.MemID) LEFT JOIN Categories on Categories.Id = Post.CategoryID
WHERE CategoryID > 0";
            var posts = db.Database.SqlQuery<PostList>(sqlstr);
            return View(posts.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categorys, "Id", "Name");
            ViewBag.MemID = new SelectList(adb.Users, "Id", "UserName");
            return View();
        }

        // POST: /Admin/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="Id,CategoryID,MemID,Tag,Status,Type,Alias,IsTop,IsLock,Title,Intro,Content,PostTime,CommNums,ViewNums,Template,Meta")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.CategoryID = new SelectList(db.Categorys, "Id", "Name", post.CategoryID);
            ViewBag.MemID = new SelectList(adb.Users, "Id", "UserName");
            return View(post);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categorys, "Id", "Name", post.CategoryID);
            ViewBag.MemID = new SelectList(adb.Users, "Id", "UserName");
            return View(post);
        }

        // POST: /Admin/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CategoryID,MemID,Tag,Status,Type,Alias,IsTop,IsLock,Title,Intro,Content,PostTime,CommNums,ViewNums,Template,Meta")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.CategoryID = new SelectList(db.Categorys, "Id", "Name", post.CategoryID);
            ViewBag.MemID = new SelectList(adb.Users, "Id", "UserName",post.MemID);
            return View(post);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Pages()
        {
            string sqlstr = @"SELECT Post.Id,Post.Type,Post.Title,Post.PostTime,Post.CommNums,
AspNetUsers.UserName,'page' as CategoryName
FROM Post LEFT JOIN AspNetUsers ON AspNetUsers.Id = Post.MemID
WHERE CategoryID = 0";
            var posts = db.Database.SqlQuery<PostList>(sqlstr);
            return View(posts.ToList());
        }

        public ActionResult Tags()
        {
            var tags = db.Tags;
            return View(tags.ToList());
        }

        public ActionResult Comments()
        {
            var comments = db.Comments;
            return View(comments.ToList());
        }

        public ActionResult Modules()
        {
            var modules = db.Modules;
            return View(modules.ToList());
        }

        public ActionResult Upfiles()
        {
            var upfiles = db.Uploads;
            return View(upfiles.ToList());
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            string picFileTypes = "png,gif,jpg,jpeg";
            string fileExt = file.FileName.Substring(file.FileName.LastIndexOf("."));
            if (picFileTypes.IndexOf(fileExt) == 0)
            {
                return Json(new { code = 1, msg = "上传文件不是图片，请上传 png,gif,jpg,jpeg 的图片格式！" });
            }
            string filename = System.Guid.NewGuid().ToString() + fileExt;
            file.SaveAs(Server.MapPath("/upfile/" + filename));
            return Json(new { code = 0, msg = "", data = new { src = "/upfile/" + filename, title = file.ContentType } });
        }
        
        
        public ActionResult Categorys()
        {
            List<Category> model = db.Categorys.ToList();
            return View(model);
        }

        public ActionResult Users()
        {
            ApplicationDbContext dbc = new ApplicationDbContext();
            List<ApplicationUser> model = dbc.Users.ToList();
            dbc.Dispose();
            return View(model);
        }

        public ActionResult Roles()
        {
            List<IdentityRole> model = db.Database.SqlQuery<IdentityRole>("SELECT * FROM AspNetRoles").ToList();
            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                adb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
