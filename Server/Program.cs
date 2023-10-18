using Connection;
using Server.DbConnect;
using System;
using System.ServiceModel;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            CheckConnection();
            Console.ReadLine();
        }

        private static bool CheckConnection()
        {
            Write("Connecting to the server...");
            try
            {
                var serviceAddress = "localhost:8301";
                var serviceName = "MyService";

                var host = new ServiceHost(typeof(ServerConnect), new Uri($"net.tcp://{serviceAddress}/{serviceName}"));
                var serverBinding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IServerConnect), serverBinding, "");

                host.Open();
                Write("The host is connected.");
                Connect.GetDbConnection();
            }
            catch (Exception ex)
            {
                ErrorWrite("Failed to connect to host.");
                ErrorWrite($"{ex}");
            }
            return true;
        }

        #region Console
        public static void Write(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now}] [Info] {str}");
            Console.ResetColor();
        }

        public static void ErrorWrite(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now}] [Error:] {str}");
            Console.ResetColor();
        }
        #endregion
    }
}
