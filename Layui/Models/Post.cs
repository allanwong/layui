namespace Layui.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int CategoryID { get; set; }
        [MaxLength(128)]
        public string MemID { get; set; }  
        public string Tag { get; set; }  
        public int Status { get; set; }  
        public int Type { get; set; }
        [MaxLength(128)]
        public string Alias { get; set; }  
        public bool IsTop { get; set; } 
        public bool IsLock { get; set; }
        [MaxLength(128)]
        [Required]
        public string Title { get; set; } 
        public string Intro { get; set; }  
        public string Content { get; set; } 
        public int PostTime { get; set; }  
        public int CommNums { get; set; }  
        public int ViewNums { get; set; }
        [MaxLength(128)]
        public string Template { get; set; }  
        public string Meta { get; set; }
        // Navigation properties
        public virtual Category Category { get; set; }
        public virtual ICollection<Upload> Upload { get; set; }
    }
}
