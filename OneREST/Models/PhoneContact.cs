using System;
namespace OneREST.Models;

public class PhoneContact
{
        public String name { get; set; }
        public String phone { get; set; }

        public PhoneContact(String name, String phone)
	{
		this.name = name;
		this.phone = phone;
	}

}

