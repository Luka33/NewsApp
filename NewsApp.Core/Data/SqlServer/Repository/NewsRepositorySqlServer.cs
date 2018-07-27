using NewsApp.Core.Data.Interfaces;
using NewsApp.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.Data.SqlServer.Repository
{
    public class NewsRepositorySqlServer : RepositorySqlServer<News>, INewsRepository
    {
        public NewsRepositorySqlServer(NewsAppDbContext context) : base(context) { }
    }
}
