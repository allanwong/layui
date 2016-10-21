namespace Layui.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Module
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string FileName { get; set; }  
        public string Content { get; set; }  
        public string HtmlID { get; set; }  
        public string Type { get; set; }  
        public int MaxLi { get; set; }  
        public string Source { get; set; }  
        public bool IsHideTitle { get; set; }  
        public string Meta { get; set; } 
    }
}
