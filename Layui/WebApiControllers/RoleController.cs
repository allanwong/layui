using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Layui.Models;

namespace Layui.WebApiControllers
{
    [Authorize]
    public class RoleController : ApiController
    {
        private Entities db = new Entities();
        // GET api/role
        public IEnumerable<IdentityRole> Get()
        {
            List<IdentityRole> Roles = db.Database.SqlQuery<IdentityRole>("SELECT * FROM AspNetRoles").ToList();
            return Roles;
        }

        // GET api/role/5
        public IdentityRole Get(int id)
        {
            IdentityRole role = db.Database.SqlQuery<IdentityRole>("SELECT * FROM AspNetRoles WHERE Id = @p0", id).FirstOrDefault();
            return role;
        }

        // POST api/role
        public void Post([FromBody] IdentityRole role)
        {
            
            db.Database.ExecuteSqlCommand("INSERT INTO AspNetRoles (Id,Name)VALUES(@p0,@p1)",Guid.NewGuid().ToString(), role.Name);
        }

        // PUT api/role/5
        public void Put(int id, [FromBody] IdentityRole role)
        {
            db.Database.ExecuteSqlCommand("UPDATE AspNetRoles set Name = @p0 WHERE Id = @p1", role.Name,id);
        }

        // DELETE api/role/5
        public void Delete(int id)
        {
            db.Database.ExecuteSqlCommand("DELETE AspNetRoles WHERE Id = @p0", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
