using OT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace OT.Services
{
    public class Questions : IQuestions
    {
        public  List<questionsModel> getQuestions(string myDb1ConnectionString)
        {
            List<questionsModel> qObj = new List<questionsModel>();
            try
            {
                

                string ConString = myDb1ConnectionString;

                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating SqlCommand objcet   
                    SqlCommand cm = new SqlCommand("select top 1 * from dbo.questions ORDER BY NEWID()", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    cm.CommandType = CommandType.Text;
                    SqlDataReader sdr = cm.ExecuteReader();
                    while (sdr.Read())
                    {
                        questionsModel q = new questionsModel();
                        q.id = (int)sdr["id"];
                        q.Question = sdr["Question"].ToString();
                        q.Ans1 = sdr["Ans1"].ToString();
                        q.Ans2 = sdr["Ans2"].ToString();
                        q.Ans3 = sdr["Ans3"].ToString();
                        q.Ans4 = sdr["Ans4"].ToString();
                        q.CorrectAns = sdr["CorrectAns"].ToString();
                        
                        qObj.Add(q);
                    }
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
                File.AppendAllText(@"C:\Temp\log.txt", "\n");
                File.AppendAllText(@"C:\Temp\log.txt", "OOPs, something went wrong.\n" + e.ToString());
            }
            finally
            {
                
            }
            return qObj;
        }
    }
}
