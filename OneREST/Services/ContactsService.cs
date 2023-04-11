using System;
using Npgsql;
using OneREST.Controllers;
using OneREST.Models;

namespace OneREST.Services {
    public class ContactsService {
        string connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admintc";

        public ContactsService ()
        {
        }

        public List<PhoneContact> GetAll ()
        {
            List<PhoneContact> contacts = new List<PhoneContact> ();

            using (var conn = new NpgsqlConnection (connectionString)) {
                conn.Open ();
                // Retrieve data from the "contacts" table
                using (var cmd = new NpgsqlCommand ("SELECT name, phone FROM contactsdotnet", conn)) {
                    var reader = cmd.ExecuteReader ();
                    {
                        while (reader.Read ()) {
                            // Retrieve data from the current row
                            string name = reader.GetString (0);
                            string phone = reader.GetString (1);

                            // Create a Contact object and display the data
                            PhoneContact contact = new PhoneContact (name, phone);
                            contacts.Add (contact);
                            Console.WriteLine ("Name: {contact.name}, Phone: {contact.phone}");
                        }
                    }
                }
            }
            return contacts;
        }

        public PhoneContact GetName (string name)
        {
            using (var conn = new NpgsqlConnection (connectionString)) {
                conn.Open ();

                using (var cmd = new NpgsqlCommand ("SELECT name, phone FROM contactsdotnet WHERE name = @name", conn)) {
                    cmd.Parameters.AddWithValue ("@name", name);
                    var reader = cmd.ExecuteReader ();
                    {
                        reader.Read ();
                        PhoneContact contact = new PhoneContact (reader.GetString (0), reader.GetString (1));
                        return contact;
                    }
                }
            }
        }

        public PhoneContact CreateContact (PhoneContact phoneContact)
        {
            using (var conn = new NpgsqlConnection (connectionString)) {
                conn.Open ();
                using (var cmd = new NpgsqlCommand ("INSERT INTO contactsdotnet (name, phone) VALUES (@name, @phone)", conn)) {
                    cmd.Parameters.AddWithValue ("@name", phoneContact.name);
                    cmd.Parameters.AddWithValue ("@phone", phoneContact.phone);
                    var reader = cmd.ExecuteNonQuery ();
                    return null;
                }
            }
        }

    }
}

