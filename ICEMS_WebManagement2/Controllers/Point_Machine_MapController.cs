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
    public class Point_Machine_MapController : Controller
    {
        private iCEMSDBEntities db = new iCEMSDBEntities();

        // GET: Point_Machine_Map
        public ActionResult Index()
        {
            return View(db.Point_Machine_Map.ToList());
        }

        // GET: Point_Machine_Map/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point_Machine_Map point_Machine_Map = db.Point_Machine_Map.Find(id);
            if (point_Machine_Map == null)
            {
                return HttpNotFound();
            }
            return View(point_Machine_Map);
        }

        // GET: Point_Machine_Map/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Point_Machine_Map/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pointname,machineid,enabled,description,minimun_order,startstop,scr")] Point_Machine_Map point_Machine_Map)
        {
            if (ModelState.IsValid)
            {
                db.Point_Machine_Map.Add(point_Machine_Map);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(point_Machine_Map);
        }

        // GET: Point_Machine_Map/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point_Machine_Map point_Machine_Map = db.Point_Machine_Map.Find(id);
            if (point_Machine_Map == null)
            {
                return HttpNotFound();
            }
            return View(point_Machine_Map);
        }

        // POST: Point_Machine_Map/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pointname,machineid,enabled,description,minimun_order,startstop,scr")] Point_Machine_Map point_Machine_Map)
        {
            if (ModelState.IsValid)
            {
                db.Entry(point_Machine_Map).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(point_Machine_Map);
        }

        // GET: Point_Machine_Map/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Point_Machine_Map point_Machine_Map = db.Point_Machine_Map.Find(id);
            if (point_Machine_Map == null)
            {
                return HttpNotFound();
            }
            return View(point_Machine_Map);
        }

        // POST: Point_Machine_Map/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Point_Machine_Map point_Machine_Map = db.Point_Machine_Map.Find(id);
            db.Point_Machine_Map.Remove(point_Machine_Map);
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
