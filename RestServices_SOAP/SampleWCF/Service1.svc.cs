using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
namespace SampleWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        [WebInvoke(Method = "GET", ResponseFormat=WebMessageFormat.Json, UriTemplate = "insert/{username}/{state}")]
        public string insertDetails(string username, string state)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into details(username,state)values('" + username + "','" + state + "')", conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            return ("Succesfully inserted into Table");

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "retrieve/{username}")]
        public string retrieveDetails(string username)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);

            conn.Open();
            string name1 = "";
            
            string state1 = "";

            SqlCommand cmd = new SqlCommand("select * from details where username='" + username + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name1 = reader["username"].ToString();
               
                state1 = reader["state"].ToString();

            }
            reader.Close();
            conn.Close();
            return "user Name: " + name1 + " you are from : " + state1;
        }

        
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
