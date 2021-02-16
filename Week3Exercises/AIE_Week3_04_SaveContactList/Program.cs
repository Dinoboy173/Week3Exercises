using System;
using System.Collections.Generic;
using System.IO;

namespace AIE_32_SaveContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact("bob", "bob@email.com", "12345678"));
            contacts.Add(new Contact("fred", "fred@email.com", "12345678"));
            contacts.Add(new Contact("ted", "ted@email.com", "12345678"));

            // save to file
            SerialiseContactList("contacts.txt", contacts);

            // clear them out
            contacts = new List<Contact>();

            // read from file
            DeSerialiseContactList("contacts.txt", contacts);

        }

        static void SerialiseContactList(string filename, List<Contact> contacts)
        {
            // TODO save all contacts to file.
            
            using (StreamWriter sw = File.CreateText(filename))
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    sw.WriteLine("name " + contacts[i].name);
                    sw.WriteLine("email " + contacts[i].email);
                    sw.WriteLine("phone " + contacts[i].phone);
                    sw.WriteLine("");
                }
            }
        }

        static void DeSerialiseContactList(string filename, List<Contact> contacts)
        {
            // TODO load all contacts from file.
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        

                        var word = line.Split(" ");
                        if (word[0] == "name") name = word[1];
                        if (word[0] == "email") email = word[1];
                        if (word[0] == "phone") phone = word[1];
                    }
                }
            }
        }
    }
}
