using System;
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
using REST.Models_log;

namespace REST.Controllers
{
    public class FacilitiesLogController : ApiController
    {
        private LogDataContext db = new LogDataContext();

        // GET: api/FacilitiesLog
        public IQueryable<Facilities_log> GetFacilities_log()
        {
            return db.Facilities_log;
        }

        // GET: api/FacilitiesLog/5
        [ResponseType(typeof(Facilities_log))]
        public async Task<IHttpActionResult> GetFacilities_log(int id)
        {
            Facilities_log facilities_log = await db.Facilities_log.FindAsync(id);
            if (facilities_log == null)
            {
                return NotFound();
            }

            return Ok(facilities_log);
        }

        // PUT: api/FacilitiesLog/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFacilities_log(int id, Facilities_log facilities_log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facilities_log.PKEY)
            {
                return BadRequest();
            }

            db.Entry(facilities_log).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Facilities_logExists(id))
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

        // POST: api/FacilitiesLog
        [ResponseType(typeof(Facilities_log))]
        public async Task<IHttpActionResult> PostFacilities_log(Facilities_log facilities_log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facilities_log.Add(facilities_log);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Facilities_logExists(facilities_log.PKEY))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = facilities_log.PKEY }, facilities_log);
        }

        // DELETE: api/FacilitiesLog/5
        [ResponseType(typeof(Facilities_log))]
        public async Task<IHttpActionResult> DeleteFacilities_log(int id)
        {
            Facilities_log facilities_log = await db.Facilities_log.FindAsync(id);
            if (facilities_log == null)
            {
                return NotFound();
            }

            db.Facilities_log.Remove(facilities_log);
            await db.SaveChangesAsync();

            return Ok(facilities_log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Facilities_logExists(int id)
        {
            return db.Facilities_log.Count(e => e.PKEY == id) > 0;
        }
    }
}