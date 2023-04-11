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
    public List<PhoneContact> GetAll ()
    {
        ContactsService cs = new ContactsService ();
        return cs.GetAll ();
    }

    [HttpGet ("{name}")]
    public PhoneContact GetName (string name)
    {
        ContactsService cs = new ContactsService ();
        return cs.GetName (name);
    }

    [HttpPost]
    public PhoneContact CreateContact (PhoneContact phoneContact)
    {
        ContactsService cs = new ContactsService ();
        return cs.CreateContact (phoneContact);
    }

}

