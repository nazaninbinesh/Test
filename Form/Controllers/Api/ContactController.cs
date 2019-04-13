using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Form.Models;
using Microsoft.AspNetCore.Mvc;

namespace Form.Controllers.Api
{
    public class ContactController : Controller
    {
        [HttpPost]
        public JsonResult GetContact([FromBody]Contact model)
        {
            try
            {
                string baseUrl = "Contact/GetContact";

                TestProjectContext db = new TestProjectContext();
                var contact = db.Contact.Where(a => !(a.Birthdate == null) &&
                                          !(a.Nid == null)).ToList();
                if (contact != null)
                {
                    foreach (var item in contact)
                    {
                        var firstName = item.FirstName.ToString();
                        var lastName = item.LastName.ToString();
                        var nId = item.Nid.ToString();
                        var birthDate = item.Birthdate;
                    }
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}