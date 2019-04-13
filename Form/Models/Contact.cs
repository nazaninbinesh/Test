using System;
using System.Collections.Generic;

namespace Form.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nid { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
