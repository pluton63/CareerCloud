﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class SecurityLoginRepository: BaseConnection,IDataRepository<SecurityLoginPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params SecurityLoginPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Applicant_Educations]
               ([Id]
               ,[Applicant]
               ,[Major]
               ,[Cetificate_Diploma]
               ,[Start_Date]
               ,[Completion_Date]
               ,[Completion_Percent])
                VALUES
               (@Id,
                @Applicant, 
                @Major,
                @Cetificate_Diploma,
                @Start_Date,
                @Completion_Date,
                @Completion_Percent)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginPoco poco in items)
                    {
                            SecurityLoginPoco oPoco = new SecurityLoginPoco();
                            cmd.Parameters.AddWithValue("Id", poco.Id);
                            cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                            cmd.Parameters.AddWithValue("Major", poco.Major);
                            cmd.Parameters.AddWithValue("Cetificate_Diploma", poco.CertificateDiploma);
                            cmd.Parameters.AddWithValue("Start_Date", poco.StartDate);
                            cmd.Parameters.AddWithValue("Completion_Date", poco.CompletionDate);
                            cmd.Parameters.AddWithValue("Completion_Percent", poco.CompletionPercent);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            }
                    }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginPoco.Add-->Insertion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT[Id]
              ,[Applicant]
              ,[Major]
              ,[Cetificate_Diploma]
              ,[Start_Date]
              ,[Completion_Date]
              ,[Completion_Percent]
              ,[Time_Stamp]
                FROM[dbo].[Applicant_Educations]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    SecurityLoginPoco[] arrPoco = new SecurityLoginPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        SecurityLoginPoco poco = new SecurityLoginPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Applicant = (Guid)reader["Applicant"];
                        poco.Major = (String)reader["Major"];
                        poco.CertificateDiploma = (String)reader["CertificateDiploma"];
                        poco.StartDate = (DateTime)reader["StartDate"];
                        poco.CompletionDate = (DateTime)reader["CompletionDate"];
                        poco.CompletionPercent = (Byte)reader["CompletionPercent"];
                        poco.TimeStamp = (Byte[])reader["TimeStamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("SecurityLoginPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<SecurityLoginPoco> GetList(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            try
            {
                SecurityLoginPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("SecurityLoginPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Applicant_Educations]
                WHERE Id =@Id)";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params SecurityLoginPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Applicant_Educations]
                SET [Id]=@Id,
                    [Applicant]=@Applicant,
                    [Major]=@Major,
                    [Cetificate_Diploma]=@Cetificate_Diploma,
                    [Start_Date]=@Start_Date,
                    [Completion_Date]=@Completion_Date,
                    [Completion_Percent]=@Completion_Percent
                    Where Id=@Id)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginPoco poco in items)
                    {
                        SecurityLoginPoco oPoco = new SecurityLoginPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Major", poco.Major);
                        cmd.Parameters.AddWithValue("Cetificate_Diploma", poco.CertificateDiploma);
                        cmd.Parameters.AddWithValue("Start_Date", poco.StartDate);
                        cmd.Parameters.AddWithValue("Completion_Date", poco.CompletionDate);
                        cmd.Parameters.AddWithValue("Completion_Percent", poco.CompletionPercent);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
