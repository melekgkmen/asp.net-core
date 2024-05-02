using System.Net.Mime;
using BlogApp.Entity;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestCompletion(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag {Text="Web Programming ", Url = "web-programming", Color = TagColors.warning},
                        new Tag {Text="Backend", Url="backend",Color = TagColors.success},
                        new Tag {Text="Frontend",Url="frontend",Color = TagColors.secondary},
                        new Tag {Text="FullStack",Url="fullstack",Color = TagColors.primary},
                        new Tag {Text="Php",Url="php",Color = TagColors.danger}
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName = "melekgokmen",Name="Melek Gökmen",Email="info@melekgokmen.com", Password="123456",Image="p1.jpg"},
                        new User {UserName = "serhatsogukpinar",Name="Serhat Soğukpınar",Email="info@serhatsogukpinar.com", Password="567890",Image="p2.jpg"}
                    );
                    context.SaveChanges();
                }

                 if(!context.Posts.Any())
                 {
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.net core",
                            Description = "Asp.net core lessons",
                            Content = "Asp.net core lessons",
                            Url="aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image="1.jpg",
                            UserId = 1,
                            Comments= new List<Comment>{new Comment {Text="good course",PublishedOn= new DateTime(),UserId = 1},
                            new Comment {Text="It was a course that I benefited from.",PublishedOn= new DateTime(),UserId = 2},
                            }
                        },
                        new Post{
                            Title = "Php",
                            Description = "Php lessons",
                            Content = "Php lessons",
                            Url="php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image="2.jpg",
                            UserId = 1
                        },
                        new Post{
                            Title = "Django",
                            Description = "Django lessons",
                            Content = "Django lessons",
                            Url="django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image="3.jpg",
                            UserId = 2
                        },
                        new Post{
                            Title = "React Lesson",
                            Description = "React lessons",
                            Content = "React lessons",
                            Url="react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            Image="3.jpg",
                            UserId = 2
                        },
                        new Post{
                            Title = "Angular",
                            Description = "Angular lessons",
                            Content = "Angular lessons",
                            Url="angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            Image="3.jpg",
                            UserId = 2
                        },
                        new Post{
                            Title = "Web Design",
                            Description = "Web Design lessons",
                            Content = "Web Design lessons",
                            Url="web-design",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            Image="3.jpg",
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                 }
            }
        }

    }
}