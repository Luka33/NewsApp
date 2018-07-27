using NewsApp.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.Data.Json.Interfaces
{
    public interface IRepositoryJson<T> : IRepository<T> where T : class
    {
        void Save(IEnumerable<T> entity);
    }
}
