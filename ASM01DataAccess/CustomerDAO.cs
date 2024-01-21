using ASM01BusinessObjects;
using ASM01BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ASM01DataAccess
{
    
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }
        public Customer GetCustomerByEmail (String email)
        {
            var dbContent = new FUMiniHotelManagementContext();
            return dbContent.Customers.SingleOrDefault(m => m.EmailAddress.Equals(email));
        }
    }
}
