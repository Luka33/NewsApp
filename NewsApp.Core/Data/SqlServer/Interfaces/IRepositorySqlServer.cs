using NewsApp.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.Data.SqlServer.Interfaces
{
    public interface IRepositorySqlServer<T> : IRepository<T> where T : class
    {
    }
}
