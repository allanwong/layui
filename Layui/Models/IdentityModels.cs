using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace Layui.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string IP { get; set; }
        public int PostTime { get; set; }
        public string Alias { get; set; }
        public string Intro { get; set; }
        public int Articles { get; set; }
        public int Pages { get; set; }
        public int Comments { get; set; }
        public int Uploads { get; set; }
        public string Template { get; set; }
        public string Meta { get; set; } 
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

 
    }


}