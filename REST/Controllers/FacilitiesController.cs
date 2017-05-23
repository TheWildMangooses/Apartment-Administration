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
using REST.Models;

namespace REST.Controllers
{
    public class FacilitiesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Facilities
        public IQueryable<Facility> GetFacilities()
        {
            return db.Facilities;
        }

        // GET: api/Facilities/5
        [ResponseType(typeof(Facility))]
        public async Task<IHttpActionResult> GetFacility(int id)
        {
            Facility facility = await db.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }

            return Ok(facility);
        }

        // PUT: api/Facilities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFacility(int id, Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facility.Id)
            {
                return BadRequest();
            }

            db.Entry(facility).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(id))
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

        // POST: api/Facilities
        [ResponseType(typeof(Facility))]
        public async Task<IHttpActionResult> PostFacility(Facility facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facilities.Add(facility);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacilityExists(facility.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = facility.Id }, facility);
        }

        // DELETE: api/Facilities/5
        [ResponseType(typeof(Facility))]
        public async Task<IHttpActionResult> DeleteFacility(int id)
        {
            Facility facility = await db.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }

            db.Facilities.Remove(facility);
            await db.SaveChangesAsync();

            return Ok(facility);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacilityExists(int id)
        {
            return db.Facilities.Count(e => e.Id == id) > 0;
        }
    }
}