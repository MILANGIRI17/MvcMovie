using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.ViewModels;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext db;

        public MoviesController(MvcMovieContext _db)
        {
            db = _db;
        }
        // GET: MoviesController
        public ActionResult Index()
        {
            var model = db.Movie.ToList();
            var vm = new List<MovieViewModel>();
            foreach(var movie in model)
            {
                vm.Add(new MovieViewModel()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    ReleaseDate=movie.ReleaseDate,
                    Genre=movie.Genre,
                    Price=movie.Price,
                }); 
            }
            return View(vm);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Movie.Find(id);
            var vm = new MovieViewModel()
            {
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                Price = model.Price,
            };
            return View(vm);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel data)
        {
            try
            {
                var model = new Movie();
                model.Title= data.Title;
                model.Genre=data.Genre;
                model.ReleaseDate = data.ReleaseDate;
                model.Price = data.Price;
                db.Movie.Add(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Movie.Find(id);
            var vm = new MovieViewModel()
            {
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                Price = model.Price,
            };
            
            return View(vm);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieViewModel vm)
        {
            try
            {
                var model = db.Movie.Find(id);
                if (vm != null)
                {
                    model.Title = vm.Title;
                    model.Genre = vm.Genre;
                    model.ReleaseDate = vm.ReleaseDate;
                    model.Price = vm.Price;
                    db.Movie.Update(model);
                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Movie.Find(id);
            var vm = new MovieViewModel()
            {
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                Price = model.Price,
            };
            return View(vm);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MovieViewModel vm)
        {
            try
            {
                var model = new Movie();
                model.Id = vm.Id;
                model.Title = vm.Title;
                model.Genre = vm.Genre;
                model.ReleaseDate = vm.ReleaseDate;
                model.Price = vm.Price;
                db.Movie.Remove(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
