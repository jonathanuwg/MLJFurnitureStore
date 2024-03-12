﻿/// <summary>
/// Member Data Access Layer
/// Group 4
/// Programmer: LKeller
/// Date: 08/11/24
/// </summary>

using cs6232_g4.DAL;
using Members.Model;
using System.Data.SqlClient;

namespace Members.DAL
{
    public class MemberDAL
    {
        public List <Member> GetMemberByID(int ID)
        {
            List <Member> MemberList = new List <Member>();

            string selectStatement =
                "SELECT member_id, date_of_birth, fname,lname, address1, address2, city, state, zip, phone, gender " +
                "FROM StoreMember " + 
                "WHERE member_id = @ID"
            ;

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.Add(new SqlParameter("@ID", ID));
                   
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Member member = new Member();
                            member.MemberID = (int)reader["member_id"];
                            member.DateOfBirth = (DateTime?)reader["date_of_birth"];
                            member.FirstName = reader["fname"].ToString();
                            member.LastName = reader["lname"].ToString();
                            member.Address1 = reader["address1"].ToString();
                            member.Address2 = reader["address2"].ToString();
                            member.City = reader["city"].ToString();
                            member.State = reader["state"].ToString();
                            member.ZipCode = reader["zip"].ToString();
                            member.Phone = reader["phone"].ToString();
                            member.Gender = Convert.ToChar(reader["gender"]);
                            
                            MemberList.Add(member);
                        }
                    }
                }
            }
            return MemberList;
        }


    }
}
