using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulrhmanBooks.DataAccess.Repository.IRepository
{
    interface UnitOfWork : IDisposable
    {
        ICategoryRepository category { get; }
        ISP_Call SP_Call { get; }
     }
}
