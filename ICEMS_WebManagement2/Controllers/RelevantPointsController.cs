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
    public class RelevantPointsController : Controller
    {
        private iCEMSDBEntities db = new iCEMSDBEntities();

        // GET: RelevantPoints
        public ActionResult Index()
        {
            return View(db.RelevantPoints.ToList());
        }

        // GET: RelevantPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelevantPoints relevantPoints = db.RelevantPoints.Find(id);
            if (relevantPoints == null)
            {
                return HttpNotFound();
            }
            return View(relevantPoints);
        }

        // GET: RelevantPoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelevantPoints/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pointname,pointtype,plantid,machineid")] RelevantPoints relevantPoints)
        {
            if (ModelState.IsValid)
            {
                db.RelevantPoints.Add(relevantPoints);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relevantPoints);
        }

        // GET: RelevantPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelevantPoints relevantPoints = db.RelevantPoints.Find(id);
            if (relevantPoints == null)
            {
                return HttpNotFound();
            }
            return View(relevantPoints);
        }

        // POST: RelevantPoints/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pointname,pointtype,plantid,machineid")] RelevantPoints relevantPoints)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relevantPoints).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relevantPoints);
        }

        // GET: RelevantPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelevantPoints relevantPoints = db.RelevantPoints.Find(id);
            if (relevantPoints == null)
            {
                return HttpNotFound();
            }
            return View(relevantPoints);
        }

        // POST: RelevantPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelevantPoints relevantPoints = db.RelevantPoints.Find(id);
            db.RelevantPoints.Remove(relevantPoints);
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
