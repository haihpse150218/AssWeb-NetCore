using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace eStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private Dictionary<string, string> getDefaultAdmin()
        {
            Dictionary<string, string> defaultAdmin = new Dictionary<string, string>();
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string email = config["AdminAccount:Email"];
            defaultAdmin.Add("email", email);
            string password = config["AdminAccount:Password"];
            defaultAdmin.Add("password", password);
            string role = config["AdminAccount:Role"];
            defaultAdmin.Add("role", role);
            return defaultAdmin;
        }
        public IActionResult Login()
        {
            string username = Request.Form["txtuser"];
            string password = Request.Form["txtpass"];
            Dictionary<string,string> adminaccount = getDefaultAdmin();
            string mail = adminaccount["email"];
            string pass = adminaccount["password"];
            string role = adminaccount["role"];
            Member mem = null;
            IMemberRepository memRep = new MemberRepository(Program.ConnectionString);
            var memlist = memRep.GetAllMembers();
            foreach (Member m in memlist)
            {
                if (m.Email.Equals(username) && m.Password.Equals(password))
                {
                    mem = m;
                }
            }

            if (mail.Equals(username) && pass.Equals(password))
            {
                HttpContext.Session.SetInt32("role", 1);
                HttpContext.Session.SetString("email", mail);
                return RedirectToAction("Index", "HomeAdmin");
            }
            else if (mem != null)
            {
                HttpContext.Session.SetInt32("role", 0);
                HttpContext.Session.SetInt32("id", mem.MemberId);
                HttpContext.Session.SetString("email", mem.Email);
                return RedirectToAction("Index", "HomeUser");
            }
            else
            {
                TempData["fail"] = "User or password is wrong, Try again.";
                ModelState.AddModelError("Excecution", "User or password is wrong, Try again.");
            }

            return View("Index");

        }
    }
}
