using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new CatContext(serviceProvider.GetRequiredService<DbContextOptions<CatContext>>()))
            {
                if (db.Cat.Any())
                {
                    return;
                }

                db.Cat.AddRange(
                    new Cat
                    {
                        Name = "Bo",
                        Age = "3 Months",
                        Breed = "Manx-Mix",
                        Color = "Tabby (Brown/White)",
                        Gender = "Male",
                        Application = new List<Application> {
                            
                        }
                    },

                    new Cat
                    {
                        Name = "Willow",
                        Age = "1 Year",
                        Breed = "Domestic Short Hair",
                        Color = "Tabby (Gray/Blue/Silver",
                        Gender = "Female",
                        Application = new List<Application> {
                            
                        }
                    },

                    new Cat
                    {
                        Name = "Sally",
                        Age = "7 Months",
                        Breed = "Domestic Short Hair",
                        Color = "Black",
                        Gender = "Female",
                        Application = new List<Application> {
                            
                        }
                    },

                    new Cat
                    {
                        Name = "Basil",
                        Age = "1.5 Years",
                        Breed = "Tabby/Tiger Mix",
                        Color = "Orange/White ",
                        Gender = "Male",
                        Application = new List<Application> {
                            
                        }
                    }
                );
                db.SaveChanges();
            }
        }
    }
}