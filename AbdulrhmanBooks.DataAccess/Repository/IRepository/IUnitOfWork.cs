﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulrhmanBooks.DataAccess.Repository.IRepository
{
   public interface IUnitOfWork :IDisposable
    {
        ICategoryRepository Category { get; }
        ISP_Call IS_Call { get; }
    }
}