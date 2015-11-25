using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICEMS_WebManagement2;

namespace ICEMS_WebManagement2.Controllers
{
    public class CalibPointsController : Controller
    {
        private iCEMSDBEntities db = new iCEMSDBEntities();

        // GET: CalibPoints
        public ActionResult Index()
        {
            return View(db.CalibPoints.ToList());
        }

        // GET: CalibPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalibPoints calibPoints = db.CalibPoints.Find(id);
            if (calibPoints == null)
            {
                return HttpNotFound();
            }
            return View(calibPoints);
        }

        // GET: CalibPoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalibPoints/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pointname,plantid,machine")] CalibPoints calibPoints)
        {
            if (ModelState.IsValid)
            {
                db.CalibPoints.Add(calibPoints);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calibPoints);
        }

        // GET: CalibPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalibPoints calibPoints = db.CalibPoints.Find(id);
            if (calibPoints == null)
            {
                return HttpNotFound();
            }
            return View(calibPoints);
        }

        // POST: CalibPoints/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pointname,plantid,machine")] CalibPoints calibPoints)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calibPoints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calibPoints);
        }

        // GET: CalibPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalibPoints calibPoints = db.CalibPoints.Find(id);
            if (calibPoints == null)
            {
                return HttpNotFound();
            }
            return View(calibPoints);
        }

        // POST: CalibPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalibPoints calibPoints = db.CalibPoints.Find(id);
            db.CalibPoints.Remove(calibPoints);
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
