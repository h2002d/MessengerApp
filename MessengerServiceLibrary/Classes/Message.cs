using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerServiceLibrary.BLL;

namespace MessengerServiceLibrary.Classes
{
   public class Message
    {
        private static MessageLogic mMessageLogic = new MessageLogic();

        #region Properties

        public int? id { get; set; }
        public string Text { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime MessageDate { get; set; }

        #endregion

        #region Static Methods

        public static bool SendMessage(Message message)
        {
            return mMessageLogic.SendMessage(message);
        }

        public static List<Message> GetMessagesByChat(int receiverId, int senderId,int pageNumber)
        {
            return mMessageLogic.GetMessages(receiverId, senderId, pageNumber);
        }

        public static bool DeleteMessage(int id)
        {
            return mMessageLogic.DeleteMessage(id);
        }

        #endregion

    }
}
