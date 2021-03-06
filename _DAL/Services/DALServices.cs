﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GroupCWebAPI._BAL.Models;
using GroupCWebAPI._DAL.Models;
using GroupCWebAPI._DAL.Services;



namespace GroupCWebAPI._DAL.Services
{
    public interface IDALService
    {
        List<NewItemBLLModel> FetchAllNewIems();
        void DeleteNewItem(long id);
        void UpdateNewItem(NewItemBLLModel model);
        void AddNewItem(NewItemBLLModel model);



    }

    public class DALServices : IDALService
    {
        private readonly GroupCContext context;

        public DALServices(GroupCContext _context)
        {
            this.context = _context;
        }

        public List<NewItemBLLModel> FetchAllNewItems()
        {
            var efModel = context.NewItem.ToList();
            var returnObject = new List<NewItemBLLModel>();

            foreach (var item in efModel)
            {
                returnObject.Add(new NewItemBLLModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    createdDate = item.createdDate,
                    Size = item.Size,
                    Price = item.Price
                });
            }

            return returnObject;
        }



        public List<NewItemBLLModel> FetchAllNewIems()
        {
            var efModel = context.NewItem.ToList();
            var returnObject = new List<NewItemBLLModel>();

            foreach (var item in efModel)
            {
                returnObject.Add(new NewItemBLLModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    createdDate = item.createdDate,
                    Size = item.Size,
                    Price = item.Price
                });
            }

            return returnObject;
        }

        public void DeleteNewItem(long id)
        {
            var item = context.NewItem
          .Where(p => p.Id == id).FirstOrDefault();
            if (item != null)
            {
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
            }

            }

        public void UpdateNewItem(NewItemBLLModel model)
        {
            var item = context.NewItem
            .Where(p => p.Id == model.Id).FirstOrDefault();
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(model);
                context.SaveChanges();
            }
            else {
                throw new KeyNotFoundException();
            }
        }

        public void AddNewItem(NewItemBLLModel model)
        {
            var item = new NewItem()
            {
                Id = model.Id,
                Name = model.Name,
                createdDate = model.createdDate,
                Size = model.Size,
                Price = model.Price
            };
            context.NewItem.Add(item);
            context.SaveChanges();
        }
    }
}
