using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apHaylliSeguridad.Business.Model;
using apHaylliSeguridad.Business.Logic;
using apHaylliSeguridad.Common;
//using apHaylliSeguridad.DataAccess;

namespace apHaylliCotizador.MVC.Controllers
{
    public class CountryController : Controller
    {

        private LoggingHandler _loggingHandler;

        public CountryController() {
            _loggingHandler = new LoggingHandler();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_loggingHandler != null)
                {
                    _loggingHandler.Dispose();
                    _loggingHandler = null;
                }
            }

            base.Dispose(disposing);
        }


        // GET: Country
        public ActionResult Index()
        {
            return View();
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                InsertCountry(int.Parse(collection["CountryID"]),
                                collection["nameCountry"],
                                collection["shortNameCountry"]);

                return RedirectToAction("ListAll");
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var country = SelectCountryById(id);
                return View(country);
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                UpdateCountry(int.Parse(collection["CountryID"]),
                                collection["nameCountry"],
                                collection["shortNameCountry"]);

                return RedirectToAction("ListAll");
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DeleteCountryById(id);
                return RedirectToAction("ListAll");
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListAll");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ListAll()
        {
            try
            {
                var countries = from e in ListAllCountries()
                                orderby e.CountryID
                                select e;
                return View(countries);
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
                ViewBag.Message = Server.HtmlEncode(ex.Message);
                return View("Error");
            }
        }
        private List<Country> ListAllCountries()
        {
            try
            {
                using (var employees = new CountryLogic())
                {
                    return employees.SelectAllCuntries();
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
            return null;
        }
        private void InsertCountry(int id, string name, string shortName)
        {
            try
            {
                using (var country = new CountryLogic())
                {
                    var entity = new Country();
                    entity.CountryID = id;
                    entity.nameCountry = name;
                    entity.shortNameCountry = shortName;

                    var opSuccessful = country.InsertCountry(entity);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
        }
        private Country SelectCountryById(int id)
        {
            try
            {
                using (var country = new CountryLogic())
                {
                    return country.SelectCountryById(id);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
            return null;
        }
        private void UpdateCountry(int id, string name, string shortName)
        {
            try
            {
                using (var countries = new CountryLogic())
                {
                    var entity = new Country();
                    entity.CountryID = id;
                    entity.nameCountry = name;
                    entity.shortNameCountry = shortName;
                    var opSuccessful = countries.UpdateCountry(entity);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
        }
        private void DeleteCountryById(int id)
        {
            try
            {
                using (var countries = new CountryLogic())
                {                   
                    var opSuccessful = countries.DeleteCountryById(id);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);
            }
        }


    }
}
