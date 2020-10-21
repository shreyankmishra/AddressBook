using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    public class Contacts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public override bool Equals(object obj)
        {
            Contacts contact = (Contacts)obj;
            if (contact == null)
                return false;
            return this.FirstName.Equals(contact.FirstName) && this.LastName.Equals(contact.LastName);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
