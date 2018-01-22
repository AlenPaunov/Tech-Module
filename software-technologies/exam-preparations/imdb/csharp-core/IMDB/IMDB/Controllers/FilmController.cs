using System.Linq;
using IMDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace IMDB.Controllers
{

    public class FilmController : Controller
    {

        public MySqlConnection database = new MySqlConnection("server=127.0.0.1;user id=mysqltest;password=test;port=3306;database=IMDB");

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var films = database.ToString();

            return View();
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {

                //database.Films.Add(film);
                ///database.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(film);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }


            //var film = database.Films.Where(f => f.Id == id).First();

            //if (film == null)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound);
            //}

            return View();

        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            if (ModelState.IsValid)
            {

               // var film = database.Films.FirstOrDefault(f => f.Id == filmModel.Id);

                //film.name = filmmodel.name;
                //film.year = filmmodel.year;
                //film.genre = filmmodel.genre;
                //film.director = filmmodel.director;

               // database.Entry(film).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
              //  database.SaveChanges();

                return RedirectToAction("Index");


            }
            return View(filmModel);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            //var film = database.Films.Where(f => f.Id == id).First();

            //if (film == null)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound);
            //}

            return View();


        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }


            //var film = database.Films.Where(f => f.Id == id).First();

            //if (film == null)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound);
            //}

            //database.Films.Remove(film);
            //database.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}