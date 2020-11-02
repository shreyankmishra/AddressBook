using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace AddressBookProgram
{
    class JSONClass
    {
        string filePath = @"C:\Users\Sammy Striker\source\repos\AddressBookProgram\AddressBookProgram\Utility\AddressBookJSON.json";
        public void WriteToFile(Dictionary<string, AddressBook> addressBookDictionary)
        {
            string json = "";
            foreach (AddressBook obj in addressBookDictionary.Values)
            {
                foreach (Contacts contact in obj.addressBook.Values)
                {
                    json = JsonConvert.SerializeObject(contact);
                    File.WriteAllText(filePath, json);
                }
            }
            Console.WriteLine("\nSuccessfully added to JSON file.");
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of JSON File");
            var json = File.ReadAllText(filePath);
            Contacts contact = JsonConvert.DeserializeObject<Contacts>(json);
            Console.WriteLine(contact.ToString());
        }
    }
}