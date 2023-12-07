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
    public class FuncionarioController : Controller
    {
        private FuncionariosEntities db = new FuncionariosEntities();

        // GET: Funcionario
        public ActionResult Index()
        {
            var tblFuncionario = db.tblFuncionario.Include(t => t.tlbSetor);
            return View(tblFuncionario.ToList());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            if (tblFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tblFuncionario);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            ViewBag.Id_setor = new SelectList(db.tlbSetor, "Id_setor", "nome");
            return View();
        }

        // POST: Funcionario/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_funcionario,Id_setor,nome,cargo")] tblFuncionario tblFuncionario)
        {
            if (ModelState.IsValid)
            {
                db.tblFuncionario.Add(tblFuncionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_setor = new SelectList(db.tlbSetor, "Id_setor", "nome", tblFuncionario.Id_setor);
            return View(tblFuncionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            if (tblFuncionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_setor = new SelectList(db.tlbSetor, "Id_setor", "nome", tblFuncionario.Id_setor);
            return View(tblFuncionario);
        }

        // POST: Funcionario/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_funcionario,Id_setor,nome,cargo")] tblFuncionario tblFuncionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFuncionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_setor = new SelectList(db.tlbSetor, "Id_setor", "nome", tblFuncionario.Id_setor);
            return View(tblFuncionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            if (tblFuncionario == null)
            {
                return HttpNotFound();
            }
            return View(tblFuncionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFuncionario tblFuncionario = db.tblFuncionario.Find(id);
            db.tblFuncionario.Remove(tblFuncionario);
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
