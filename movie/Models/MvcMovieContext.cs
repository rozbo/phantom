using System;
using Microsoft.EntityFrameworkCore;

namespace movie.Models
{
    public class MvcMovieContext: DbContext
    {
		public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
			: base(options)
        {
            
        }

        public DbSet<movie.Models.Topic> Topic { get; set; }
        public DbSet<movie.Models.User> User { get; set; }
    }
}
