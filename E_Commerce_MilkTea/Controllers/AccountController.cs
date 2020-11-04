using E_Commerce_MilkTea.Models;
using milkTeaModelsss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Commerce_MilkTea.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Index(login login)
        {
            bool res = new accountModel().login(login.username, login.pass);
            if (ModelState.IsValid && res)
            {
                FormsAuthentication.SetAuthCookie(login.username, login.rememberMe);
                return RedirectToAction("index", "home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng kiểm tra lại!");
            }
            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }
    }
}