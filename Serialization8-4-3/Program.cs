using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization8_4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var cnt = new Contact("Petya", 777, "petya@mail.ru");

            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream("contact.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, cnt);
            }

            using (var fs = new FileStream("contact.dat", FileMode.OpenOrCreate))
            {
                var contact = (Contact)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($" {contact.Name} --- {contact.PhoneNumber}");
            }

        }
    }

    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
    
}