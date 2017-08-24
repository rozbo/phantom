using System;
using System.ComponentModel.DataAnnotations;

namespace phantom.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        [Display(Name="发布日期",Description = "这个帖子发布的日期")]
        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public string Content { get; set; }
        public int ReplyCount { get; set; }
        public int ViewCount { get; set; }
        public int NodeId { get; set; }
    }
}
