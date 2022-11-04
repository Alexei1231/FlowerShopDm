using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;

internal class Program
{
    class Flower//товар магазину(квітка)
    {
        private String Name;
        private int Price;
        private String Article;
        private bool Availability = true;

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

        public String getArticle()
        {
            return this.Article;
        }

        public String getName()
        {
            return this.Name;
        }

        public int getPrice()
        {
            return this.Price;
        }
        public void changeStatusToUnavailable()
        {
            this.Availability = false;
        }
        public void changeStatusToAvailable()
        {
           this.Availability = true;
        }


    }



    class FlowerShop//магазин квіток
    {
        private string Address;
        private string Name;
        private Collection<Flower> Flowers = new Collection<Flower>();
        private Collection<Employee> Employees = new Collection<Employee>();

        public FlowerShop(string address, string name, Collection<Flower> flowers, Collection<Employee> employees)
        {
            this.Address = address;
            this.Name = name;
            this.Flowers = flowers;
            this.Employees = employees;
        }

        public FlowerShop()
        {

            if (this.Name == null)//стрінг не може бути налл, треба доробити цей механізм
            {
                Console.WriteLine("enter the name of the shop:");
                this.Name = Console.ReadLine();
            }
            if (this.Address == null)
            {
                Console.WriteLine("enter the address of the shop:");
                this.Address = Console.ReadLine();
            }



        }

        public void addEmployee(Employee employeeToAdd)//додавання працівника до штату через код
        {
            this.Employees.Add(employeeToAdd);
        }

        public void addEmployee()//додавання працівника до штату через консоль
        {
            Employee employeeToAdd = new Employee();//"консольне створення" робітника
            this.Employees.Add(employeeToAdd);

        }


        public Employee getEmployeeByID(string ID_search)
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
        public void fireEmployeeById()//(string idForSearching)//звільнити робітника
        {
            this.showEmployees();
            Console.WriteLine("write the ID of the employee you want to fire");
            string idForSearching = Console.ReadLine();
            foreach (var Emp in Employees)
            {
                if (idForSearching == Emp.getID())
                {
                    Emp.changeStatusToFired();
                    Console.WriteLine("this employee has been fired successfully");
                }
            }
            Console.WriteLine("we have not found the worker");

        }
        public void bringEmployeeBack()
        {
            this.showEmployees();
            Console.WriteLine("write the ID of the employee you want to bring back");
            string idForSearching = Console.ReadLine();
            foreach (var Emp in Employees)
            {
                if (idForSearching == Emp.getID())
                {
                    Emp.changeStatusToWorking();
                    Console.WriteLine("this employee has been brung back successfully");
                }
            }
            Console.WriteLine("we have not found the worker");
        }
        public void showEmployees()
        {
            foreach(var Emp in Employees)
            {
      
                Console.WriteLine("id: {0}  name: {1}", Emp.getID, Emp.getName);

            }
        }
        public void addFlower(Flower flowerToAdd)
        {
            this.Flowers.Add(flowerToAdd);
        }//додавання квітки до списку "через код"
        public void addFlower()//додавання квітки до списку через консоль
        {
            Flower flowerToAdd = new Flower();
            Flowers.Add(flowerToAdd);
        }
        public void showFlowers()
        {
            foreach (var Flo in Flowers)
            {
                Flo.getArticle();
                Flo.getName();
                Flo.getPrice();

            }
        }
        public void setFlowerStatusToUnavailable()
        {
            this.showFlowers();
            Console.WriteLine("write the article of the flower you want to change its status to unavailable");
            string articleForSearching = Console.ReadLine();
            foreach (var Flo in Flowers)
            {
                if (articleForSearching == Flo.getArticle())
                {
                    Flo.changeStatusToUnavailable();
                    Console.WriteLine("this flower is now unavailable");
                }
            }
            Console.WriteLine("we have not found the flower");
        }
        public void setFlowerStatusToAvailable()
        {
            this.showFlowers();
            Console.WriteLine("write the article of the flower you want to change its status to available");
            string articleForSearching = Console.ReadLine();
            foreach (var Flo in Flowers)
            {
                if (articleForSearching == Flo.getArticle())
                {
                    Flo.changeStatusToAvailable();
                    Console.WriteLine("this flower is now available");
                }
            }
            Console.WriteLine("we have not found the flower");
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


        public Employee(string codeOfEmloyee, string name, int age, FlowerShopEmployeePosition employeePosition)//створення працівника
        {
            ID = codeOfEmloyee;
            Name = name;
            Age = age;
            this.employeePosition = employeePosition;
            bool isWorking = true;
        }
        public Employee()//створення працівника через консоль(потрібність в проекті цього метода саме в цьому классі не доведена)
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
        public void changeStatusToWorking()
        {
            this.isWorking = true;
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
        bool workingStage = true;
        //private Collection<FlowerShop> flowerShops;
        FlowerShop userFlowerShop;
        public void Start() //стартова сторінка програми; створення першого магазину
        {
            userFlowerShop = new FlowerShop();
            Menu();

        }
        public void Menu()
        {
            while (workingStage)
            {
                Console.WriteLine(" 1 - to add an employee to your shop\n " +
                    "2 - to add a new flower \n" +
                    "3 - to show employees \n" +
                    "4 - to fire an employee\n" +
                    "5 - to bring an employee back\n" +
                    "6 - to show items\n" +
                    "7 - to change item's status to unavailable\n" +
                    "8 - to change item's status to available\n" +
                    "9 - to shut the programm down\n");
                int userChoose = Convert.ToInt32(Console.ReadLine());
                switch (userChoose)
                {
                    case 1:
                        userFlowerShop.addEmployee();
                        this.Menu();
                        break;
                    case 2:
                        userFlowerShop.addFlower();
                        this.Menu();
                        break;
                    case 3:
                        userFlowerShop.showFlowers();
                        this.Menu();
                        break;
                    case 4:
                        userFlowerShop.fireEmployeeById();
                        this.Menu();
                        break;
                    case 5: 
                        userFlowerShop.bringEmployeeBack(); 
                        this.Menu();
                        break;
                    case 6:
                        userFlowerShop.showFlowers();
                        this.Menu();
                        break;
                    case 7:
                        userFlowerShop.setFlowerStatusToUnavailable();
                        this.Menu();
                        break;
                    case 8:
                        userFlowerShop.setFlowerStatusToAvailable();
                        this.Menu();
                        break;
                    case 9:
                        this.workingStage = false;
                        break;


                }

            }
        }
        public Prog()
        {
            Start();
        }

    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        Prog currentProg = new Prog();


    }
}