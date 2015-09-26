using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerServiceLibrary.Db;
using MessengerServiceLibrary.Classes;
using System.Data;
using System.Data.SqlClient;

namespace MessengerServiceLibrary.BLL
{
    class UserLogic : DbHelper
    {
        // if any error db will return 1
        internal bool RegisterUser(User user)
        {
            try
            {
                command = database.GetStoredProcCommand("sp_SetUser");

                database.AddInParameter(command, "@ID", SqlDbType.Int, user.Id);
                database.AddInParameter(command, "@Name", SqlDbType.NVarChar, user.Name);
                database.AddInParameter(command, "@Surname", SqlDbType.NVarChar, user.SurName);
                database.AddInParameter(command, "@Username", SqlDbType.NVarChar, user.UserName);
                database.AddInParameter(command, "@Password", SqlDbType.NVarChar, user.Password);
                database.AddInParameter(command, "@ProfilePicture", SqlDbType.NVarChar, user.ProfilePicture);
                database.ExecuteScalar(command);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        internal User Login(string name, string password)
        {

            command = database.GetStoredProcCommand("sp_LoginUser");

            database.AddInParameter(command, "@UserName", SqlDbType.NVarChar, name);
            database.AddInParameter(command, "@Password", SqlDbType.NVarChar, password);
            using (var reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    return (new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        UserName = reader["UserName"].ToString(),
                        Name = reader["Name"].ToString(),
                        ProfilePicture = reader["ProfilePicture"].ToString(),
                        SurName = reader["SurName"].ToString()
                    });
                }
            }
            return null;

        }

        internal bool UserNameExists(string username)
        {
            command = database.GetStoredProcCommand("sp_UserNameExists");
            database.AddInParameter(command, "@UserName", SqlDbType.NVarChar, username);
            using (var reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

