using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
namespace eStore.Controllers
{
    public class MemberController : Controller
    {
        // GET: MemberController
        public ActionResult Index()
        {
            IMemberRepository memRep = new MemberRepository(Program.ConnectionString);
            var memList = memRep.GetAllMembers();
            return View(memList);
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int? id)
        {
            IMemberRepository memRep = new MemberRepository(Program.ConnectionString);
            if (id == null)
            {
                return NotFound();
            }

            var mem = memRep.GetMemberByID(id.Value);
            if (mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }

        // GET: MemberController/Create
        public ActionResult Create() => View();

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
                 [Bind("MemberId, Email, CompanyName, City, Country, Password")] Member mem)
        {
            IMemberRepository memRep = new MemberRepository(Program.ConnectionString);
            try
            {
                if (ModelState.IsValid)
                {
                    var MemID = memRep.GetMemberByID(mem.MemberId);
                    var MemMail = memRep.GetMemberByEmail(mem.Email);
                    if (MemID != null)
                    {
                        TempData["error"] = "ID already exists";
                        return View("Create");
                    }
                    else if (MemMail != null)
                    {
                        TempData["error"] = "Email already exists";
                        return View("Create");
                    }

                    memRep.InsertMember(mem);
                }
                TempData["complete"] = "Completed";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(mem);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int? id)
        {
            IMemberRepository memRep = new MemberRepository(Program.ConnectionString);
            if (id == null)
            {
                return NotFound();
            }
            var mem = memRep.GetMemberByID(id.Value);
            if (mem == null)
            {
                return NotFound();
            }

            return View(mem);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member mem)
        {
            try
            {
                IMemberRepository memRep = new MemberRepository(Program.ConnectionString);
                if (id != mem.MemberId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    memRep.UpdateMember(mem);
                }

                TempData["complete"] = "Completed";

                if (HttpContext.Session.GetInt32("role") == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Details", "Member", new { id = HttpContext.Session.GetInt32("id") });
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IMemberRepository memRep = new MemberRepository(Program.ConnectionString);

            var mem = memRep.GetMemberByID(id.Value);
            if (mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }
        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                IMemberRepository memRep = new MemberRepository(Program.ConnectionString);
                memRep.DeleteMember(id);
                TempData["complete"] = "Completed";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
