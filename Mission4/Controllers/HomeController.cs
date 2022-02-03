using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        // Receive from the database and pass to the database
        private MovieCollectionsContext _MovieContext { get; set; }

        public HomeController(MovieCollectionsContext MovieName)
        {
            _MovieContext = MovieName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            // ViewBag."xxx" name can be any, _MovieContext."xxx" name is from the Dbset of Context in the models
            ViewBag.Categories = _MovieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddNewMovie add)
        {
            if (ModelState.IsValid)
            {
                //post the info to the database
                _MovieContext.Add(add);

                //Save the info to the database
                _MovieContext.SaveChanges();

                return View("Confirmation", add);
            }
            else //if invalid
            {
                ViewBag.Categories = _MovieContext.Categories.ToList();

                return View();
            }


        }

        //Pulling data once the form had submitted
        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = _MovieContext.AddNewMovies
                .Include(x => x.Category)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Pull the data from the Movie Categories list, so you can edit
            ViewBag.Categories = _MovieContext.Categories.ToList();

            // Find the record that is asscocaited with the id(parameter) Match them together
            var edit = _MovieContext.AddNewMovies
                .Single(x => x.MovieId == id);

            // Add the variable behind the view page so that it will shows up when you click edit
            return View("AddMovie", edit);
        }


        [HttpPost]
        public IActionResult Edit(AddNewMovie edit)
        {
            //Update the database infor
            _MovieContext.Update(edit);

            //Save changes
            _MovieContext.SaveChanges();

            //Redirect to the the List page
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the record that is asscocaited with the id(parameter) Match them together
            var delete = _MovieContext.AddNewMovies
                .Single(x => x.MovieId == id);

            return View(delete); ;
        }

        [HttpPost]
        public IActionResult Delete(AddNewMovie delete)
        {

            //Remove the database infor
            _MovieContext.AddNewMovies.Remove(delete);

            //Save changes
            _MovieContext.SaveChanges();

            //Redirect to the the List page
            return RedirectToAction("MovieList");

        }

    }
}
