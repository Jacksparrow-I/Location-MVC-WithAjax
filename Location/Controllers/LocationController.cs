using Location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Location.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            //int CompanyIdId = 1;
            LocationDbHandller DbLocation = new LocationDbHandller();
            ModelState.Clear();
            Locations model = new Locations();
            var data = DbLocation.GetLocationsList();

            List<SelectListItem> items = new List<SelectListItem>();

            var list = data.Select(p => new SelectListItem
            {
                Value = p.CountryName.ToString(),
                Text = p.CountryName.ToString()
            });
            var listcn = new SelectList("Value", "Text");
            ViewBag.CountryName = list;

            return View(data);
        }


        // GET: Default/Edit/5
        public ActionResult Edit(int id = 3)
        {
            LocationDbHandller DbLocation = new LocationDbHandller();
            var data = DbLocation.GetLocation();

            List<SelectListItem> items = new List<SelectListItem>();

            var listCountry = data.Select(p => new SelectListItem
            {
                Value = p.CountryId.ToString(),
                Text = p.CountryName.ToString()
            });
            var listcnCountry = new SelectList("Value", "Text");
            //ViewBag.CountryName = listCountry;


            var listCountryId = data.Select(p => new SelectListItem
            {
                Value = p.CountryId.ToString(),
                Text = p.CountryId.ToString()
            });
            var listcnCountryId = new SelectList("Value", "Text");
            //ViewBag.CountryID = listCountryId;


            var listState = data.Select(p => new SelectListItem
            {
                Value = p.StateId.ToString(),
                Text = p.StateName.ToString()
            });
            var listcnState = new SelectList("Value", "Text");
            //ViewBag.StateName = listState;


            var listCity = data.Select(p => new SelectListItem
            {
                Value = p.CityName.ToString(),
                Text = p.CityName.ToString()
            });
            var listcnCity = new SelectList("Value", "Text");

            ViewBag.CountryName = listCountry;
            ViewBag.StateName = listState;
            ViewBag.CityName = listCity;
            ViewBag.CountryId = listCountryId;

            return View(data);
        }

        // POST: Default/Edit
        [HttpPost]
        public ActionResult Edit(Locationssave Location)
        {
            try
            {
                //LocationDbHandller DbLocation = new LocationDbHandller();
                //List<SelectListItem> items = new List<SelectListItem>();

                //if (Location.CountryName == null || Location.CountryName == "1")
                //{
                //    //Location.CountryName = "India";
                //    Location.CountryName = "1";
                //}

                //if (Location.StateName == null || Location.StateName == "0")
                //{
                //    //Location.StateName = "Gujarat";
                //    Location.StateName = "1";
                //}

                //var data = DbLocation.GetLocation();
                //var dataCountrytostate = DbLocation.GetStateLocationByCountry(Location);
                //var dataStatetoCity = DbLocation.GetCityLocationByState(Location);

                //// Country List 
                //var listCountry = data.Select(p => new SelectListItem
                //{
                //    Value = p.CountryId.ToString(),
                //    Text = p.CountryName.ToString()
                //});
                //var listcnCountry = new SelectList("Value", "Text");
                //ViewBag.CountryName = listCountry;

                //// State List 
                //var listState = dataCountrytostate.Select(p => new SelectListItem
                //{
                //    Value = p.StateName.ToString(),
                //    Text = p.StateName.ToString()
                //});
                //var listcnState = new SelectList("Value", "Text");
                //ViewBag.StateName = listState;

                //// City List 
                //var listCity = dataStatetoCity.Select(p => new SelectListItem
                //{
                //    Value = p.CityName.ToString(),
                //    Text = p.CityName.ToString()
                //});
                //var listcnCity = new SelectList("Value", "Text");
                //ViewBag.CityName = listCity;

                //data = dataCountrytostate;
                //data = dataStatetoCity;

                //ViewBag.CountryName = listCountry;
                //ViewBag.StateName = listState;
                //ViewBag.CityName = listCity;



                //if (data != null)
                //{
                //    @ViewBag.Message = "List Added Successfully";
                //}
                //Thread.Sleep(800);
                //return Json(data, JsonRequestBehavior.AllowGet); 
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetCountry()
        {
            try
            {
                LocationDbHandller DbLocation = new LocationDbHandller();
                List<SelectListItem> items = new List<SelectListItem>();
                Thread.Sleep(50);
                var data = DbLocation.GetLocation();

                if (data != null)
                {
                    @ViewBag.Message = "List Added Successfully";
                }
                //Thread.Sleep(800);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult EditState(string CountryName)
        {
            try
            {
                LocationDbHandller DbLocation = new LocationDbHandller();
                List<SelectListItem> items = new List<SelectListItem>();

                if (CountryName == null || CountryName == "0")
                {
                    //Location.CountryName = "India";
                    CountryName = "1";
                }
                var data = DbLocation.GetStateLocationByCountry(CountryName);

                if (data != null)
                {
                    @ViewBag.Message = "List Added Successfully";
                }
                //Thread.Sleep(800);
                return Json(data, JsonRequestBehavior.AllowGet);
                //return View(data);
            }
            catch
            {
                return Json(View());
            }
        }

        [HttpPost]
        public JsonResult EditCity(string CountryName, string StateName)
        {
            try
            {
                LocationDbHandller DbLocation = new LocationDbHandller();
                List<SelectListItem> items = new List<SelectListItem>();

                if (CountryName == null || CountryName == "0")
                {
                    //Location.CountryName = "India";
                    CountryName = "India";
                }

                if (StateName == null || StateName == "0")
                {
                    //Location.CountryName = "India";
                    //StateName = "1";
                    if (CountryName == "1")
                    {
                        StateName = "1";
                    }
                    else if(CountryName == "2")
                    {
                        StateName = "5";
                    }
                    else if (CountryName == "3")
                    {
                        StateName = "8";
                    }
                    else if (CountryName == "4")
                    {
                        StateName = "11";
                    }
                }

                var data = DbLocation.GetCityLocationByState(CountryName, StateName);

                if (data != null)
                {
                    @ViewBag.Message = "List Added Successfully";
                }
                //Thread.Sleep(800);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(View());
            }
        }

        // POST: Country/Delete/4
        [HttpPost]
        public ActionResult Delete(string CountryId)
        {
            try
            {
                // TODO: Add delete logic here

                LocationDbHandller DbLocation = new LocationDbHandller();
                if (DbLocation.DeleteByCompanyId(CountryId))
                {
                    ViewBag.SuccessMsg = "Country Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
