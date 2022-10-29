using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection.Metadata;

internal class Program
{
    class Flower
    {
        String Name;
        int Price;
        string Article;

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



    class FlowerShop
    {
        string Address;
        string Name;
        Collection<Flower> Flowers;
        Collection<FlowerShopEmployee> FlowerShopEmployees;

        public FlowerShop(string address, string name, Collection<Flower> flowers, Collection<FlowerShopEmployee> flowerShopEmployees)
        {
            this.Address = address;
            this.Name = name;
            this.Flowers = flowers;
            this.FlowerShopEmployees = flowerShopEmployees;
        }
        public void addEmployee(FlowerShopEmployee flowerShopEmployee)
        {
            this.FlowerShopEmployees.Add(flowerShopEmployee);
        }

        public FlowerShopEmployee GetEmployeeByID(string ID_search)
        {
            foreach (var Emp in FlowerShopEmployees)
            {
                if (ID_search == Emp.getID())
                {
                    return Emp;
                }
            }
            return null;
        }
        public void fireEmployeeById(string ID_search)
        {
            foreach (var Emp in FlowerShopEmployees)
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

    class FlowerShopEmployee
    {
        private string ID;
        string Name;
        int Age;
        //position toggle(or whatever) should be added
        FlowerShopEmployeePosition employeePosition;
        bool isWorking;


        FlowerShopEmployee(string codeOfEmloyee, string name, int age, FlowerShopEmployeePosition employeePosition)
        {
            ID = codeOfEmloyee;
            Name = name;
            Age = age;
            this.employeePosition = employeePosition;
            bool isWorking = true;
        }
        FlowerShopEmployee()
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

    enum FlowerShopEmployeePosition { StockWorker, Seller, Administrator }

    class Prog
    {
        Collection<FlowerShop> flowerShops;
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