using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerServiceLibrary.Db;
using MessengerServiceLibrary.Classes;
using System.Data;

namespace MessengerServiceLibrary.BLL
{
    class MessageLogic : DbHelper
    {
        // if any error db will return 1
        internal bool SendMessage(Message message)
        {
            command = database.GetStoredProcCommand("sp_SendMessage");

            database.AddInParameter(command, "@UserId", SqlDbType.NVarChar, message.SenderId);
            database.AddInParameter(command, "@RecieverId", SqlDbType.NVarChar, message.ReceiverId);
            database.AddInParameter(command, "@MessageContent", SqlDbType.NVarChar, message.Text);
            try
            {
                database.ExecuteNonQuery(command);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal List<Message> GetMessages(int? senderId, int receiverId, int pageNumber)
        {
            List<Message> result = new List<Message>();

            command = database.GetStoredProcCommand("sp_GetMessages");
            database.AddInParameter(command, "@UserId", SqlDbType.Int, senderId.Value);
            database.AddInParameter(command, "@RecieverId", SqlDbType.Int, receiverId);
            database.AddInParameter(command, "@PageNumber", SqlDbType.Int, pageNumber);

            using (var reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    result.Add(new Message
                    {
                        id = Convert.ToInt32(reader["Id"]),
                        Text = reader["MessageContent"].ToString(),
                        MessageDate = Convert.ToDateTime(reader["DateSent"])
                    });
                }
                return result;
            }
            

        }

        internal bool DeleteMessage(int messageId)
        {
            command = database.GetStoredProcCommand("sp_DeleteMessage");

            database.AddInParameter(command, "@MessageId", SqlDbType.Int, messageId);
            try
            {
                database.ExecuteScalar(command);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
