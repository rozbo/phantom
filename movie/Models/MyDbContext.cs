using System;
using Microsoft.EntityFrameworkCore;

namespace movie.Models
{
    public class MyDbContext: DbContext
    {
		public MyDbContext(DbContextOptions<MyDbContext> options)
			: base(options)
        {
            
        }

        public DbSet<Topic> Topic { get; set; }
        public DbSet<User> User { get; set; }
    }
}
