namespace Layui.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PostList
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public int PostTime { get; set; }
        public int CommNums { get; set; }
    }
}