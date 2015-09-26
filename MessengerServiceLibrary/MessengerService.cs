using MessengerServiceLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MessengerService : IMessengerService
    {

        #region User Actions

        public User Login(string userName, string password)
        {
            return User.Login(userName, password);
        }

        public bool Register(User user)
        {
            return User.Register(user);
        }

        public bool UserNameExists(string username)
        {
            return User.UserNameExists(username);
        }
        #endregion

        #region Message Actions

        public List<Message> GetMessages(int recieverId,int senderId,int pageNumber)
        {
            return Message.GetMessagesByChat(recieverId, senderId, pageNumber);
        }

        public bool DeleteMessage(int id)
        {
            return Message.DeleteMessage(id);
        }
        public bool SendMessage(Message message)
        {
            return Message.SendMessage(message);
        }

        #endregion

    }
}
