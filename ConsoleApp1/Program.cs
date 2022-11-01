using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection.Metadata;

internal class Program
{
    class Flower//товар магазину
    {
       private String Name;
       private int Price;
       private string Article;

        public Flower(string name, int price, string article)
        {
            this.Name = name;
            this.Price = price;
            this.Article = article;
        }
        public Flower()
        {
            Console.WriteLine("name of the flower:");
            this.Name = Console.ReadLine();
            Console.WriteLine("price of the flower:");
            this.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("article(code) of the flower:");
            this.Article = Console.ReadLine();
        }

    }



    class FlowerShop//магазин квіток
    {
        private string Address;
        private string Name;
        private Collection<Flower> Flowers;
        private Collection<Employee> Employees;

        public FlowerShop(string address, string name, Collection<Flower> flowers, Collection<Employee> employees)
        {
            this.Address = address;
            this.Name = name;
            this.Flowers = flowers;
            this.Employees = employees;
        }
        public void addEmployee(Employee flowerShopEmployee)
        {
            this.Employees.Add(flowerShopEmployee);
        }

        public Employee GetEmployeeByID(string ID_search)
        {
            foreach (var Emp in Employees)
            {
                if (ID_search == Emp.getID())
                {
                    return Emp;
                }
            }
            return null;
        }
        public void fireEmployeeById(string ID_search)//звільнити робітника
        {
            foreach (var Emp in Employees)
            {
                if (ID_search == Emp.getID())
                {
                    Emp.changeStatusToFired();
                    Console.WriteLine("this employee has been fired successfully");
                }
            }
            Console.WriteLine("we have not found the worker");  

        }
    }

    class Employee
    {
        private string ID;
        private string Name;
        private int Age;
        //position toggle(or whatever) should be added
        private FlowerShopEmployeePosition employeePosition;
        private bool isWorking;


        Employee(string codeOfEmloyee, string name, int age, FlowerShopEmployeePosition employeePosition)//створення працівника
        {
            ID = codeOfEmloyee;
            Name = name;
            Age = age;
            this.employeePosition = employeePosition;
            bool isWorking = true;
        }
        Employee()//створення працівника через консоль(потрібність в проекті цього метода саме в цьому классі не доведена)
        {
            Console.WriteLine("name of the worker:");
            this.Name = Console.ReadLine();
            Console.WriteLine("age of the worker:");
            this.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("worker's personal ID:");
            this.ID = Console.ReadLine();
        }
        public void changeStatusToFired()
        {
            this.isWorking = false;
        }

        public string getID()
        {
            return this.ID;
        }
        public string getName()
        {
            return this.Name;
        }

    }

    enum FlowerShopEmployeePosition { StockWorker, Seller, Administrator }//перерахування можливих позицій робітника

    class Prog//клас програми(щоб мінімізувати код в Main)
    {
        private Collection<FlowerShop> flowerShops;
        public void Start()
        {

        }
        public Prog()
        {

        }

    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        Prog currentProg = new Prog();
       

    }
}