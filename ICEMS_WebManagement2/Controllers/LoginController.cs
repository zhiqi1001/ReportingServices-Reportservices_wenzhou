using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICEMS_WebManagement2.Controllers
{
    public class Psd
    {
        public string psd { get; set; }
    }

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include="psd")] Psd p)
        {
            if (ModelState.IsValid)
            {
                if (p.psd == "999999")
                {
                    Session["ID"] = "1";
                    return RedirectToAction("Index", "MachineCemsInfoes");
                }
                else
                {
                    ViewBag.Msg = "Incorrect Password";
                    return View();
                }
            }
            return View();
        }
    }
}