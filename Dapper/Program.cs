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

            //int rows = db.Execute(sql, student);
            //Console.WriteLine($"{rows} row(s) inserted");

            //string sqlUpdate = "UPDATE Students SET Age = @Age WHERE Id = @Id";
            //int rows = db.Execute(sqlUpdate, new { Age = 26, Id = 1 });
            //Console.WriteLine($"{rows} row(s) inserted");

            string sqlDelete = "DELETE FROM Students WHERE Id = @Id";
            int rows = db.Execute(sqlDelete, new { Id = 1 });
            Console.WriteLine($"{rows} row(s) deleted");

            var students = db.Query<Student>("SELECT * FROM Students").ToList();
            foreach (var st in students)
            {
                Console.WriteLine($"{st.Id}: {st.Name}, {st.Age}, {st.Adress}, {st.Email}, {st.Year}");
            }
        }
    }
}
