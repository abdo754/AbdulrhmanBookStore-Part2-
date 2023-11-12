using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulrhmanBooks.DataAccess.Repository.IRepository
{
    interface UnitOfWork :IDisposable
    {
        ICategoryRepository Category { get; }
        ISP_Call IS_Call { get; }
    }
}
