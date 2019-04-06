using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCparcial.Models;

namespace MVCparcial.Controllers
{
    public class PepitaCarrilloFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: PepitaCarrilloFriends
        public ActionResult Index()
        {
            return View(db.PepitaCarrilloFriends.ToList());
        }

        // GET: PepitaCarrilloFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PepitaCarrilloFriend pepitaCarrilloFriend = db.PepitaCarrilloFriends.Find(id);
            if (pepitaCarrilloFriend == null)
            {
                return HttpNotFound();
            }
            return View(pepitaCarrilloFriend);
        }

        // GET: PepitaCarrilloFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PepitaCarrilloFriends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,NombreCompleto,Apodo,Cumpleanos,TipoAmigo,Status")] PepitaCarrilloFriend pepitaCarrilloFriend)
        {
            if (ModelState.IsValid)
            {
                db.PepitaCarrilloFriends.Add(pepitaCarrilloFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pepitaCarrilloFriend);
        }

        // GET: PepitaCarrilloFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PepitaCarrilloFriend pepitaCarrilloFriend = db.PepitaCarrilloFriends.Find(id);
            if (pepitaCarrilloFriend == null)
            {
                return HttpNotFound();
            }
            return View(pepitaCarrilloFriend);
        }

        // POST: PepitaCarrilloFriends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,NombreCompleto,Apodo,Cumpleanos,TipoAmigo,Status")] PepitaCarrilloFriend pepitaCarrilloFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pepitaCarrilloFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pepitaCarrilloFriend);
        }

        // GET: PepitaCarrilloFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PepitaCarrilloFriend pepitaCarrilloFriend = db.PepitaCarrilloFriends.Find(id);
            if (pepitaCarrilloFriend == null)
            {
                return HttpNotFound();
            }
            return View(pepitaCarrilloFriend);
        }

        // POST: PepitaCarrilloFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PepitaCarrilloFriend pepitaCarrilloFriend = db.PepitaCarrilloFriends.Find(id);
            db.PepitaCarrilloFriends.Remove(pepitaCarrilloFriend);
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
