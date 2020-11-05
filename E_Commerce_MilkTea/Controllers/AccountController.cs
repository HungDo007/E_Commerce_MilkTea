using E_Commerce_MilkTea.Common;
using E_Commerce_MilkTea.Models;
using milkTeaModelsss;
using milkTeaModelsss.frameWork;
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
        [ValidateAntiForgeryToken]
        public ActionResult Index(login login)
        {
            bool res = new accountModel().login(login.username, Encryptor.MD5Hash(login.pass));
            if (ModelState.IsValid && res)
            {
                FormsAuthentication.SetAuthCookie(login.username, login.rememberMe);
                ViewBag.username = login.username;
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
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(register register)
        {
            if (register.pass != register.repass || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "Mật khẩu không trùng khớp! Vui lòng kiểm tra lại.");
                return View(register);
            }
            User_Accounts accounts = new User_Accounts()
            {
                Username = register.username,
                Password = Encryptor.MD5Hash(register.pass),
                FirstName = register.firstname,
                LastName = register.lastname,
                PhoneNumber = register.phone,
                Email = register.email,
                Address = register.address
            };
            if (new accountModel().register(accounts))
            return View("index");
            else
            {
                ModelState.AddModelError("", "lam lai");
                return View(register);
            }
        }
        [HttpGet]
        public ActionResult ForgotPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPass(string username, string email)
        {
            return View();
        }
    }
}