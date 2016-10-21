namespace Layui.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Upload
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string AuthorID { get; set; } 
        public int Size { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }  
        public string SourceName { get; set; }
        [MaxLength(128)]
        public string MimeType { get; set; }  
        public int PostTime { get; set; }  
        public int DownNums { get; set; }  
        public int PostID { get; set; } 
        public string Intro { get; set; }  
        public string Meta { get; set; }
        // Navigation properties
        public virtual Post Post { get; set; }
    }
}
