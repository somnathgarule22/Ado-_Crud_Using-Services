using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoUsing_Services5_10
{
    internal class Program
    {
        EmployeeServices er;
        public Program()
        {
            er= new EmployeeServices();

        }
        public void Add()
        {
            Employee e=new Employee();
            Console.WriteLine("Enter Employee Name");
            e.name = Console.ReadLine();

            Console.WriteLine("Enter Employee Designation");
            e.designation= Console.ReadLine();

            Console.WriteLine("Enter Employee Salary");
            e.salary = (float)Convert.ToDouble(Console.ReadLine());

            string msg=er.AddEmployee(e);
            Console.WriteLine(msg);
        }
        public void Display()
        {
            List<Employee> lst=er.GetEmployees();
            foreach (Employee e in lst)
            {
                Console.WriteLine($"{e.id} {e.name} {e.designation} {e.salary}");
            }
        }
        public void UpdateEmployee()
        {
            Employee e = new Employee();
            Console.WriteLine("Enter Employee Id");
            e.id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Employee Name");
            e.name= Console.ReadLine();
            Console.WriteLine("Enter Employee Designation");
            e.designation= Console.ReadLine();

            Console.WriteLine("Enter Employee Salary");
            e.salary=(float)Convert.ToDouble(Console.ReadLine());

            string msg = er.UpdateEmployee(e);
            Console.WriteLine(msg);
        }

        public void DeleteEmployee()
        {
            Employee e=new Employee();
            Console.WriteLine("Enter Employee ID");
            e.id= Convert.ToInt32(Console.ReadLine());

            string msg= er.DeleteEmployee(e);
            Console.WriteLine(msg);
        }



        static void Main(string[] args)
        {
            Program p = new Program();
            int ch, i = 1;
            while(i!=0)
            {
                Console.WriteLine("Choice?\n1. Add Employee\n2. Display Student\n3.Update Employee\n4.Delete Employee");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        {
                            p.Add();
                            break;
                        }
                        case 2:
                        {
                            p.Display();
                            break;
                        }
                    case 3:
                        {
                            p.UpdateEmployee();
                            break;
                        }
                    case 4:
                        {
                            p.DeleteEmployee();
                            break;
                        }
                            

                        
                    default:
                        {
                            Console.WriteLine("Please Enter Correct Choice");
                            break;
                        }
                }
                Console.WriteLine("Do You Want to Continue? if yes(1) no(0)");
                i = Convert.ToInt32(Console.ReadLine());

            }
        }
    }
}
