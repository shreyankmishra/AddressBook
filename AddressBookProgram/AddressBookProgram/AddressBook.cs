using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookProgram
{
    class AddressBook
    {
        public List<Contacts> ContactList;
        private Dictionary<string, Contacts> addressBook = new Dictionary<string, Contacts>();
        private Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();
        public AddressBook()
        {
            this.ContactList = new List<Contacts>();
        }
        public void AddContact(Contacts contact)
        {
            if (this.ContactList.Find(e => e.Equals(contact)) != null)
                Console.WriteLine("This contact already exists.");
            else
            this.ContactList.Add(contact);
        }
        public int FindByPhoneNo(long phoneNo)
        {
            return this.ContactList.FindIndex(contact => contact.PhoneNumber.Equals(phoneNo));
        }
        public int FindByFirstName(string firstName)
        {
            return this.ContactList.FindIndex(contact => contact.FirstName.Equals(firstName));
        }
        public void DeleteContact(int index)
        {
            this.ContactList.RemoveAt(index);
        }
        public List<Contacts> GetListOfDictionaryKeys(Dictionary<string, Contacts> d)
        {
            List<Contacts> book = new List<Contacts>();
            foreach (var value in d.Values)
            {
                book.Add(value);
            }
            return book;
        }
        public void SearchPersonByCity(string city)
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                List<Contacts> contactList = GetListOfDictionaryKeys(addressbookobj.addressBook);
                foreach (Contacts contact in contactList.FindAll(c => c.City.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        public void SearchPersonByState(string state)
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                List<Contacts> contactList = GetListOfDictionaryKeys(addressbookobj.addressBook);
                foreach (Contacts contact in contactList.FindAll(c => c.State.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
    }
}
