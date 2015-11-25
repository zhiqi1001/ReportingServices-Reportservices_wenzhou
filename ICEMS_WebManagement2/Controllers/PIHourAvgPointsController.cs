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
    public class PIHourAvgPointsController : Controller
    {
        private iCEMSDBEntities db = new iCEMSDBEntities();

        // GET: PIHourAvgPoints
        public ActionResult Index()
        {
            return View(db.PIHourAvgPoints.ToList());
        }

        // GET: PIHourAvgPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PIHourAvgPoints pIHourAvgPoints = db.PIHourAvgPoints.Find(id);
            if (pIHourAvgPoints == null)
            {
                return HttpNotFound();
            }
            return View(pIHourAvgPoints);
        }

        // GET: PIHourAvgPoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PIHourAvgPoints/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pointname,shiftsecs")] PIHourAvgPoints pIHourAvgPoints)
        {
            if (ModelState.IsValid)
            {
                db.PIHourAvgPoints.Add(pIHourAvgPoints);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pIHourAvgPoints);
        }

        // GET: PIHourAvgPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PIHourAvgPoints pIHourAvgPoints = db.PIHourAvgPoints.Find(id);
            if (pIHourAvgPoints == null)
            {
                return HttpNotFound();
            }
            return View(pIHourAvgPoints);
        }

        // POST: PIHourAvgPoints/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pointname,shiftsecs")] PIHourAvgPoints pIHourAvgPoints)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pIHourAvgPoints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pIHourAvgPoints);
        }

        // GET: PIHourAvgPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PIHourAvgPoints pIHourAvgPoints = db.PIHourAvgPoints.Find(id);
            if (pIHourAvgPoints == null)
            {
                return HttpNotFound();
            }
            return View(pIHourAvgPoints);
        }

        // POST: PIHourAvgPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PIHourAvgPoints pIHourAvgPoints = db.PIHourAvgPoints.Find(id);
            db.PIHourAvgPoints.Remove(pIHourAvgPoints);
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
