using NewsApp.Core.Data.Interfaces;
using NewsApp.Core.Data.Json.Interfaces;
using NewsApp.Core.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NewsApp.Core.Data.Json.Repository
{
    public class NewsRepositoryJson : IRepositoryJson<News>, INewsRepository
    {
        protected string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\proizvodiJsonData.json";
        public NewsRepositoryJson()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }

        public void Create(News news)
        {
            IEnumerable<News> newsList = GetAll();
            if (newsList.Count() == 0)
            {
                news.Id = 1;
            }
            else
            {
                news.Id = newsList.Last().Id + 1;
            }
            newsList = newsList.Append(news).ToList();
            Save(newsList);
        }

        public void Delete(News news)
        {
            IEnumerable<News> proizvodi = GetAll();
            Save(proizvodi.Where(p => p.Id != news.Id).ToList());
        }

        public IEnumerable<News> GetAll()
        {
            string dataText = File.ReadAllText(filePath);
            IEnumerable<News> newsList = JsonConvert.DeserializeObject<IEnumerable<News>>(dataText);

            return newsList;
        }

        public News GetById(int id)
        {
            IEnumerable<News> newsList = GetAll();
            News news = newsList.Where(p => p.Id == id).FirstOrDefault();

            return news;
        }
        public void Save(IEnumerable<News> newsList)
        {
            var changedData = JsonConvert.SerializeObject(newsList);
            File.WriteAllText(filePath, changedData);
        }

        public void Update(News news)
        {
            IEnumerable<News> proizvodi = GetAll();
            Save(proizvodi.Select(p => p.Id == news.Id ? news : p).ToList());
        }
    }
}
