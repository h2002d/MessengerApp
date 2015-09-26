using MessengerServiceLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMessengerService
    {
        [OperationContract]
        User Login(string userName ,string password);
        [OperationContract]
        bool Register(User user);
        [OperationContract]
        bool UserNameExists(string username);
        [OperationContract]
        List<Message> GetMessages(int recieverId, int senderId, int pageNumber);
        [OperationContract]
        bool DeleteMessage(int id);
        [OperationContract]
        bool SendMessage(Message message);
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "MessengerServiceLibrary.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
