﻿using AbdulrhmanBooks.DataAccess.Repository.IRepository;
using AbdulrhmanBooks.Models;
using AbdulrhmanBookStore.DataAccess.Data;
using System;
using System.Linq;

namespace AbdulrhmanBooks.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                /*_db.SaveChanges();*/
            }
        }
    }
}
