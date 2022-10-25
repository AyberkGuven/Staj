using Staj.Context;
using Staj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Staj.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var db = new BizimDbContext())
            {
                var data = db.Users.FirstOrDefault(x => x.userName == user.userName && x.Password == user.Password);

                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(user.userName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mesaj = "Geçersiz Kullanıcı. Kullanıcı Adı veya Şifre Hatalı";
                    return View();
                }
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}