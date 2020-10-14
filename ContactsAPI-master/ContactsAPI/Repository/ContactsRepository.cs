using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        static List<Contacts> ContactsList = new List<Contacts>();
        public void Add(Contacts item)
        {
            ContactsList.Add(item);
        }

        public Contacts Find(string key)
        {
            return ContactsList
                .Where(e => e.MobilePhone.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<Contacts> GetAll()
        {
            return ContactsList;
        }

        public void Remove(string Id)
        {
            var itemtoremove = ContactsList.SingleOrDefault(r => r.MobilePhone == Id);
            if(itemtoremove != null)
            {
                ContactsList.Remove(itemtoremove);
            }
        }

        public void Update(Contacts item)
        {
            var itemtoupdate = ContactsList.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if(itemtoupdate != null)
            {
                itemtoupdate.FirstName = item.FirstName;
                itemtoupdate.LastName = item.LastName;
                itemtoupdate.IsFamiliyMember = item.IsFamiliyMember;
                itemtoupdate.Company = item.Company;
                itemtoupdate.JobTitle = item.JobTitle;
                itemtoupdate.Email = item.Email;
                itemtoupdate.MobilePhone = item.MobilePhone;
                itemtoupdate.DateOfBirth = item.DateOfBirth;
                itemtoupdate.AnniversaryDate = item.AnniversaryDate;
            }
        }
    }
}
