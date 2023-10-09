using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class CustomerRepository:ICustomer
    {

        public  List<Customer> GetCustomer()
        {
            var list = new List<Customer>();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public  Customer FindCustomerById(string Email, string password)
        {
            var list = new Customer();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Customers.FirstOrDefault(x => x.Email == Email && x.Password == password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public  int FindCustomerMaxId()
        {
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    int maxId = context.Customers.Max(customer => customer.CustomerId.Value);
                    return maxId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public  void SaveCustomer(Customer Customer)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.Customers.Add(Customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public  Customer checkAdminLogin(string email, string password)
        {
            var c = new FUFlowerBouquetManagementContext();
            Customer admin = c.getDefaultAccounts();
            if (email == admin.Email && password == admin.Password)
            {
                return admin;
            }
            return null;
        }

        public  Customer FindCustomerById(int id)
        {
            var list = new Customer();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Customers.FirstOrDefault(x => x.CustomerId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public  Customer FindCustomerByEmail(string email)
        {
            var list = new Customer();
            try
            {
                using (var context = new FUFlowerBouquetManagementContext())
                {
                    list = context.Customers.FirstOrDefault(x => x.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public  void UpdateCustomer(Customer Customer)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.Customers.Update(Customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public  void DeleteCustomer(Customer Customer)
        {

            try
            {
                using var context = new FUFlowerBouquetManagementContext();

                context.Customers.Remove(Customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
