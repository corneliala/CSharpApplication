using ContactApplication.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace ContactApplication.Services
{
    
    internal class MenuManager
    {
        private List<IContact> contacts = new List<IContact>();
        private FileService file = new FileService();
        
        

        public string FilePath { get; set; } = null!;
        public void OptionMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Adressboken!");
            Console.WriteLine("1. Skapa en kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa en specifik kontakt");
            Console.WriteLine("4. Ta bort en specifik kontakt");
            Console.Write("Välj ett av alternativen ovan:");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1": OptionOne(); break;
                case "2": OptionTwo(); break;
                case "3": OptionThree(); break;
                case "4": OptionFour(); break;
            }
        }

        private void OptionOne()
        {
            Console.Clear();
            Console.WriteLine("Skapa en kontakt");

            
            IContact contact = new Contact();

            Console.Write("Förnamn:");
            contact.FirstName = Console.ReadLine() ?? "";
            Console.Write("Efternamn:");
            contact.LastName = Console.ReadLine() ?? "";
            Console.Write("E-postadress:");
            contact.Email = Console.ReadLine() ?? "";
            Console.Write("Telefon:");
            contact.Phone = Console.ReadLine() ?? "";
            Console.Write("Adress:");
            contact.Address = Console.ReadLine() ?? "";

            contacts.Add(contact);
            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
        }

        private void OptionTwo()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}\n{contact.Email}\n");
            }
            Console.ReadKey();
            
        }

        private void OptionThree()
        {
            IContact contact = new Contact();
            Console.WriteLine("Visa en specifik kontakt");
            Console.Write("Ange förnamnet på kontakten:");
            string firstName = Console.ReadLine() ?? "";
            Console.Write("Ange efternamnet på kontakten:");
            string lastName = Console.ReadLine() ?? "";

            var foundContact = contacts.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (foundContact != null)
            {
                Console.WriteLine("Namn: " + foundContact.FirstName + " " + foundContact.LastName);
                Console.WriteLine("E-postadress: " + foundContact.Email);
            }
            else
            {
                Console.WriteLine("Kontakten hittades inte.");
            }
            Console.ReadKey();
        }

        private void OptionFour()
        {
            IContact contact = new Contact();
            Console.WriteLine("Ta bort kontakt från listan");
            Console.Write("Ange förnamnet på kontakten:");
            string firstName = Console.ReadLine() ?? "";
            Console.Write("Ange efternamnet på kontakten:");
            string lastName = Console.ReadLine() ?? "";

            var foundContact = contacts.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (foundContact != null)
            {
                contacts.Remove(foundContact);
                Console.WriteLine("Kontakten är nu borttagen.");
            }
            else
            {
                Console.WriteLine("Kontakten hittades inte.");
            }
            Console.ReadKey();

        }
    }
}
