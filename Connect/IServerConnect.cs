using System;
using System.ServiceModel;

namespace Connection
{
    [ServiceContract]
    public interface IServerConnect
    {
        [OperationContract]
        bool CheckUser(string name, string password);

        [OperationContract]
        void DeleteEvents();

        [OperationContract]
        void DeleteUsers();

        [OperationContract]
        void SaveToDatabase(int counter, string events, string coordinates, DateTime date);

        [OperationContract]
        void Message(string str);
    }
}
