using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Product.Context;
using Product.Models;
using System.IO;

namespace Product.Controllers
{
    public class CategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public async Task<ActionResult> Index()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View(await db.Categories.ToListAsync());
        }

        public ActionResult GetCategoryWiseItems(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["id"] = id;
            List<Item> items = db.Items.Where(e => e.CategoryID == id).ToList();

            if (items == null)
            {
                return HttpNotFound();
            }

            return PartialView("CategoryWiseItems", items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Items")] Category category, HttpPostedFileBase[] Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Image != null)
                    {
                        if (category.Items.Count == Image.Count())
                        {
                            for (int i = 0; i < category.Items.Count; i++)
                            {
                                // To save a image to a folder
                                string picture = System.IO.Path.GetFileName(Image[i].FileName);
                                string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
                                Image[i].SaveAs(path);

                                // To store as byte[] in a Table of Database
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Image[i].InputStream.CopyTo(ms);
                                    category.Items[i].Image = ms.GetBuffer();
                                }
                            }
                        }
                        db.Categories.Add(category);
                        db.SaveChanges();
                        TempData["id"] = category.ID;
                        return RedirectToAction("Index");
                    }
                }
                return View(category);
            }
            catch (Exception)
            {
                return View(category);
            }
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", id);
            return PartialView(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Items")] Category category, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    for (int i = 0; i < category.Items.Count; i++)
                    {
                        if (file[i] != null)
                        {
                            // To save a image to a folder
                            string picture = System.IO.Path.GetFileName(file[i].FileName);
                            string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
                            file[i].SaveAs(path);

                            // To store as byte[] in a Table of Database
                            using (MemoryStream ms = new MemoryStream())
                            {
                                file[i].InputStream.CopyTo(ms);
                                category.Items[i].Image = ms.GetBuffer();
                            }
                        }
                    }
                }
                db.Entry(category).State = EntityState.Modified;
                foreach(Item item in category.Items)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                TempData["id"] = category.ID;
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
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
