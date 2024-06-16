using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Host.Interfaces.UI
{
    /// <summary>
    /// Example View Controller.
    /// TODO:Delete
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the default 'Index' View
        /// </summary>
        /// <returns></returns>
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the 'Details' View
        /// </summary>
        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Returns the 'Create' View
        /// </summary>
        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Accepts the 'Create' View response,
        /// returning user to 'Index' view.
        /// </summary>
        // POST: HomeController/Create
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

        /// <summary>
        /// Returns the 'Edit' View
        /// </summary>
        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// Accepts the 'Edit' View response,
        /// returning user to Index view.
        /// </summary>
        // POST: HomeController/Edit/5
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

        /// <summary>
        /// Returns the 'Delete' View
        /// </summary>
        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// Acccepts tghe Delete response 
        /// and returns the Index view.
        /// </summary>
        // POST: HomeController/Delete/5
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
