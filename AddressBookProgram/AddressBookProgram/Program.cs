using System;
using System.Collections.Generic;

namespace AddressBookProgram
{
    class Program
    {
        public static Dictionary<string, AddressBook> AddressBookDict = new Dictionary<string, AddressBook>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            int choice;
            string name;
            do
            {
                Console.WriteLine("\nMenu : \n 1.Add New Address Book \n 2.Work On Existing Address Book \n  3.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Name of Address Book");
                        name = Console.ReadLine();
                        AddressBookDict.Add(name, new AddressBook());
                        break;
                    case 2:
                        Console.WriteLine("Enter the Name of Address Book you wish to Work On");
                        name = Console.ReadLine();
                        AddressBook addressBook = AddressBookDict[name];
                        AddressBookFill(addressBook);
                        break;
                }
            } while (choice != 3);
        }

        public static void AddressBookFill(AddressBook addressBook)
        {
            int option;
            do
            {
                Console.WriteLine("\nMenu : \n1.Add Contact \n2.Edit Contact \n3.Delete Contact \n 4.Search Contact by city/state \n 5.Count by City/State \n 6.Sort Entries By Name \n 7.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Contacts contact = new Contacts();
                        SetContact(contact);
                        addressBook.AddContact(contact);
                        break;
                    case 2:
                        Console.WriteLine("Enter the Phone Number of Contact to Edit");
                        long phoneNo = long.Parse(Console.ReadLine());
                        int index = addressBook.FindByPhoneNo(phoneNo);
                        if (index == -1)
                        {
                            Console.WriteLine("No Contact Exists");
                            continue;
                        }
                        else
                        {
                            Contacts contact2 = new Contacts();
                            SetContact(contact2);
                            addressBook.ContactList[index] = contact2;
                            Console.WriteLine("Contact Updated Successfully");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the First Name of Contact you wish to delete");
                        string firstName = Console.ReadLine();
                        int indexValue = addressBook.FindByFirstName(firstName);
                        if (indexValue == -1)
                        {
                            Console.WriteLine("No Contact Exists with Following First Name");
                            continue;
                        }
                        else
                        {
                            addressBook.DeleteContact(indexValue);
                            Console.WriteLine("Contact Deleted Successfully");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Would You Like To \n1.Search by city \n2.Search by state");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("Enter name of city :");
                                addressBook.SearchPersonByCity(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter name of state :");
                                addressBook.SearchPersonByState(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }
                        break;
                    case 5:
                        addressBook.DisplayCountByCityandState();
                        break;
                    case 6:
                        addressBook.SortByName();
                        break;
                }
            } while (option != 7);
        }
        public static void SetContact(Contacts contact)
        {
            Console.WriteLine("Enter the First Name");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter the City Name");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter the State Name");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter the zip code");
            contact.Zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number");
            contact.PhoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the email address");
            contact.Email = Console.ReadLine();
        }
    }
}
