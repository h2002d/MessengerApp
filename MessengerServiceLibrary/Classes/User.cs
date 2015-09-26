using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerServiceLibrary.BLL;

namespace MessengerServiceLibrary.Classes
{
    public class User
    {

        static UserLogic mUserLogic = new UserLogic();

        #region Properties

        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        

        #endregion


        #region Static Methods

        public static User Login(string name, string password)
        {
            return mUserLogic.Login(name, password);
        }

        public static bool Register(User user)
        {
            return mUserLogic.RegisterUser(user);
        }

        public static bool UserNameExists(string username)
        {
            return mUserLogic.UserNameExists(username);
        }

        #endregion
    }
}
