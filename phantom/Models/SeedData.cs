using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace phantom.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
			using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
                var context=serviceScope.ServiceProvider.GetService<MyDbContext>();
				// Look for any phantoms
				if (context.Topic.Count()==0)
				{
					context.Topic.AddRange(
					 new Topic
					 {
						 Title = "When Harry Met Sally",
						 PostDate = DateTime.Parse("1989-1-11"),
						 Content = "Romantic Comedy",
                         ReplyCount = 1,
                    ReplyDate=DateTime.Parse("1989-1-11"),
                    NodeId=1
					 },

					 new Topic
					 {
						 Title = "Ghostbusters ",
						 PostDate = DateTime.Parse("1984-3-13"),
						 Content = "Comedy",
						 ReplyCount = 1,
						 ReplyDate = DateTime.Parse("1989-1-11"),
						 NodeId = 1
					 },

					 new Topic
					 {
						 Title = "Ghostbusters 2",
						 PostDate = DateTime.Parse("1986-2-23"),
						 Content = "Comedy",
						 ReplyCount = 1,
						 ReplyDate = DateTime.Parse("1989-1-11"),
						 NodeId = 1
					 },

				   new Topic
				   {
					   Title = "Rio Bravo",
					   PostDate = DateTime.Parse("1959-4-15"),
					   Content = "Western",
					   ReplyCount = 1,
					   ReplyDate = DateTime.Parse("1989-1-11"),
					   NodeId = 1
				   });
				}
				if (context.User.Count()==0)
				{
					context.User.AddRange(
						new User{
							Username="115115",
							Password="110110",
							Email = "75200306@qq.com"
						},
						new User{
							Username="115116",
							Password="110110",
							Email = "1@qq.com"
						}
					);
				}
				context.SaveChanges();
			}
        }
    }
}
