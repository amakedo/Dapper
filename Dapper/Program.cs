using Dapper_1;
using System.Data.SqlClient;

namespace Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;";

            var db = new SqlConnection(connStr);

            string sql = "INSERT INTO Students (Name, Age, Adress, Email, Year) VALUES (@Name, @Age, @Adress, @Email, @Year)";

            var student = new Student {Name = "John Doe", Age = 20, Adress = "123 Main St", Email = "test@gmail.com", Year = 2 };

            int rows = db.Execute(sql, student);
            Console.WriteLine($"{rows} row(s) inserted");
        }
    }
}
