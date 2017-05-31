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
    public class ApartmentsLogController : ApiController
    {
        
        private LogDataContext db = new LogDataContext();

        // GET: api/ApartmentsLog
        public IQueryable<Apartments_log> GetApartments_log()
        {
            return db.Apartments_log;
        }

        // GET: api/ApartmentsLog/5
        [ResponseType(typeof(Apartments_log))]
        public async Task<IHttpActionResult> GetApartments_log(int id)
        {
            Apartments_log apartments_log = await db.Apartments_log.FindAsync(id);
            if (apartments_log == null)
            {
                return NotFound();
            }

            return Ok(apartments_log);
        }

        // PUT: api/ApartmentsLog/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApartments_log(int id, Apartments_log apartments_log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartments_log.PKEY)
            {
                return BadRequest();
            }

            db.Entry(apartments_log).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Apartments_logExists(id))
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

        // POST: api/ApartmentsLog
        [ResponseType(typeof(Apartments_log))]
        public async Task<IHttpActionResult> PostApartments_log(Apartments_log apartments_log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apartments_log.Add(apartments_log);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Apartments_logExists(apartments_log.PKEY))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = apartments_log.PKEY }, apartments_log);
        }

        // DELETE: api/ApartmentsLog/5
        [ResponseType(typeof(Apartments_log))]
        public async Task<IHttpActionResult> DeleteApartments_log(int id)
        {
            Apartments_log apartments_log = await db.Apartments_log.FindAsync(id);
            if (apartments_log == null)
            {
                return NotFound();
            }

            db.Apartments_log.Remove(apartments_log);
            await db.SaveChangesAsync();

            return Ok(apartments_log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Apartments_logExists(int id)
        {
            return db.Apartments_log.Count(e => e.PKEY == id) > 0;
        }
    }
}