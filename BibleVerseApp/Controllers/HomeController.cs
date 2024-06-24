using BibleVerseApp.Data;
using BibleVerseApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibleVerseApp.Controllers {
    /// <summary>
    /// controller class that will redirect to the correct views
    /// </summary>
    public class HomeController : Controller {
        //logger instance was already created in project by .net
        private readonly ILogger<HomeController> _logger;
        //repository for interacting with the bible verse models we retrieve from the db
        private readonly BibleVerseRepository _repository;

        /// <summary>
        /// constructor to initialize both properties
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        public HomeController(ILogger<HomeController> logger, BibleVerseRepository repository) {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// method to display home index page
        /// </summary>
        /// <returns>index</returns>
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// method to search for bible verses in the testament chosen
        /// </summary>
        /// <param name="model"></param>
        /// <returns>search results</returns>
        public async Task<IActionResult> SearchVerse(BibleVerseSearchModel model) {
            if(!ModelState.IsValid) {
                //if model state is invalid, return back to index
                return View("Index", model);
            }

            var results = await _repository.SearchVersesAsync(model.SearchVerse, model.Testament);
            ViewData["SearchResult"] = model.SearchVerse;
            //return search resutls view with matching searchterm
            return View("SearchResults", results);
        }

        /// <summary>
        /// method to display all verses in new testament
        /// </summary>
        /// <returns>testament with new testament verses</returns>
        public async Task<IActionResult> NewTestament() {
            var newTestamentVerses = await _repository.GetAllNewTestamentVersesAsync();
            //variable to display in the testament page this is the new testament
            ViewData["TestamentTitle"] = "New Testament";
            return View("Testament", newTestamentVerses);
        }

        /// <summary>
        /// method to display all verses in new testament
        /// </summary>
        /// <returns>testament with old testament verses</returns>
        public async Task <IActionResult> OldTestament() {
            var oldTestamentVerses = await _repository.GetAllOldTestamentVersesAsync();
            //variable to display in the testament page this is the old testament
            ViewData["TestamentTitle"] = "Old Testament";
            return View("Testament", oldTestamentVerses);
        }

        /// <summary>
        /// method to redirect to privacy page
        /// </summary>
        /// <returns>privacy.cshtml</returns>
        public IActionResult Privacy() {
            return View();
        }

        /// <summary>
        /// method to handle errors
        /// </summary>
        /// <returns>error page with details</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}