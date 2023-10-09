using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public interface ICustomer
    {
         List<Customer> GetCustomer();
         Customer FindCustomerById(string Email, string password);

    }
}
