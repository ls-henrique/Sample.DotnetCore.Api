using MySql.Data.MySqlClient;
using System;

namespace Sample.Carros.Infra.Data
{
    public class DataContext : IDisposable
    {
        public MySqlConnection Connection { get; set; }

        public DataContext()
        {
            this.Connection = new MySqlConnection("Server=127.0.0.1;Database=prometeus;Uid=admin;Pwd=admin;");
            this.Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
