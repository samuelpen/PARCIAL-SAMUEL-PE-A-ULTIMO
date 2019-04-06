using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIparcial.Models;

namespace APIparcial.Controllers
{
    public class PepitaCarrilloFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PepitaCarrilloFriends
        public IQueryable<PepitaCarrilloFriend> GetPepitaCarrilloFriends()
        {
            return db.PepitaCarrilloFriends;
        }

        // GET: api/PepitaCarrilloFriends/5
        [ResponseType(typeof(PepitaCarrilloFriend))]
        public IHttpActionResult GetPepitaCarrilloFriend(int id)
        {
            PepitaCarrilloFriend pepitaCarrilloFriend = db.PepitaCarrilloFriends.Find(id);
            if (pepitaCarrilloFriend == null)
            {
                return NotFound();
            }

            return Ok(pepitaCarrilloFriend);
        }

        // PUT: api/PepitaCarrilloFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPepitaCarrilloFriend(int id, PepitaCarrilloFriend pepitaCarrilloFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pepitaCarrilloFriend.FriendId)
            {
                return BadRequest();
            }

            db.Entry(pepitaCarrilloFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PepitaCarrilloFriendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PepitaCarrilloFriends
        [ResponseType(typeof(PepitaCarrilloFriend))]
        public IHttpActionResult PostPepitaCarrilloFriend(PepitaCarrilloFriend pepitaCarrilloFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PepitaCarrilloFriends.Add(pepitaCarrilloFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pepitaCarrilloFriend.FriendId }, pepitaCarrilloFriend);
        }

        // DELETE: api/PepitaCarrilloFriends/5
        [ResponseType(typeof(PepitaCarrilloFriend))]
        public IHttpActionResult DeletePepitaCarrilloFriend(int id)
        {
            PepitaCarrilloFriend pepitaCarrilloFriend = db.PepitaCarrilloFriends.Find(id);
            if (pepitaCarrilloFriend == null)
            {
                return NotFound();
            }

            db.PepitaCarrilloFriends.Remove(pepitaCarrilloFriend);
            db.SaveChanges();

            return Ok(pepitaCarrilloFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PepitaCarrilloFriendExists(int id)
        {
            return db.PepitaCarrilloFriends.Count(e => e.FriendId == id) > 0;
        }
    }
}