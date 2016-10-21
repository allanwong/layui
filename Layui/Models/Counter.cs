namespace Layui.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Counter
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string MemID { get; set; }
        [MaxLength(128)]
        public string IP { get; set; }
        [MaxLength(128)]
        public string Agent { get; set; }
        [MaxLength(128)]
        public string Refer { get; set; }
        [MaxLength(128)]
        public string Title { get; set; }  
        public int PostTime { get; set; } 
        public string Description { get; set; }  
        public string PostData { get; set; } 
        public string AllRequestHeader { get; set; }  
    }
}
