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
using FineEx.DataLayer.Context;
using FineEx.DataLayer.Models;

namespace FineExApi.Controllers
{
    public class InvoicesController : ApiController
    {
        private DbFineEx db = new DbFineEx();

        // GET: api/Invoices
        public IQueryable<Invoice> GetInvoices()
        {
            return db.Invoices;
        }

        // GET: api/Invoices/5
        [ResponseType(typeof(Invoice))]
        public List<Invoice> GetInvoicesForCompany(int id)
        {
            List<Invoice> invoices = new List<Invoice>();
            invoices.AddRange(db.Invoices.Where(i => i.SenderId == id).ToList());
            invoices.AddRange(db.Invoices.Where(i => i.ReceiverId == id).ToList());
            if (invoices == null || invoices.Count == 0)
            {
                return null;
            }

            return invoices;
        }

        // GET: api/Invoices/5
        //[ResponseType(typeof(Invoice))]
        //public async Task<IHttpActionResult> GetInvoice(int id)
        //{
        //    Invoice invoice = await db.Invoices.FindAsync(id);
        //    if (invoice == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(invoice);
        //}

        // PUT: api/Invoices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoice.Id)
            {
                return BadRequest();
            }

            db.Entry(invoice).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        [ResponseType(typeof(Invoice))]
        public async Task<IHttpActionResult> PostInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Invoices.Add(invoice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = invoice.Id }, invoice);
        }

        // DELETE: api/Invoices/5
        [ResponseType(typeof(Invoice))]
        public async Task<IHttpActionResult> DeleteInvoice(int id)
        {
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            db.Invoices.Remove(invoice);
            await db.SaveChangesAsync();

            return Ok(invoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoiceExists(int id)
        {
            return db.Invoices.Count(e => e.Id == id) > 0;
        }
    }
}