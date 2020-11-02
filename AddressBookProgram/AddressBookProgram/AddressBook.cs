using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookProgram
{
    public class AddressBook
    {
        public List<Contacts> ContactList;
        public Dictionary<string, Contacts> addressBook = new Dictionary<string, Contacts>();
        public Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();
        private Dictionary<Contacts, string> cityDictionary = new Dictionary<Contacts, string>();
        private Dictionary<Contacts, string> stateDictionary = new Dictionary<Contacts, string>();
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
        public void CreateCityDictionary()
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.cityDictionary.Add(contact, contact.City);
                }
            }
        }
        public void CreateStateDictionary()
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.stateDictionary.Add(contact, contact.State);
                }
            }
        }
        public void DisplayCountByCityandState()
        {
            CreateCityDictionary();
            CreateStateDictionary();
            Dictionary<string, int> countByCity = new Dictionary<string, int>();
            Dictionary<string, int> countByState = new Dictionary<string, int>();
            foreach (var obj in addressBookDictionary.Values)
            {
                foreach (var person in obj.cityDictionary)
                {
                    countByCity.TryAdd(person.Value, 0);
                    countByCity[person.Value]++;
                }
            }
            Console.WriteLine("City wise count :");
            foreach (var person in countByCity)
            {
                Console.WriteLine(person.Key + ":" + person.Value);
            }
            foreach (var obj in addressBookDictionary.Values)
            {
                foreach (var person in obj.stateDictionary)
                {
                    countByState.TryAdd(person.Value, 0);
                    countByState[person.Value]++;
                }
            }
            Console.WriteLine("State wise count :");
            foreach (var person in countByState)
            {
                Console.WriteLine(person.Key + ":" + person.Value);
            }
        }
        public void SortByName()
        {
            foreach (AddressBook addressBookobj in addressBookDictionary.Values)
            {
                List<string> list = addressBookobj.addressBook.Keys.ToList();
                list.Sort();
                foreach (string name in list)
                {
                    Console.WriteLine(addressBookobj.addressBook[name].ToString());
                }
            }
        }
        public void SortByCity()
        {
            CreateCityDictionary();
            Dictionary<string, Contacts> inverseCityDictionary = new Dictionary<string, Contacts>();
            foreach (AddressBook obj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in obj.cityDictionary.Keys)
                {
                    inverseCityDictionary.TryAdd(contact.City, contact);
                }
            }
            List<string> list = inverseCityDictionary.Keys.ToList();
            list.Sort();
            foreach (string city in list)
            {
                Console.WriteLine(inverseCityDictionary[city].ToString());
            }
        }
        public void SortByState()
        {
            CreateStateDictionary();
            Dictionary<string, Contacts> inverseStateDictionary = new Dictionary<string, Contacts>();
            foreach (AddressBook obj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in obj.stateDictionary.Keys)
                {
                    inverseStateDictionary.TryAdd(contact.State, contact);
                }
            }
            List<string> list = inverseStateDictionary.Keys.ToList();
            list.Sort();
            foreach (string state in list)
            {
                Console.WriteLine(inverseStateDictionary[state].ToString());
            }
        }
        public void SortByZip()
        {
            SortedList<int, Contacts> sortedbyCity = new SortedList<int, Contacts>();
            foreach (AddressBook addressBookobj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in addressBookobj.addressBook.Values)
                {
                    sortedbyCity.TryAdd(contact.Zip, contact);
                }
            }
            foreach (var item in sortedbyCity)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
