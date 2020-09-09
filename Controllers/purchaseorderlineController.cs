using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Management_System.Models;

namespace Management_System.Controllers
{
    public class purchaseorderlineController : Controller
    {
        private Management_SystemEntities3 db = new Management_SystemEntities3();

        // GET: purchaseorderline
        public ActionResult Index(int? id)
        {
            var purchase_order_line = db.purchase_order_line.Include(p => p.purchase_order);
            purchase_order_line = from Pl in purchase_order_line  where Pl.po_id == id select Pl;
            return View(purchase_order_line.ToList());
        }

        // GET: purchaseorderline/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase_order_line purchase_order_line = db.purchase_order_line.Find(id);
            if (purchase_order_line == null)
            {
                return HttpNotFound();
            }
            return View(purchase_order_line);
        }

        // GET: purchaseorderline/Create
        public ActionResult Create()
        {
            ViewBag.po_id = new SelectList(db.purchase_order, "po_id", "po_id");
            return View();
        }

        // POST: purchaseorderline/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pol_id,Line_No,Paper_quality,Quantity,Number_of_ply,Height,Width,length,Rate,Amount,po_id")] purchase_order_line purchase_order_line)
        {
            if (ModelState.IsValid)
            {
                int? id = purchase_order_line.po_id;
                db.purchase_order_line.Add(purchase_order_line);
                db.SaveChanges();
                return RedirectToAction("In" +
                    "dex",new { id = id });
            }

            ViewBag.po_id = new SelectList(db.purchase_order, "po_id", "po_id", purchase_order_line.po_id);
            return View(purchase_order_line);
        }

        // GET: purchaseorderline/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase_order_line purchase_order_line = db.purchase_order_line.Find(id);
            if (purchase_order_line == null)
            {
                return HttpNotFound();
            }
            ViewBag.po_id = new SelectList(db.purchase_order, "po_id", "po_id", purchase_order_line.po_id);
            return View(purchase_order_line);
        }

        // POST: purchaseorderline/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pol_id,Line_No,Paper_quality,Quantity,Number_of_ply,Height,Width,length,Rate,Amount,po_id")] purchase_order_line purchase_order_line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_order_line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = purchase_order_line.po_id });
            }
            ViewBag.po_id = new SelectList(db.purchase_order, "po_id", "company_name", purchase_order_line.po_id);
            return View(purchase_order_line);
        }

        // GET: purchaseorderline/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase_order_line purchase_order_line = db.purchase_order_line.Find(id);
            if (purchase_order_line == null)
            {
                return HttpNotFound();
            }
            return View(purchase_order_line);
        }

        // POST: purchaseorderline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            purchase_order_line purchase_order_line = db.purchase_order_line.Find(id);
            db.purchase_order_line.Remove(purchase_order_line);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = purchase_order_line.po_id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
