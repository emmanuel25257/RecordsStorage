using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public ItemController(ApplicationDbContext db)
        {
            _Db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objlist = _Db.Items;
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
        public IActionResult Create(Item obj)
        {
            _Db.Items.Add(obj);
            _Db.SaveChanges();
          return RedirectToAction("Index");
        }
    }
}
