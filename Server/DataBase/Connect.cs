using System;
using System.Data.SQLite;

namespace Server.DbConnect
{
    public class Connect
    {
        public const string filePath = @"C:\ProgramData\cursorposition.db";

        public static SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version = 3; New = True; Compress = True;");
        
        #region Создание и подключение к БД
        public static void GetDbConnection()
        {
            Write("Подключение к БД.");
            try
            {
                connection.Open();
                Write("Подключение прошло успешно.");

                CreateTables(connection);
                InsertDataUsers(connection);

                connection.Close();
            }
            catch (SQLiteException ex)
            {
                ErrorWrite(ex.Message);
            }
        }

        static void CreateTables(SQLiteConnection conn)
        {
            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS users" +
                "(user_id INT," +
                "user_name varchar(50)," +
                "user_password varchar(50))";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE IF NOT EXISTS events" +
                "(event_id INT," +
                "event_name varchar(50)," +
                "event_coordinates varchar(30)," +
                "event_time varchar(30))";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        static void InsertDataUsers(SQLiteConnection conn)
        {
            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT INTO users" +
                "(user_id, user_name, user_password)" +
                "VALUES" +
                "(1,'Admin', '1q2w3e4r5T');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO users" +
                "(user_id, user_name, user_password)" +
                "VALUES" +
                "(2,'User', 'User');";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        #endregion

        #region Насстройки консоли
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
