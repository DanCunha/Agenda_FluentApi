using EntityFrameworkCtis.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkCtis.Controllers
{
    public class ContatoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Contato
        public ActionResult Index()
        {
            List<Contato> contatos = db.Contato.Include("Enderecos").ToList();

            //foreach(var lista in contatos)
            //{

            //}

            return View(contatos);
        }

        // GET: Contato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        public ActionResult Create(Contato contato)
        {
            try
            {
                db.Contato.Add(contato);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View();
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            Contato contato = db.Contato.Include("Enderecos").Where(x => x.ContatoId == id).FirstOrDefault();
            return View(contato);
        }

        // POST: Contato/Edit/5
        [HttpPost]
        public ActionResult Edit(Contato model)
        {
            try
            {
                Contato contato = db.Contato.Find(model.ContatoId);
                contato.Nome = model.Nome;
                contato.Telefone = model.Telefone;
                contato.email = model.email;
                contato.DataNascimento = model.DataNascimento;

                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Edit", model.ContatoId);
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View();
            }
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
