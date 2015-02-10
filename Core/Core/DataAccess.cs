using System;
using System.Collections;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Data
{
    public class DataAccess
    {
        public DataAccess()
        {

        }

        
        public string getData(string sql, ref DataSet ds)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Initial Catalog=Database1;Integrated Security=True");
            SqlDataAdapter dt = new SqlDataAdapter(sql, con);

            try
            {
                con.Open();
                dt.Fill(ds);
                return "1";
            }
            catch (Exception ex) { return ex.Message; }
            finally
            {
                con.Close();
            }
        }

        public string exeQuery(string sql)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Initial Catalog=Database1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "1";
            }
            catch (Exception ex) { return ex.Message; }
            finally
            {
                con.Close();
            }
        }
        public string FillDataSet(string spName, DataTable Parameters, ref DataSet ds)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Initial Catalog=Database1;Integrated Security=True");
            SqlDataAdapter dt = new SqlDataAdapter(spName, con);

            dt.SelectCommand.CommandType = CommandType.StoredProcedure;


            for (int i = 0; i < Parameters.Rows.Count; i++)
            {
                dt.SelectCommand.Parameters.Add(new SqlParameter(Parameters.Rows[i]["ParameterName"].ToString(), Parameters.Rows[i]["ParameterValue"].ToString()));
            }

            try
            {
                con.Open();
                dt.Fill(ds);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }


        }
        public string getPublicData(string sql, ref DataSet ds)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Initial Catalog=Database1;Integrated Security=True");
            SqlDataAdapter dt = new SqlDataAdapter(sql, con);

            try
            {
                con.Close();
                dt.Fill(ds);
                return "1";
            }
            catch (Exception ex) { return ex.Message; }
            finally
            {
                con.Close();
            }
        }
        public string Update(string spName, DataTable Parameters, string ParameterOutName, ref int ParameterOutValue)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;C:\eyad\Special Topics in Computer Science(1)\LDA\Tools\LatentDirichletAllocation\LatentDirichletAllocation-master\Core\Core\Database1.mdf;Initial Catalog=Database1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(spName, con);

            cmd.CommandType = CommandType.StoredProcedure;


            for (int i = 0; i < Parameters.Rows.Count; i++)
            {
                cmd.Parameters.Add(new SqlParameter(Parameters.Rows[i]["ParameterName"].ToString(), Parameters.Rows[i]["ParameterValue"].ToString()));

            }

            if (ParameterOutName != "")
            {
                SqlParameter PKParameter = new SqlParameter();
                PKParameter.Direction = ParameterDirection.Output;
                PKParameter.DbType = DbType.Int32;
                PKParameter.ParameterName = ParameterOutName;
                cmd.Parameters.Add(PKParameter);
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                if (ParameterOutName != "")
                {
                    ParameterOutValue = Convert.ToInt32(cmd.Parameters[ParameterOutName].Value);
                }
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }


        }

       
    }
}
