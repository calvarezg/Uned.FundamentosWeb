using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class GuitarController : Controller
    {
        private IGuitarRepository Repository { get; set; }

        public GuitarController(IGuitarRepository repository)
        {
            Repository = repository;
        }

        public ActionResult Index()
        {
            var guitars = Repository.GetAllGuitars();
            return View(guitars);
        }

        public ActionResult GetByName(string name)
        {
            var guitars = Repository.GetGuitarsByName(name);
            ViewBag.SearchCriteria = name;
            return View("Index", guitars);
        }

        public ActionResult Details(int id)
        {
            var guitar = Repository.GetById(id);
            return View(guitar);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guitar guitar)
        {
            try
            {
                if (guitar.IsValid()) 
                {
                    Repository.Add(guitar);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Errors = guitar.Errors;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var guitar = Repository.GetById(id);
            return View(guitar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Guitar guitar)
        {
            try
            {
                Repository.Update(id, guitar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
