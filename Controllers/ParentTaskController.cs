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
using ProjectManagerWeb;

namespace ProjectManagerWeb.Controllers
{
    public class ParentTaskController : ApiController
    {
        private ProjectManagerDBEntities db = new ProjectManagerDBEntities();

        // GET: api/ParentTask/GetParentTaskTables
        public IQueryable<ParentTaskTable> GetParentTaskTables()
        {
            return db.ParentTaskTables;
        }

        // GET: api/ParentTask/GetParentTaskTable/5
        [ResponseType(typeof(ParentTaskTable))]
        public IHttpActionResult GetParentTaskTable(int id)
        {
            ParentTaskTable parentTaskTable = db.ParentTaskTables.Find(id);
            if (parentTaskTable == null)
            {
                return NotFound();
            }

            return Ok(parentTaskTable);
        }

        // PUT: api/ParentTask/PutParentTaskTable/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParentTaskTable(int id, ParentTaskTable parentTaskTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parentTaskTable.ParentTaskID)
            {
                return BadRequest();
            }

            db.Entry(parentTaskTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentTaskTableExists(id))
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

        // POST: api/ParentTask/PostParentTaskTable
        [ResponseType(typeof(ParentTaskTable))]
        public IHttpActionResult PostParentTaskTable(ParentTaskTable parentTaskTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParentTaskTables.Add(parentTaskTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ParentTaskTableExists(parentTaskTable.ParentTaskID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = parentTaskTable.ParentTaskID }, parentTaskTable);
        }

        // DELETE: api/ParentTask/DeleteParentTaskTable/5
        [ResponseType(typeof(ParentTaskTable))]
        public IHttpActionResult DeleteParentTaskTable(int id)
        {
            ParentTaskTable parentTaskTable = db.ParentTaskTables.Find(id);
            if (parentTaskTable == null)
            {
                return NotFound();
            }

            db.ParentTaskTables.Remove(parentTaskTable);
            db.SaveChanges();

            return Ok(parentTaskTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParentTaskTableExists(int id)
        {
            return db.ParentTaskTables.Count(e => e.ParentTaskID == id) > 0;
        }
    }
}