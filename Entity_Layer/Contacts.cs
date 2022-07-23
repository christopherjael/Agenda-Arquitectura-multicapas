using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string CivilState { get; set; }
        public string MobileNum { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
    }
}
