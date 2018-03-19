using jeweller.Models;
using System.Collections.Generic;

namespace jeweller.Repository
{
    public interface ICustomerHandle
    {
        bool AddCustomer(CustomerModel cmodel);
        List<CustomerModel> GetCustomers();
        bool UpdateCustomerDetails(CustomerModel cm);
        bool DeleteCustomer(int id);
        List<CustomerModel> SearchCustomers(string searchvalue);
    }
}