using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookProgram
{
    class CSVHandler
    {
        private string filePath = @"C:\Users\Sammy Striker\source\repos\AddressBookProgram\AddressBookProgram\Utility\AddressBookCSV.csv";
        public void WriteToFile(Dictionary<string, AddressBook> addressBookDictionary)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (AddressBook obj in addressBookDictionary.Values)
                    {
                        List<Contacts> contactRecord = obj.addressBook.Values.ToList();
                        csv.WriteRecords(contactRecord);
                    }
                    Console.WriteLine("\nSuccessfully added to CSV file.");
                    csv.Dispose();
                }
            }
        }
        public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    Console.WriteLine("Below are Contents of CSV File");
                    List<Contacts> contactRecord = csv.GetRecords<Contacts>().ToList();
                    foreach (Contacts contact in contactRecord)
                    {
                        Console.WriteLine(contact.ToString());
                    }
                }
            }
        }
    }
}