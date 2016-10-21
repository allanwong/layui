namespace Layui.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }  
        public int Order { get; set; } 
        public int Count { get; set; }
        [MaxLength(128)]
        public string Alias { get; set; }
        [MaxLength(200)]
        public string Intro { get; set; } 
        public int RootID { get; set; } 
        public int ParentID { get; set; }
        [MaxLength(128)]
        public string Template { get; set; }
        [MaxLength(128)]
        public string LogTemplate { get; set; }  
        public string Meta { get; set; }
        // Navigation properties
        public virtual ICollection<Post> Post{ get; set; }
    }
}