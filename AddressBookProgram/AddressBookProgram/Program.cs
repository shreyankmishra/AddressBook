using System;

namespace AddressBookProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome to Address Book Program");
            int option;
            do
            {
                Console.WriteLine("\nMenu : \n1.Add Contact \n2.Edit Contact \n3.Delete Contact \n4.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Contacts contact = new Contacts();
                        setContact(contact);
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
                            setContact(contact2);
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
                }
            } while (option != 4);
        }
        public static void setContact(Contacts contact)
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
