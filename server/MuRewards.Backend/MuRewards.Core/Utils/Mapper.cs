﻿using MuRewards.Core.Entities;
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

        public static RewardRequestModel ToModel(this RewardRequest pagedRewards)
        {
            if (pagedRewards == null) return null;

            MuRewards.Core.Models.Status status;

            if (!Enum.TryParse(pagedRewards.Status, out status))
            {
                status = MuRewards.Core.Models.Status.Pending;
            }

            return new RewardRequestModel
            {
                Id = pagedRewards.Id,
                RequesterId = pagedRewards.RequesterId,
                AwardeeId = pagedRewards.AwardeeId,
                ManagerId = pagedRewards.ManagerId,
                Comments = pagedRewards.Comments,
                Status = status,
                 MuPoints = pagedRewards.MuPoints,
                 CreatedOn = pagedRewards.CreatedOn,
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


        public static MuWalletModel ToModel(this MuWallet model)
        {
            if (model == null) return null;

            return new MuWalletModel
            {
                Id = model.Id,
                MuPoints = model.MuPoints,
                ProfileId = model.ProfileId,
                WalletType = model.WalletType
            };
        }
    }
}