using jeweller.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace jeweller.Repository
{
    public class JewellerHandler : IJewellerHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["jewellercon"].ToString();
            con = new SqlConnection(constring);
        }

        // ********** Get Jeweller username and password ********************
        [HandleError]
        public List<JewellerDetails> GetJeweller()
        {
            connection();
            List<JewellerDetails> jewellerlist = new List<JewellerDetails>();

            SqlCommand cmd = new SqlCommand("GetJeweller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                jewellerlist.Add(
                    new JewellerDetails
                    {
                        Username = Convert.ToString(dr["username"]),
                        Password = Convert.ToString(dr["password"]),
                        Name = Convert.ToString(dr["name"]),
                        Contact1 = Convert.ToString(dr["contact1"]),
                        Contact2 = Convert.ToString(dr["contact2"]),
                        Email = Convert.ToString(dr["email"]),
                        Address = Convert.ToString(dr["address"]),
                        Pincode = Convert.ToString(dr["pincode"]),
                    });
            }
            return jewellerlist;
        }

        // ***************** UPDATE JEWELLERS DETAILS *********************
        public bool UpdateDetails(JewellerDetails jd)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateJeweller", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", jd.Username);
            cmd.Parameters.AddWithValue("@password", jd.Password);
            cmd.Parameters.AddWithValue("@name", jd.Name);
            cmd.Parameters.AddWithValue("@contact1", jd.Contact1);
            cmd.Parameters.AddWithValue("@contact2", jd.Contact2);
            cmd.Parameters.AddWithValue("@email", jd.Email);
            cmd.Parameters.AddWithValue("@address", jd.Address);
            cmd.Parameters.AddWithValue("@pincode", jd.Pincode);

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