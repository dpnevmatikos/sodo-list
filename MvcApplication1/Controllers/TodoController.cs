﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.DAL;

namespace MvcApplication1.Controllers
{
    public class TodoController : Controller
    {
        private TodoContext db = new TodoContext();

        //
        // GET: /Todo/
        [Authorize]
        public ActionResult Index()
        {
            string s = User.Identity.Name;
            var list = db.Todos.Where(t => t.username == User.Identity.Name).ToList();
            
            //return View(db.Todos.ToList());
            return View(list);
        }

        //
        // GET: /Todo/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        //
        // GET: /Todo/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Todo/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                todo.username = User.Identity.Name;
                db.Todos.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        //
        // GET: /Todo/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (todo.username != User.Identity.Name)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(todo);
        }

        //
        // POST: /Todo/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Todo todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        //
        // GET: /Todo/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        //
        // POST: /Todo/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.Todos.Find(id);
            db.Todos.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}