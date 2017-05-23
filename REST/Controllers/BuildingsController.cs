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
using REST;
using REST.Models;

namespace REST.Controllers
{
    public class BuildingsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Buildings
        public IQueryable<Building> GetBuildings()
        {
            return db.Buildings;
        }

        // GET: api/Buildings/5
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> GetBuilding(int id)
        {
            Building building = await db.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // PUT: api/Buildings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBuilding(int id, Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != building.B_No)
            {
                return BadRequest();
            }

            db.Entry(building).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
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

        // POST: api/Buildings
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> PostBuilding(Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buildings.Add(building);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BuildingExists(building.B_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = building.B_No }, building);
        }

        // DELETE: api/Buildings/5
        [ResponseType(typeof(Building))]
        public async Task<IHttpActionResult> DeleteBuilding(int id)
        {
            Building building = await db.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            db.Buildings.Remove(building);
            await db.SaveChangesAsync();

            return Ok(building);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuildingExists(int id)
        {
            return db.Buildings.Count(e => e.B_No == id) > 0;
        }
    }
}