using ASM01BusinessObjects.Models;
using ASM01Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM01Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }
    }
}
