using System;
using System.Globalization;

namespace AssignmentSession17
{
    public class HireDate
    {
        #region Attributes
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        #endregion

        #region Constructor
        public HireDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public HireDate (HireDate hireDate)
        {
            Year=hireDate.Year;
            Month = hireDate.Month;
            Day = hireDate.Day;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year:D4}";
        }

        public static HireDate CreateHireDate()
        {
            string input;
            int year, month, day;
            do
            {
                Console.Write("Enter the day of hiring date");
                input = Console.ReadLine();
            }
            while (int.TryParse(input, out day));
            do
            {
                Console.Write("Enter the month of hiring date");
                input = Console.ReadLine();
            }
            while (int.TryParse(input, out month));
            do
            {
                Console.Write("Enter the year of hiring date");
                input = Console.ReadLine();
            }
            while (int.TryParse(input, out year));

            return new HireDate(day,month,year);
        }
        public static bool CompareToDates(HireDate left,HireDate right)
        {
            if (left.Year > right.Year)
            {
                return true;
            }
            else if (left.Year < right.Year)
            {
                return false;
            }
            else if (left.Month > right.Month)
            {
                return true;
            }
            else if (left.Month < right.Month)
            {
                return false;
            }
            else if (left.Day > right.Day)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion
    }
    public enum Gender
    {
        M,
        F
    }




    [Flags]
    public enum SecurityLevel
    {
        Guest =1,
        Developer=2,
        Secretary=4,
        DBA=8,
    }

    public class Employee 
    {
        #region Attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public SecurityLevel SecurityLevel { get; set; }
        public decimal Salary { get; set; }
        public HireDate HireDate { get; set; }
        private Gender Gender { get; set; }

        #endregion

        #region Constructor
        public Employee()
        {

        }
        public Employee(Employee employee)
            
        {
            Id = employee.Id;
            Name = employee.Name;
            SecurityLevel = employee.SecurityLevel;
            Salary = employee.Salary;
            HireDate = new HireDate(employee.HireDate);
            Gender = employee.Gender;
           
        }
        #endregion

        #region Methods
       

        public override string ToString()
        {
            return $"Name: {Name}\nID: {Id}\nSecurity Level: {SecurityLevel}\n" +
                   $"Salary: {String.Format(CultureInfo.CurrentCulture, "{0:C}", Salary)}\n" +
                   $"Hire Date: {base.ToString()}\nGender: {Gender}";
        }

       public static Employee  CreateEmployee(SecurityLevel sec)
        {
            Employee emp = new Employee();
            emp.SecurityLevel = sec;
            string? input;
            int id;
            do
            {
                Console.Write("Enter the Employee ID: ");
                input = Console.ReadLine();

            }
            while (!int.TryParse(input,out id));
            emp.Id = id;
            Console.Write("Enter the employee Name: ");
            emp.Name = Console.ReadLine();
            do
            {
                Console.Write("Enter the Employee Salary: ");
                input = Console.ReadLine();

            }
            while (!int.TryParse(input, out id));
            emp.Salary = id;
            emp.HireDate = HireDate.CreateHireDate();
            Gender g;
            do
            {
                Console.Write("Enter the Employee Gender: ");
                input = Console.ReadLine();

            }
            while (!Enum.TryParse(input, out g));
            emp.Gender = g;
            return emp;
        }
        public static Employee[] SortEmployee(Employee[] emp)
        {
            for(int i = 0; i < emp.Length; i++)
            {
                int minind = i;
                for(int j = i + 1; j < emp.Length; j++)
                {
                    if (HireDate.CompareToDates(emp[i].HireDate, emp[minind].HireDate))
                    {
                        minind = j;
                    }
                }
                if (minind != i)
                {
                    Employee temp = new Employee(emp[minind]);
                    emp[minind] = new Employee(emp[i]);
                    emp[i] = temp;
                }
            }
            return emp;


        }

        #endregion
    }

  
}
