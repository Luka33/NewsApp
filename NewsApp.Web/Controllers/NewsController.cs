using Microsoft.AspNetCore.Mvc;
using NewsApp.Core.Data.Interfaces;
using NewsApp.Core.Data.Models;
using NewsApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Web.Controllers
{
    public class NewsController: Controller
    {
        private readonly INewsRepository _newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        [Route("News")]
        public IActionResult List()
        {
            var newsVM = new List<NewsViewModel>();

            IEnumerable<News> newsList = _newsRepository.GetAll().OrderBy(n => n.Name);

            if (newsList.Count() == 0)
            {
                return View("Empty");
            }
            foreach (var news in newsList)
            {
                newsVM.Add(new NewsViewModel
                {
                    News = news
                });
            }
            return View(newsVM);
        }
        public IActionResult Delete(int id)
        {
            var news = _newsRepository.GetById(id);
            _newsRepository.Delete(news);

            return RedirectToAction("List");
        }
        [Route("News/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("News/Create")]
        [HttpPost]
        public IActionResult Create(News news)
        {
            if (!ModelState.IsValid)
            {
                return View(news);
            }

            news.CreatedTimestamp = DateTime.Now;

            _newsRepository.Create(news);

            return RedirectToAction("List");
        }
        [Route("News/Update")]
        public IActionResult Update(int id)
        {
            var news = _newsRepository.GetById(id);

            return View(news);
        }
        [Route("News/Update")]
        [HttpPost]
        public IActionResult Update(News news)
        {
            if (!ModelState.IsValid)
            {
                return View(news);
            }

            _newsRepository.Update(news);

            return RedirectToAction("List");
        }
    }
}
