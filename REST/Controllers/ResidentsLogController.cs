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
    public class ResidentsLogController : ApiController
    {
        private LogDataContext db = new LogDataContext();

        // GET: api/ResidentsLog
        public IQueryable<Residents_log> GetResidents_log()
        {
            return db.Residents_log;
        }

        // GET: api/ResidentsLog/5
        [ResponseType(typeof(Residents_log))]
        public async Task<IHttpActionResult> GetResidents_log(int id)
        {
            Residents_log residents_log = await db.Residents_log.FindAsync(id);
            if (residents_log == null)
            {
                return NotFound();
            }

            return Ok(residents_log);
        }

        // PUT: api/ResidentsLog/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResidents_log(int id, Residents_log residents_log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residents_log.PKEY)
            {
                return BadRequest();
            }

            db.Entry(residents_log).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Residents_logExists(id))
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

        // POST: api/ResidentsLog
        [ResponseType(typeof(Residents_log))]
        public async Task<IHttpActionResult> PostResidents_log(Residents_log residents_log)
        {
            residents_log.PKEY = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residents_log.Add(residents_log);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Residents_logExists(residents_log.PKEY))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = residents_log.PKEY }, residents_log);
        }

        // DELETE: api/ResidentsLog/5
        [ResponseType(typeof(Residents_log))]
        public async Task<IHttpActionResult> DeleteResidents_log(int id)
        {
            Residents_log residents_log = await db.Residents_log.FindAsync(id);
            if (residents_log == null)
            {
                return NotFound();
            }

            db.Residents_log.Remove(residents_log);
            await db.SaveChangesAsync();

            return Ok(residents_log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Residents_logExists(int id)
        {
            return db.Residents_log.Count(e => e.PKEY == id) > 0;
        }
    }
}