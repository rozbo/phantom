using System;
namespace movie.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }
        public int seen { get; set; }
    }
}
