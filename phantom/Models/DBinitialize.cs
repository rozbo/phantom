using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace phantom.Models
{
    public static class DBinitialize
    {

        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<MyDbContext>();
                //db.Database.EnsureCreated();
                db.Database.Migrate();
            }
        }
    }
}
