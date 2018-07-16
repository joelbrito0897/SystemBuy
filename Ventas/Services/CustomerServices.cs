using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ventas.Models;

namespace Ventas.Services
{
    public interface ICustomerServices
    {
        bool Create(Customer _customer);
        void Update(Customer  _customer);
        void Delete(int ID);
        Customer Find(int? ID);
        List<Customer> CustomerList();
        void sendMessage(Customer customer);
    }
    public class CustomerServices : ICustomerServices
    {
        private readonly GlobalDbContext _context;
        public CustomerServices(GlobalDbContext context)
        {
            _context = context;
        }

        public bool Create(Customer _customer)
        {
            Customer customer = new Customer()
            {
                ID = _customer.ID,
                Name = _customer.Name,
                LastName = _customer.LastName,
                Email = _customer.Email,
                Addres = _customer.Addres,
                Phone = _customer.Phone
            };

            var x = _context.Customer.Add(customer);
            _context.SaveChanges();

            return true;
        }

        public List<Customer> CustomerList()
        {
            var customer = _context.Customer;
            return customer.ToList();
        }

        public void Delete(int ID)
        {
            Customer customerSelect = _context.Customer.Where(x => x.ID == ID).FirstOrDefault();
            var customer = _context.Customer.Remove(customerSelect);
            _context.SaveChanges();
        }

        public Customer Find(int? ID)
        {
            Customer customerSelect = _context.Customer.Where(x => x.ID == ID).FirstOrDefault();
            return customerSelect;
        }

        public void Update(Customer _customer)
        {
            Customer customerSelect = _context.Customer.Where(x => x.ID == _customer.ID).FirstOrDefault();

            customerSelect.ID = _customer.ID;
            customerSelect.Name = _customer.Name;
            customerSelect.LastName = _customer.LastName;
            customerSelect.Email = _customer.Email;
            customerSelect.Addres = _customer.Addres;
            customerSelect.Phone = _customer.Phone;

            _context.SaveChanges();
        }

        public void sendMessage(Customer _customer)
        {
            Customer customerSelect = _context.Customer.Where(x => x.Email == _customer.Email).FirstOrDefault();

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("SystemBuy", "joelbrito0897@hotmail.com"));
                message.To.Add(new MailboxAddress(customerSelect.Name + " " + customerSelect.LastName, customerSelect.Email));
                message.Subject = "SystemBuy | Registro Exitoso";

                var builder = new BodyBuilder();
                var msj = new StringBuilder();
                msj.AppendLine("<h3>Bienvenido a nuestra familia Sr/a "+ customerSelect.Name + " " + customerSelect.LastName+"</h3>");

                builder.HtmlBody = msj.ToString();
                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.live.com", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("joelbrito0897@hotmail.com", "Jb8492036463");
                    client.Send(message);
                    Console.WriteLine("The mail has been sent successfully");
                    client.Disconnect(true);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}