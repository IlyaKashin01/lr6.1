using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lr6.DAO;
using lr6.Models;

namespace lr6.Controllers
{
    public class HomeController : Controller
    {
        TransportDAO transportDAO = new TransportDAO();
        // GET: /Home/
        public ActionResult Index()
        {
            return View(transportDAO.GetAllTransport());
        }
        // GET: /Home/Create
        [Authorize(Users = "Administrator@post.com")]
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Users = "Administrator@post.com")]
        public ActionResult Create([Bind(Exclude = "ID")] Cars
       auto)
        {
            try
            {
                if (transportDAO.AddTransport(auto))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }
        // GET: Tours/Edit/5
        [Authorize(Users = "Administrator@post.com")]
        public ActionResult Edit(int id)
        {
            List<Cars> recordList = transportDAO.GetAllTransport();
            var item = recordList.Find((car) => car.ID == id);
            return View(item);
        }
        // POST: Tours/Edit/5
        [HttpPost]
        [Authorize(Users = "Administrator@post.com")]
        public ActionResult Edit(Cars auto)
        {
            try
            {
                if (transportDAO.EditTransport(auto, 1))
                    return RedirectToAction("Index");
                else
                    return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }
        // GET: Tours/Delete/5
        [Authorize(Users = "Administrator@post.com")]
        public ActionResult Delete(int id)
        {
            List<Cars> recordList = transportDAO.GetAllTransport();
            var item = recordList.Find((car) => car.ID == id);
            return View(item);
        }
        // POST: Tours/Delete/5
        [HttpPost]
        [Authorize(Users = "Administrator@post.com")]
        public ActionResult Delete(Cars auto)
        {
            try
            {
                if (transportDAO.DeleteRecord(auto))
                    return RedirectToAction("Index");
                else
                    return View();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin, Visitor")]
        public ActionResult Details(int id)
        {
            List<Cars> carlist = transportDAO.GetAllTransport();
            var item = carlist.Find((car) => car.ID == id);
            return View(item);
        }

    }
}