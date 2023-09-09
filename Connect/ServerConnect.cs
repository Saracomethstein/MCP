using System;
using System.Net.Mail;
using System.Net;
using System.Data.SQLite;
using System.Runtime.InteropServices;

namespace Connection
{
    public class ServerConnect : IServerConnect
    {
        public const string filePath = @"C:\ProgramData\cursorposition.db";
        
        public static SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version = 3; New = True; Compress = True;");

        public bool CheckUser(string username, string password)
        {
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "SELECT * FROM users WHERE user_name = @username AND user_password = @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.ExecuteNonQuery();
            connection.Close();

            return count > 0;
        }

        public void DeleteEvents()
        {
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "DELETE FROM events;";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }

        public void DeleteUsers()
        {
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "DELETE FROM users;";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }

        public void Message(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now}] [Info] {str}");
            Console.ResetColor();
        }

        public void SaveToDatabase(int counter, string events, string coordinates, DateTime date)
        {
            SQLiteCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "INSERT INTO events (event_id, event_name, event_coordinates, event_time) VALUES (@Counter, @Event, @Coordinates , @Time)";
            cmd.Parameters.AddWithValue("@Counter", counter);
            cmd.Parameters.AddWithValue("@Event", events);
            cmd.Parameters.AddWithValue("@Coordinates", coordinates);
            cmd.Parameters.AddWithValue("@Time", date);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }
    }
}
