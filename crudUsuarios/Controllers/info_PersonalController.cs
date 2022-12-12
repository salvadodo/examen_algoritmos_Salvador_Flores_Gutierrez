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
using crudUsuarios.Models;

namespace crudUsuarios.Controllers
{
    public class info_PersonalController : ApiController
    {
        private ModelsContext db = new ModelsContext();

        // GET: api/info_Personal
        public IQueryable<info_Personal> Getinfo_Personal()
        {
            return db.info_Personal;
        }

        // GET: api/info_Personal/5
        [ResponseType(typeof(info_Personal))]
        public IHttpActionResult Getinfo_Personal(int id)
        {
            info_Personal info_Personal = db.info_Personal.Find(id);
            if (info_Personal == null)
            {
                return NotFound();
            }

            return Ok(info_Personal);
        }

        // PUT: api/info_Personal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinfo_Personal(int id, info_Personal info_Personal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != info_Personal.id)
            {
                return BadRequest();
            }

            db.Entry(info_Personal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!info_PersonalExists(id))
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

        // POST: api/info_Personal
        [ResponseType(typeof(info_Personal))]
        public IHttpActionResult Postinfo_Personal(info_Personal info_Personal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.info_Personal.Add(info_Personal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (info_PersonalExists(info_Personal.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = info_Personal.id }, info_Personal);
        }

        // DELETE: api/info_Personal/5
        [ResponseType(typeof(info_Personal))]
        public IHttpActionResult Deleteinfo_Personal(int id)
        {
            info_Personal info_Personal = db.info_Personal.Find(id);
            if (info_Personal == null)
            {
                return NotFound();
            }

            db.info_Personal.Remove(info_Personal);
            db.SaveChanges();

            return Ok(info_Personal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool info_PersonalExists(int id)
        {
            return db.info_Personal.Count(e => e.id == id) > 0;
        }
    }
}