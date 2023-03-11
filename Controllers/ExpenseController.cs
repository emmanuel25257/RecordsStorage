using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public ExpenseController(ApplicationDbContext db)
        {
            _Db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objlist = _Db.Expenses;
            return View(objlist);

            
        }
        //GET Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _Db.Expenses.Add(obj);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _Db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _Db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
          
            _Db.Expenses.Remove(obj);
            _Db.SaveChanges();
             return RedirectToAction("Index");            
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _Db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _Db.Expenses.Update(obj);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
