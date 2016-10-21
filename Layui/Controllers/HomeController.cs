using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Layui.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ContentResult Install()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                string sqlstr = @"DROP TABLE [Category];
DROP TABLE [Comment];
DROP TABLE [Config];
DROP TABLE [Counter];
DROP TABLE [Module];
DROP TABLE [Post];
DROP TABLE [Tag];
DROP TABLE [Upload];
DROP TABLE [__MigrationHistory];";

                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                cmd.ExecuteNonQuery();
            }
            

            return Content("成功");
        }
    }
}