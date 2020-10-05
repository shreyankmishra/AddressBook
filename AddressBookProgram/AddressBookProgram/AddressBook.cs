using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    class AddressBook
    {
        public List<Contacts> ContactList;
        public AddressBook()
        {
            this.ContactList = new List<Contacts>();
        }
        public void AddContact(Contacts contact)
        {
            this.ContactList.Add(contact);
        }
        public int FindByPhoneNo(long phoneNo)
        {
            return this.ContactList.FindIndex(contact => contact.PhoneNumber.Equals(phoneNo));
        }
    }
}
