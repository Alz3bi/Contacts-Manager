using System.Xml.Linq;

namespace ContactManager
{
    public class Program
    {

        public static List<string> contacts = new();

        static void Main()
        {
            try
            {
                InterFace();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
            }
        }
        public static void InterFace()
        {
            while (true) {
                Console.Clear();
                Console.WriteLine("Contact Manager");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Remove Contact");
                Console.WriteLine("3. View All Contacts");
                Console.WriteLine("4. Search Contact");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = GetChoice();
                string name;
                const string exit = "Press any key to return to main menu";
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the name of the contact: ");
                        name = GetInput();
                        if(CheckDuplicate(name) == "Contact already exists")
                        {
                            Console.WriteLine(CheckDuplicate(name));
                        }
                        else
                        {
                            AddContact(name);
                            Console.WriteLine("Contact added");
                        }
                        Console.WriteLine(exit);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter the name of the contact: ");
                        name = GetInput();
                        RemoveContact(name);
                        Console.WriteLine(exit);
                        Console.ReadKey();
                        break;
                    case 3:
                        PrintContacts();
                        break;
                    case 4:
                        Console.WriteLine("Enter the name of the contact: ");
                        name = GetInput();
                        bool searchResault = SearchContact(name);
                        if (searchResault)
                        {
                            Console.WriteLine("Contact found");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found");
                        }
                        Console.WriteLine(exit);
                        Console.ReadKey();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        public static List<string> AddContact(string contact)
        {
            // Add contact
            contacts.Add(contact);
            return contacts;
        }
        public static List<string> RemoveContact(string contact)
        {
            // Remove contact
            if (contacts.Contains(contact))
            {
                contacts.Remove(contact);
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
            return contacts;
        }
        public static List<string> ViewAllContacts()
        {
            // View all contacts
            return contacts;
        }
        public static string CheckDuplicate(string contact)
        {
            // Check for duplicate contacts
            if (contacts.Contains(contact))
            {
                return "Contact already exists";
            }
            return "Contact added";
        }
        public static string GetInput()
        {
            string name = Console.ReadLine().Trim();
            while(string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid input");
                name = Console.ReadLine().Trim();
            }
            return name;
        }
        public static int GetChoice()
        {
            string input = Console.ReadLine();
            bool success = Int32.TryParse(input, out int choice);
            while (!success || choice < 1 || choice > 4)
            {
                Console.WriteLine("Please enter a valid input");
                input = Console.ReadLine();
                success = Int32.TryParse(input, out choice);
            }
            return choice;
        }
        public static void PrintContacts()
        {
            const string exit = "Press any key to return to main menu";
            Console.Clear();
            Console.WriteLine("All contacts:");
            foreach (string contact in contacts)
            {
                Console.WriteLine(contact);
            }
            Console.WriteLine(exit);
            Console.ReadKey();
        }
        public static bool SearchContact(string contact)
        {
            // Search for a contact
            Console.Clear();
            foreach (string c in contacts)
            {
                if (c.Contains(contact))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
