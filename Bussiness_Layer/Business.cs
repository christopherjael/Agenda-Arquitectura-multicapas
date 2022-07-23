using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using Entity_Layer;

namespace Business_Layer
{
    public class Business
    {
        Data data = new Data();
        public List<Contacts> Populate(string seachParam)
        {
            return data.Populate(seachParam);
        }

        public List<Contacts> ListAllContacts() {
            return data.ListAllContacts();
        }

        public void CreateContact(Contacts contacts)
        {
            data.CreateContact(contacts);
        }

        public void UpdateContact(Contacts contacts)
        {
            data.UpdateContact(contacts);
        }

        public void DeleteContact(int Id)
        {
            data.DeleteContact(Id);
        }
    }
}
