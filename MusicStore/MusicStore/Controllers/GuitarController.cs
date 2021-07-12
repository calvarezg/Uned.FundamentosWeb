using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class GuitarController : Controller
    {
        public ActionResult Index()
        {            
            return View(GuitarColletction);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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


        private static List<Guitar> guitars = null;
        private static List<Guitar> GuitarColletction
        {
            get
            {
                if (guitars == null)
                {
                    guitars = new List<Guitar>();
                    guitars.Add(new Guitar() { Name = "Standard Strat.", ImagePath = "img/img-1.jpg", Price = 1600 });
                    guitars.Add(new Guitar() { Name = "Rosewood Std.", ImagePath = "img/img-2.jpg", Price = 1850 });
                    guitars.Add(new Guitar() { Name = "Limited Edition", ImagePath = "img/img-3.jpg", Price = 2665 });
                    guitars.Add(new Guitar() { Name = "Standard Mapple", ImagePath = "img/img-4.jpg", Price = 1500 });
                }

                return guitars;
            }
        }

        private IEnumerable<Guitar> GetGuitarsByName(string filter)
        {
            var guitars = from guitar in GuitarColletction
                          where guitar.Name.Contains(filter.Trim())
                          select guitar;
            return guitars.ToList();
        }
    }
}
