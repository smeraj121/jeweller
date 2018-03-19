using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace jeweller.Models
{
    public class OrderHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["jewellercon"].ToString();
            con = new SqlConnection(constring);
        }
        public bool AddProduct(Product product, int user)
        {
            connection();
            SqlCommand cmd = new SqlCommand("addproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@product_name", product.Product_Name);
            cmd.Parameters.AddWithValue("@weight", product.Weight);
            cmd.Parameters.AddWithValue("@purity", product.Purity);
            cmd.Parameters.AddWithValue("@desc", product.Desc);
            cmd.Parameters.AddWithValue("@rate", product.Rate);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@product_id",ParameterDirection.Output);
            cmd.Parameters.AddWithValue("@order_id", user);
            cmd.Parameters.AddWithValue("@quantity", 1);
            var cost = 1 * product.Price;
            cmd.Parameters.AddWithValue("@order_price", cost);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Product> GetProducts()
        {
            connection();
            List<Product> productlist = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                productlist.Add(
                    new Product
                    {
                        Product_Id = Convert.ToInt32(dr["product_id"]),
                        Product_Name = Convert.ToString(dr["product_name"]),
                        Weight = Convert.ToSingle(dr["weight"]),
                        Purity = Convert.ToSingle(dr["purity"]),
                        Desc = Convert.ToString(dr["description"]),
                        Rate = Convert.ToSingle(dr["rate"]),
                        Price=Convert.ToSingle(dr["price"])
                    });
            }
            return productlist;
        }

        public List<Orders> GetOrders(int user)
        {
            connection();
            List<Orders> orders = new List<Orders>();

            SqlCommand cmd = new SqlCommand("GetOrders", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user", user);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                orders.Add(
                    new Orders
                    {
                        orders_id = Convert.ToInt32(dr["Id"]),
                        product_id = Convert.ToInt32(dr["product_id"]),
                        order_id= Convert.ToInt32(dr["order_id"]),
                        Quantity = Convert.ToInt32(dr["quantity"]),
                        Order_price = Convert.ToSingle(dr["order_price"]),

                    });
            }
            return orders;
        }

        public bool EditProduct(Product product)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@product_name", product.Product_Name);
            cmd.Parameters.AddWithValue("@weight", product.Weight);
            cmd.Parameters.AddWithValue("@purity", product.Purity);
            cmd.Parameters.AddWithValue("@descrip", product.Desc);
            cmd.Parameters.AddWithValue("@rate", product.Rate);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@product_id", product.Product_Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}