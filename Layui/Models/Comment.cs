namespace Layui.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Comment
    {
        public int Id { get; set; }
        public int PostID { get; set; }  
        public bool IsChecking { get; set; }  
        public int RootID { get; set; }  
        public int ParentID { get; set; }
        [MaxLength(128)]
        public string MemID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; } 
        public string Content { get; set; }
        [MaxLength(128)]
        public string Email { get; set; }
        [MaxLength(128)]
        public string HomePage { get; set; }  
        public int PostTime { get; set; } 
        public string IP { get; set; }
        [MaxLength(128)]
        public string Agent { get; set; }  
        public string Meta { get; set; }  
    }
}
