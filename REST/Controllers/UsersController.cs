﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using REST.Models;

namespace REST.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }
        // GET: api/Users/adri1685/test
        [Route("{username}/{password}")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(string username,string password)
        {
            User user = await (from usr in db.Users where (usr.Username == username) select usr).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            else if(user.Password!=password)
            {
                return BadRequest("wrong-password");
            }

            return Ok(user);
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("{username}/{oldpassword}/{newpassword}")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> ChangePassword(string username,string oldpassword,string newpassword)
        {
            User user = await (from usr in db.Users where usr.Username == username select usr).FirstOrDefaultAsync();
            if (user == null)
                return NotFound();
            else if (user.Password != oldpassword)
                return BadRequest("wrong-password");
                user.Password = newpassword;
            try
            {
                await db.SaveChangesAsync();
                return Ok(user);
            }
            catch (DbUpdateException)
            {
                return BadRequest("error");
            }
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}