using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data_1.Models;

namespace Data_1.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movies
        public ActionResult Index()
        {

            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var viewModel = new CreateOrEditViewModel { // Nytt viewModel-objekt
                Movie = new Movie {
                    Year = DateTime.Today.Year
                }, // Lager et Movie-objekt med inneværende år som default verdi
                Genres = GetGenres()
        };
            return View(viewModel);
        }

        // Metode som heter ut Genres:
    public IEnumerable<SelectListItem> GetGenres()
    {
            return db.Genres
                .Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() })
                .ToList();        
    }

    // POST: Movies/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movie")] CreateOrEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(viewModel.Movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.Genres = GetGenres();

            return View(viewModel);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CreateOrEditViewModel // Nytt viewModel-objekt
            { 
                Movie = movie,
                
                Genres = GetGenres()
            };

            return View(viewModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Movie")] CreateOrEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.Movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.Genres = GetGenres();
            
            return View(viewModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
