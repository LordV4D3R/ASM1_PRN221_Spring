using ASM01BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM01Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByEmail(String email);
    }
}
