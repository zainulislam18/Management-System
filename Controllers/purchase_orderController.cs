using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Management_System.Models;

namespace Management_System.Controllers
{
    public class purchase_orderController : Controller
    {
        private Management_SystemEntities3 db = new Management_SystemEntities3();

        // GET: purchase_order
        public ActionResult Index(String searchCompany,int SearchPO=0)
        {
            var purchase_order = db.purchase_order.Include(p => p.Tax);
            if(searchCompany != null && searchCompany != "")
                return View(purchase_order.Where(x => x.company_name.Contains(searchCompany)).ToList());
            if(SearchPO !=0)
            {
                return View(purchase_order.Where(x => x.po_id.Equals(SearchPO)).ToList());
            }
            return View(purchase_order.ToList());

        }

        // GET: purchase_order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase_order purchase_order = db.purchase_order.Find(id);
            if (purchase_order == null)
            {
                return HttpNotFound();
            }
            return View(purchase_order);
        }

        // GET: purchase_order/Create
        public ActionResult Create()
        {
            ViewBag.tax_id = new SelectList(db.Taxes, "tax_id", "tax_id");
            return View();
        }

        // POST: purchase_order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "po_id,company_name,delivery_dat,po_date,tax_id")] purchase_order purchase_order)
        {
            if (ModelState.IsValid)
            {
                db.purchase_order.Add(purchase_order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tax_id = new SelectList(db.Taxes, "tax_id", "tax_id", purchase_order.tax_id);
            return View(purchase_order);
        }

        // GET: purchase_order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase_order purchase_order = db.purchase_order.Find(id);
            if (purchase_order == null)
            {
                return HttpNotFound();
            }
            ViewBag.tax_id = new SelectList(db.Taxes, "tax_id", "tax_id", purchase_order.tax_id);
            return View(purchase_order);
        }

        // POST: purchase_order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "po_id,company_name,delivery_dat,po_date,tax_id")] purchase_order purchase_order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tax_id = new SelectList(db.Taxes, "tax_id", "tax_id", purchase_order.tax_id);
            return View(purchase_order);
        }

        // GET: purchase_order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchase_order purchase_order = db.purchase_order.Find(id);
            if (purchase_order == null)
            {
                return HttpNotFound();
            }
            return View(purchase_order);
        }

        // POST: purchase_order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            purchase_order purchase_order = db.purchase_order.Find(id);
            db.purchase_order.Remove(purchase_order);
            db.SaveChanges();
            return RedirectToAction("Index");
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
