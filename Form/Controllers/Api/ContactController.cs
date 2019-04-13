using System;
using System.Data.Entity;
using System.Linq;
using Form.Models;
using Microsoft.AspNetCore.Mvc;

namespace Form.Controllers.Api
{
    public class ContactController : Controller
    {
        readonly string baseUrl = "Contact/GetContact";

        [HttpPost]
        public JsonResult GetContact([FromBody]Contact model,int counter=1)
        {
            try
            {
                TestProjectContext db = new TestProjectContext();
                var contact = db.Contact.Where(a => !(a.Birthdate == null) &&
                                          !(a.Nid == null))
                                          .OrderBy(a=>a.Nid)
                                          .Skip(20 * (counter - 1)).Take(20).ToList();
                return Json(contact);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}