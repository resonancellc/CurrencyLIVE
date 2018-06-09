using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLIVE
{
    public static class StaticSQL
    {
        public static string ConnectionString { get; set; }

        public static void SetConnectionString(string conn)
        {
            ConnectionString = conn;
        }

        public static DateTime? GetLatestUpdateDate()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT TOP(1) Date FROM CurrencyRates ORDER BY Date DESC", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.Text;
                        DateTime? date = (DateTime?)cmd.ExecuteScalar();
                        conn.Close();
                        return date;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                }
            }
        }

        public static void InsertCurrencyData(CurrencyRate currency)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO CurrencyRates (Name, Value, Date)
                                                          VALUES (@Name, @Value, @Date)", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("Name", currency.Name);
                        cmd.Parameters.AddWithValue("Value", currency.Value);
                        cmd.Parameters.AddWithValue("Date", currency.Date);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
        }

        public static DataTable GetCurrencyHistoryByName(string name)
        {
            using (SqlConnection con = new SqlConnection(StaticSQL.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM CurrencyRates WHERE Name = @Name ORDER BY Date ASC", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            DataTable data = ds.Tables[0];
                            return data;
                        }
                    }
                }
            }
        }
    }
}
