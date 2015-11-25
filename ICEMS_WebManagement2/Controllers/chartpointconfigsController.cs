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
    public class chartpointconfigsController : Controller
    {
        private iCEMSDBEntities db = new iCEMSDBEntities();

        // GET: chartpointconfigs
        public ActionResult Index()
        {
            return View(db.chartpointconfig.ToList());
        }

        // GET: chartpointconfigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chartpointconfig chartpointconfig = db.chartpointconfig.Find(id);
            if (chartpointconfig == null)
            {
                return HttpNotFound();
            }
            return View(chartpointconfig);
        }

        // GET: chartpointconfigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: chartpointconfigs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pointname,type")] chartpointconfig chartpointconfig)
        {
            if (ModelState.IsValid)
            {
                db.chartpointconfig.Add(chartpointconfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chartpointconfig);
        }

        // GET: chartpointconfigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chartpointconfig chartpointconfig = db.chartpointconfig.Find(id);
            if (chartpointconfig == null)
            {
                return HttpNotFound();
            }
            return View(chartpointconfig);
        }

        // POST: chartpointconfigs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pointname,type")] chartpointconfig chartpointconfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chartpointconfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chartpointconfig);
        }

        // GET: chartpointconfigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chartpointconfig chartpointconfig = db.chartpointconfig.Find(id);
            if (chartpointconfig == null)
            {
                return HttpNotFound();
            }
            return View(chartpointconfig);
        }

        // POST: chartpointconfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chartpointconfig chartpointconfig = db.chartpointconfig.Find(id);
            db.chartpointconfig.Remove(chartpointconfig);
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
