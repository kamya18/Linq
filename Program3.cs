using System;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Program3
{
    [Table(Name = "Department")]
    public class Department
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int DeptId { get; set; }

        [Column]
        public string Deptname { get; set; }
    }

    public class DataContext : DataContext
    {
        public DataContext(string connectionString) : base(connectionString) { }

        public Table<Department> Departments;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=PMCLAP1271-1118;Database=Practice;User Id=sa;Password=India@123;";
            DataContext db = new DataContext(connectionString);

            // Querying data using LINQ to SQL
            var query = from c in db.Departments
                        where c.Deptname.StartsWith("A")
                        select c;

            Console.WriteLine("Departments whose names start with 'A':");
            foreach (var dept in query)
            {
                Console.WriteLine($"ID: {dept.DeptId}, Name: {dept.Deptname}");
            }

            // Inserting a new department
            Department newDepartment = new Department { Deptname = "New Department" };
            db.Departments.InsertOnSubmit(newDepartment);
            db.SubmitChanges();

            Console.WriteLine("\nNew dept added.");

            // Updating an existing department
            var departmentToUpdate = db.Departments.Single(c => c.DeptId == 1);
            departmentToUpdate.Deptname = "Updated Dept";
            db.SubmitChanges();

            Console.WriteLine("Dept updated.");

            // Deleting a department
            var departmentToDelete = db.Departments.Single(c => c.DeptId == 2);
            db.Departments.DeleteOnSubmit(departmentToDelete);
            db.SubmitChanges();

            Console.WriteLine("Dept deleted.");
        }
    }
}
