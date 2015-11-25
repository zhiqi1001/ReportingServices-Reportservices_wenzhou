using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ICEMS_WebManagement
{
    public class MachineCemsInfoesController : Controller
    {
        private iCEMSDBEntities db = new iCEMSDBEntities();

        // GET: MachineCemsInfoes
        public ActionResult Index()
        {
            return View(db.MachineCemsInfo.ToList());
        }

        // GET: MachineCemsInfoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineCemsInfo machineCemsInfo = db.MachineCemsInfo.Find(id);
            if (machineCemsInfo == null)
            {
                return HttpNotFound();
            }
            return View(machineCemsInfo);
        }

        // GET: MachineCemsInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MachineCemsInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,machineid,machinename,plantid,globalmachineid,cemstime,importedtime,updatetime,designedload")] MachineCemsInfo machineCemsInfo)
        {
            if (ModelState.IsValid)
            {
                db.MachineCemsInfo.Add(machineCemsInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machineCemsInfo);
        }

        // GET: MachineCemsInfoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineCemsInfo machineCemsInfo = db.MachineCemsInfo.Find(id);
            if (machineCemsInfo == null)
            {
                return HttpNotFound();
            }
            return View(machineCemsInfo);
        }

        // POST: MachineCemsInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,machineid,machinename,plantid,globalmachineid,cemstime,importedtime,updatetime,designedload")] MachineCemsInfo machineCemsInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machineCemsInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machineCemsInfo);
        }

        // GET: MachineCemsInfoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineCemsInfo machineCemsInfo = db.MachineCemsInfo.Find(id);
            if (machineCemsInfo == null)
            {
                return HttpNotFound();
            }
            return View(machineCemsInfo);
        }

        // POST: MachineCemsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MachineCemsInfo machineCemsInfo = db.MachineCemsInfo.Find(id);
            db.MachineCemsInfo.Remove(machineCemsInfo);
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
