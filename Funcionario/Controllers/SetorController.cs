using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Funcionario.Models;

namespace Funcionario.Controllers
{
    public class SetorController : Controller
    {
        private FuncionariosEntities db = new FuncionariosEntities();

        // GET: Setor
        public ActionResult Index()
        {
            return View(db.tlbSetor.ToList());
        }

        // GET: Setor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbSetor tlbSetor = db.tlbSetor.Find(id);
            if (tlbSetor == null)
            {
                return HttpNotFound();
            }
            return View(tlbSetor);
        }

        // GET: Setor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_setor,nome")] tlbSetor tlbSetor)
        {
            if (ModelState.IsValid)
            {
                db.tlbSetor.Add(tlbSetor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbSetor);
        }

        // GET: Setor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbSetor tlbSetor = db.tlbSetor.Find(id);
            if (tlbSetor == null)
            {
                return HttpNotFound();
            }
            return View(tlbSetor);
        }

        // POST: Setor/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_setor,nome")] tlbSetor tlbSetor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbSetor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbSetor);
        }

        // GET: Setor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbSetor tlbSetor = db.tlbSetor.Find(id);
            if (tlbSetor == null)
            {
                return HttpNotFound();
            }
            return View(tlbSetor);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tlbSetor tlbSetor = db.tlbSetor.Find(id);
            db.tlbSetor.Remove(tlbSetor);
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
