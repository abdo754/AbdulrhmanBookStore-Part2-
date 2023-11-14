using AbdulrhmanBooks.DataAccess.Repository.IRepository;
using AbdulrhmanBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulrhmanBooks.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            SP_Call = new SP_Call(_db); // Renamed from SP_Call to IS_Call
        }

        public ICategoryRepository Category { get; private set; }
        public ISP_Call SP_Call { get; private set; } // Name changed to match the interface

        public ISP_Call IS_Call
        {
            get { return SP_Call; }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
