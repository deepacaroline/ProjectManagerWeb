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
    public class TaskController : ApiController
    {
        private ProjectManagerDBEntities db = new ProjectManagerDBEntities();
        
        // GET: api/Task/GetTaskTables
        public IQueryable<TaskTable> GetTaskTables()
        {
            return db.TaskTables;
        }

        // GET: api/Task/GetTaskTable/5
        [ResponseType(typeof(TaskTable))]
        public IHttpActionResult GetTaskTable(int id)
        {
            TaskTable taskTable = db.TaskTables.Find(id);
            if (taskTable == null)
            {
                return NotFound();
            }

            return Ok(taskTable);
        }

        // PUT: api/Task/PutTaskTable/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskTable(int id, TaskTable taskTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskTable.TaskID)
            {
                return BadRequest();
            }

            db.Entry(taskTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTableExists(id))
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

        // POST: api/Task/PostTaskTable
        [ResponseType(typeof(TaskTable))]
        public IHttpActionResult PostTaskTable(TaskTable taskTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskTables.Add(taskTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TaskTableExists(taskTable.TaskID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taskTable.TaskID }, taskTable);
        }

        // DELETE: api/Task/DeleteTaskTable/5
        [ResponseType(typeof(TaskTable))]
        public IHttpActionResult DeleteTaskTable(int id)
        {
            TaskTable taskTable = db.TaskTables.Find(id);
            if (taskTable == null)
            {
                return NotFound();
            }

            db.TaskTables.Remove(taskTable);
            db.SaveChanges();

            return Ok(taskTable);
        }

        protected override void Dispose(bool disposing)
        { 
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskTableExists(int id)
        {
            return db.TaskTables.Count(e => e.TaskID == id) > 0;
        }
    }
}