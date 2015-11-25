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
    public class MachineShiftSecsController : Controller
    {
        private iCEMSDBEntities db = new iCEMSDBEntities();

        // GET: MachineShiftSecs
        public ActionResult Index()
        {
            return View(db.MachineShiftSecs.ToList());
        }

        // GET: MachineShiftSecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineShiftSecs machineShiftSecs = db.MachineShiftSecs.Find(id);
            if (machineShiftSecs == null)
            {
                return HttpNotFound();
            }
            return View(machineShiftSecs);
        }

        // GET: MachineShiftSecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MachineShiftSecs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,machineid,shiftsecs")] MachineShiftSecs machineShiftSecs)
        {
            if (ModelState.IsValid)
            {
                db.MachineShiftSecs.Add(machineShiftSecs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machineShiftSecs);
        }

        // GET: MachineShiftSecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineShiftSecs machineShiftSecs = db.MachineShiftSecs.Find(id);
            if (machineShiftSecs == null)
            {
                return HttpNotFound();
            }
            return View(machineShiftSecs);
        }

        // POST: MachineShiftSecs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,machineid,shiftsecs")] MachineShiftSecs machineShiftSecs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machineShiftSecs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machineShiftSecs);
        }

        // GET: MachineShiftSecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineShiftSecs machineShiftSecs = db.MachineShiftSecs.Find(id);
            if (machineShiftSecs == null)
            {
                return HttpNotFound();
            }
            return View(machineShiftSecs);
        }

        // POST: MachineShiftSecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MachineShiftSecs machineShiftSecs = db.MachineShiftSecs.Find(id);
            db.MachineShiftSecs.Remove(machineShiftSecs);
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
