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
            if (contato.DataNascimento.ToString() == "01/01/0001 00:00:00")
            {
                this.ModelState.AddModelError("DataNascimento", "Data Inválida");
                return View(contato);
            }

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
                return View(contato);
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            Contato contato = db.Contato.Include("Enderecos").Where(x => x.ContatoId == id).FirstOrDefault();

            ViewBag.ContatoId = contato.ContatoId;
            ViewBag.Enderecos = contato.Enderecos;

            return View(contato);
        }

        // POST: Contato/Edit/5
        [HttpPost]
        public ActionResult Edit(Contato model)
        {
            Contato contato = db.Contato.Include("Enderecos").Where(x => x.ContatoId == model.ContatoId).FirstOrDefault();
            contato.Nome = model.Nome;
            contato.Telefone = model.Telefone;
            contato.email = model.email;
            if(model.DataNascimento.ToString() == "01/01/0001 00:00:00")
            {
                this.ModelState.AddModelError("DataNascimento", "Data Inválida");
                return View(contato);
            }
            contato.DataNascimento = model.DataNascimento;

            try
            { 
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Edit", model.ContatoId);
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View(contato);
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
