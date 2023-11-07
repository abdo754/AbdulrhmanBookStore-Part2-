using AbdulrhmanBooks.DataAccess.Repository.IRepository;
using AbdulrhmanBooks.Models;
using AbdulrhmanBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulrhmanBooks.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db; // Correct the field name
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; // Correct the field name
        }
    }
}
