using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Provider
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string City { get;  private set; }

        public Provider() { }
        public Provider(int id, string name, string emailaddress)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede estar vacío.");
            if (string.IsNullOrEmpty(emailaddress))
                throw new ArgumentNullException("El correo no puede estar vacío.");

            try
            {
                var email = new System.Net.Mail.MailAddress(emailaddress);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ArgumentNullException("El correo es inválido.");
            }
            Id = id;
            Name = name;
            EmailAddress = emailaddress;

        }

        public void AddAddress(string address, string city)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException("La direccion no puede estar vacío.");
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException("La ciudad no puede estar vacío.");
            Address = address;
            City = city;
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentNullException("El telefono no puede estar vacío.");
            if (phoneNumber.Length < 10)
                throw new FormatException("El telefono debe tener al menos 10 caracteres");
            PhoneNumber = phoneNumber;
        }
    }
}
