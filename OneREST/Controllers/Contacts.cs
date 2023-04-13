using Microsoft.AspNetCore.Mvc;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;
using OneREST.Models;
using OneREST.Services;
namespace OneREST.Controllers;

[ApiController]
[Route ("/api/contacts")]
public class Contacts : ControllerBase {

    public Contacts ()
    {
    }

    [HttpGet]
    public List<PhoneContact> getAll ()
    {
        ContactsService cs = new ContactsService ();
        return cs.getAll ();
    }

    [HttpGet ("{name}")]
    public PhoneContact getName (string name)
    {
        ContactsService cs = new ContactsService ();
        return cs.getName (name);
    }

    [HttpPost]
    public PhoneContact createContact (PhoneContact phoneContact)
    {
        ContactsService cs = new ContactsService ();
        return cs.createContact (phoneContact);
    }

    [HttpPut]
    public PhoneContact updateContact (PhoneContact phoneContact)
    {
        ContactsService cs = new ContactsService ();
        return cs.updateContact (phoneContact);
    }

    [HttpDelete ("{name}")]
    public PhoneContact deleteContact (string name)
    {
        ContactsService cs = new ContactsService ();
        return cs.deleteContact (name);
    }

}

