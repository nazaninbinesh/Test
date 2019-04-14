using Form.Models;
using Form.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;
using System.Linq;

namespace Form.Controllers.Api
{
    public class ContactController : Controller
    {
        [HttpGet]
        public JsonResult GetContact(ContactViewModel model)
        {
            try
            {
                TestProjectContext db = new TestProjectContext();

                var contact = db.Contact.Where(a => !(a.Birthdate == null) &&
                                          !(a.Nid == null))
                                          .OrderBy(a => a.Nid
                                          )
                                          .Skip(20 * (model.Page - 1)).Take(20).ToList();
                return Json(contact);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public JsonResult UpdateContact([FromBody]Contact model)
        {
            try
            {
                TestProjectContext db = new TestProjectContext();

                var contact = db.Contact.Find(model.Id);
                if (contact != null)
                {
                    contact.FirstName = model.FirstName;
                    contact.LastName = model.LastName;
                    contact.Nid = model.Nid;
                    contact.Birthdate = model.Birthdate;

                    db.SaveChanges();
                }
                return Json(contact);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public JsonResult CreateContact([FromBody]Contact model)
        {
            try
            {
                TestProjectContext db = new TestProjectContext();
                var contact = new Contact();
                contact.FirstName = model.FirstName;
                contact.LastName = model.LastName;
                contact.Birthdate = model.Birthdate;
                contact.Nid = model.Nid;

                db.Contact.Add(contact);
                db.SaveChanges();

                return Json(true);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }
    }
}