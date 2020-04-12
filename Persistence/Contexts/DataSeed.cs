using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullStack_Project_IE_2.Persistence.Contexts
{
    public class DataSeed
    {
        public static void Seed(AppDbContext context, IPasswordHasher passwordHasher)
        {
            

                var types = new List<Core.Models.Type>
                {
                new Core.Models.Type { Name = EType.Common.ToString() },
                new Core.Models.Type { Name = EType.Admin.ToString() }
                };

                context.Types.AddRange(types);
                context.SaveChanges();
            

            
                var users = new List<User>
                {
                    new User { Email = "admin@admin.com", Password = passwordHasher.HashPassword("12345678") },
                    new User { Email = "common@common.com", Password = passwordHasher.HashPassword("12345678") },
                };

                users[0].UserTypes.Add(new UserType
                {
                    TypeId = context.Types.SingleOrDefault(r => r.Name == EType.Admin.ToString()).Id
                });

                users[1].UserTypes.Add(new UserType
                {
                    TypeId = context.Types.SingleOrDefault(r => r.Name == EType.Common.ToString()).Id
                });

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    } 

