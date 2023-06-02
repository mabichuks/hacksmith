using MuRewards.Core.Entities;
using MuRewards.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Core.Utils
{
    public static class Mapper
    {
        public static ProfileModel ToModel(this Profile profile)
        {
            if (profile == null) return null;

            return new ProfileModel
            {
                CreatedOn = profile.CreatedOn,
                DoB = profile.DoB,
                Email = profile.Email,
                FirstName = profile.FirstName,
                Id = profile.Id,
                IsManager = profile.IsManager,
                LastName = profile.LastName,
                ManagerId = profile.ManagerId,
            };
        }

        public static CatalogModel ToModel(this  Catalog catalog)
        {
            if (catalog == null) return null;

            return new CatalogModel
            {
                Details = catalog.Details,
                Id =  catalog.Id,
                ImageUrl = catalog.ImageUrl,
                ItemCount = catalog.ItemCount,
                ItemName = catalog.ItemName,
                Value = catalog.Value
            };
        }
    }
}
