using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public class FactoryDesign
    {
        public static void Init()
        {
            Employee contractEmployee = new Employee();
            contractEmployee.EmployeeType = EmployeeType.Contractor;
            contractEmployee.EmployeeId = 1;
            contractEmployee.Name = "Stephan";

            IEmployeeManagerFactory empFactory = new EmployeeManagerFactory();
            IEmployeeManager empManager = empFactory.GetEmployeeManger(contractEmployee.EmployeeType);
            contractEmployee.HourlyPay = empManager.GetHourlyPay();
            contractEmployee.Bonus = empManager.GetBonus();

            PrintEmployeeInfo(contractEmployee);

            Employee permananentEmployee = new Employee();
            permananentEmployee.EmployeeType = EmployeeType.Permananet;
            permananentEmployee.EmployeeId = 2;
            permananentEmployee.Name = "Thinagaran";

            empManager = empFactory.GetEmployeeManger(permananentEmployee.EmployeeType);
            permananentEmployee.HourlyPay = empManager.GetHourlyPay();
            permananentEmployee.Bonus = empManager.GetBonus();

            PrintEmployeeInfo(permananentEmployee);

        }

        public static void PrintEmployeeInfo(Employee employee)
        {
            Console.WriteLine($"{employee.Name} is a {employee.EmployeeType.ToString()} employee with a hourly pay of {employee.HourlyPay}$ and eligible for a bonus amount of {employee.Bonus}");
        }
    }

    public class EmployeeManagerFactory : IEmployeeManagerFactory
    {
        private IEmployeeManager employeeManager;

        public IEmployeeManager GetEmployeeManger(EmployeeType employeeType)
        {
            switch (employeeType)
            {
                case EmployeeType.Permananet:
                    employeeManager = new PermanenetEmployeeManager();
                    break;
                case EmployeeType.Contractor:
                    employeeManager = new ContractEmployeeManager();
                    break;
            }

            return employeeManager;
        }
    }

    public interface IEmployeeManagerFactory
    {
        IEmployeeManager GetEmployeeManger(EmployeeType employeeType);
    }

    public interface IEmployeeManager
    {
        decimal GetBonus();
        decimal GetHourlyPay();
        string GetDescription(Employee employee);
    }

    public class PermanenetEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 50;
        }

        public string GetDescription(Employee employee)
        {
            var description = $"{employee.Name} is a {employee.EmployeeType.ToString()} employee with a hourly pay of {employee.HourlyPay}$ and eligible for a bonus amount of {employee.Bonus}$.  He is not eligible for House rent allowance and eligible for Medical allowance for Medical Allowance of {employee.MedicalAllowance}$";
            return description;
        }

        public decimal GetHourlyPay()
        {
            return 500;
        }

        public decimal GetMedicalAllowance()
        {
            return 100;
        }
    }

    public class ContractEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 10;
        }

        public string GetDescription(Employee employee)
        {
            var description = $"{employee.Name} is a {employee.EmployeeType.ToString()} employee with a hourly pay of {employee.HourlyPay}$ and eligible for a bonus amount of {employee.Bonus}$.  He is eligble for House rent allowance of {employee.HouseRentAllowance}$ and not eligible for Medical allowance";
            return description;
        }

        public decimal GetHourlyPay()
        {
            return 200;
        }

        public decimal GetHouseRentAllowance()
        {
            return 300;
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public decimal Bonus { get; set; }
        public decimal HourlyPay { get; set; }
        public EmployeeRole EmployeeRole { get; set; }

        //Applicable to Contract employee
        public decimal HouseRentAllowance { get; set; }

        //Applicable to Permanent employee
        public decimal MedicalAllowance { get; set; }

        public string EmployeeDescription { get; set; }
    }

    public enum EmployeeType
    {
        Permananet,
        Contractor
    }

    public enum EmployeeRole
    {
        Manager,
        Supervisor,
        Other
    }
}
