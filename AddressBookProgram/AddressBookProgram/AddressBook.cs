﻿using System;
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
    }
}