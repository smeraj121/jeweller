using jeweller.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jeweller.Repository
{
    public class CustomerHandler : ICustomerHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["jewellercon"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW CUSTOMER *********************
        public bool AddCustomer(CustomerModel cmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("regcustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", cmodel.Name);
            cmd.Parameters.AddWithValue("@Contact", cmodel.Contact);
            cmd.Parameters.AddWithValue("@Email", cmodel.Email);
            cmd.Parameters.AddWithValue("@Address", cmodel.Address);
            cmd.Parameters.AddWithValue("@Pincode", cmodel.Pincode);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** Get Customer Details ********************
        [HandleError]
        public List<CustomerModel> GetCustomers()
        {
            connection();
            List<CustomerModel> customerslist = new List<CustomerModel>();

            SqlCommand cmd = new SqlCommand("GetCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                customerslist.Add(
                    new CustomerModel
                    {
                        Cust_Id = Convert.ToInt32(dr["cust_id"]),
                        Name = Convert.ToString(dr["name"]),
                        Contact = Convert.ToString(dr["contact"]),
                        Email = Convert.ToString(dr["email"]),
                        Address = Convert.ToString(dr["address"]),
                        Pincode = Convert.ToString(dr["pincode"]),
                    });
            }
            return customerslist;
        }

        public bool UpdateCustomerDetails(CustomerModel cm)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cust_id", cm.Cust_Id);
            cmd.Parameters.AddWithValue("@name", cm.Name);
            cmd.Parameters.AddWithValue("@contact", cm.Contact);
            cmd.Parameters.AddWithValue("@email", cm.Email);
            cmd.Parameters.AddWithValue("@address", cm.Address);
            cmd.Parameters.AddWithValue("@pincode", cm.Pincode);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteCustomer(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DelCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cust_id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<CustomerModel> SearchCustomers(string searchvalue)
        {
            connection();
            List<CustomerModel> customerslist = new List<CustomerModel>();

            SqlCommand cmd = new SqlCommand("SearchCustom", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@searchval", searchvalue);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                customerslist.Add(
                    new CustomerModel
                    {
                        Cust_Id = Convert.ToInt32(dr["cust_id"]),
                        Name = Convert.ToString(dr["name"]),
                        Contact = Convert.ToString(dr["contact"]),
                        Email = Convert.ToString(dr["email"]),
                        Address = Convert.ToString(dr["address"]),
                        Pincode = Convert.ToString(dr["pincode"]),
                    });
            }
            return customerslist;
        }

    }
}