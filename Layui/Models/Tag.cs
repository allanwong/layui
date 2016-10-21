namespace Layui.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; } 
        public int Order { get; set; } 
        public int Count { get; set; }
        [MaxLength(128)]
        public string Alias { get; set; }  
        public string Intro { get; set; }
        [MaxLength(128)]
        public string Template { get; set; }  
        public string Meta { get; set; }  
    }
}
