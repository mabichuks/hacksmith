using MuRewards.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Infrastructure
{
    public static class SeedData
    {
        public static List<Profile> GetSeedProfiles()
        {
            var list = new List<Profile>();
            list.Add(new Profile
            {
                CreatedOn = DateTime.Now,
                DoB = new DateTime(1988, 01, 02),
                Email = "maxwell@mail.com",
                FirstName = "Maxwell",
                IsManager = true,
                Id = Guid.NewGuid(),
                LastName = "Fisher",
                ManagerId = Guid.NewGuid().ToString(),
            });

            list.Add(new Profile
            {
                CreatedOn = DateTime.Now,
                DoB = new DateTime(1990, 02, 02),
                Email = "frank@mail.com",
                FirstName = "Frank",
                IsManager = false,
                Id = Guid.NewGuid(),
                LastName = "Bernard",
                ManagerId = Guid.NewGuid().ToString(),
            });

            list.Add(new Profile
            {
                CreatedOn = DateTime.Now,
                DoB = new DateTime(1990, 02, 02),
                Email = "mark@mail.com",
                FirstName = "Mark",
                IsManager = false,
                Id = Guid.NewGuid(),
                LastName = "Matthew",
                ManagerId = Guid.NewGuid().ToString(),
            });

            return list;
        }

    }
}
