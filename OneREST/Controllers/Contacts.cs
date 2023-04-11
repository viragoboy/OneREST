using Microsoft.AspNetCore.Mvc;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;
using OneREST.Models;
namespace OneREST.Controllers;

[ApiController]
[Route("/api/contacts")]
public class Contacts : ControllerBase
{
    string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admintc";

    public Contacts()
    {
    }

    [HttpGet]
    public List<PhoneContact> GetAll()
    {
        List<PhoneContact> contacts = new List<PhoneContact>();

        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            // Retrieve data from the "contacts" table
            using (var cmd = new NpgsqlCommand("SELECT name, phone FROM contactsdotnet", conn))
            {
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        // Retrieve data from the current row
                        string name = reader.GetString(0);
                        string phone = reader.GetString(1);

                        // Create a Contact object and display the data
                        PhoneContact contact = new PhoneContact(name, phone);
                        contacts.Add(contact);
                        Console.WriteLine("Name: {contact.name}, Phone: {contact.phone}");
                    }
                }
            }
        }
        return contacts;
    }



    [HttpGet("{id}")]
    public PhoneContact GetID(int id)
    {
        return null;
    }

    [HttpPost("{id}")]
    public PhoneContact Insert(int id)
    {
        return null;
    }

}

