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
using SPAApplication.Models;

namespace SPAApplication.Controllers
{
    public class DepartmentsController : ApiController
    {
        private SPAContext db = new SPAContext();

        // GET: api/Departments
        public IQueryable<Department> GetDepartaments()
        {
            return db.Departaments;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartament(int id)
        {
            Department departament = db.Departaments.Find(id);
            if (departament == null)
            {
                return NotFound();
            }

            return Ok(departament);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartament(int id, Department departament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departament.Id)
            {
                return BadRequest();
            }

            db.Entry(departament).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentExists(id))
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

        // POST: api/Departments
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartament(Department departament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departaments.Add(departament);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departament.Id }, departament);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartament(int id)
        {
            Department departament = db.Departaments.Find(id);
            if (departament == null)
            {
                return NotFound();
            }

            db.Departaments.Remove(departament);
            db.SaveChanges();

            return Ok(departament);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartamentExists(int id)
        {
            return db.Departaments.Count(e => e.Id == id) > 0;
        }
    }
}