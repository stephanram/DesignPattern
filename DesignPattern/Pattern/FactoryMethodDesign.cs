using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public class FactoryMethodDesign
    {
        public static void Init()
        {
            Employee contractEmployee = new Employee();
            contractEmployee.EmployeeType = EmployeeType.Contractor;
            contractEmployee.EmployeeId = 1;
            contractEmployee.Name = "Stephan";

            EmployeeFactoryManager factoryManager = new EmployeeFactoryManager();
            BaseEmployeeFactory factory = factoryManager.Create(contractEmployee);
            contractEmployee = factory.ApplySalary();
            Console.WriteLine(contractEmployee.EmployeeDescription);

            Employee permananentEmployee = new Employee();
            permananentEmployee.EmployeeType = EmployeeType.Permananet;
            permananentEmployee.EmployeeId = 2;
            permananentEmployee.Name = "Thinagaran";

            factory = factoryManager.Create(permananentEmployee);
            permananentEmployee = factory.ApplySalary();
            Console.WriteLine(permananentEmployee.EmployeeDescription);

        }
    }

    public class EmployeeFactoryManager
    {
        public BaseEmployeeFactory Create(Employee employee)
        {
            BaseEmployeeFactory baseEmployeeFactory;

            switch (employee.EmployeeType)
            {
                case (EmployeeType.Permananet):
                    baseEmployeeFactory = new PermanentEmployeeFactory(employee);
                    break;
                case (EmployeeType.Contractor):
                    baseEmployeeFactory = new ContractEmployeeFactory(employee);
                    break;
                default:
                    baseEmployeeFactory = new ContractEmployeeFactory(employee);
                    break;
            }

            return baseEmployeeFactory;
        }
    }

    public abstract class BaseEmployeeFactory
    {
        protected Employee employee = null;

        public BaseEmployeeFactory(Employee employee)
        {
            this.employee = employee;
        }

        public Employee ApplySalary()
        {
            IEmployeeManager manager = this.Create();
            this.employee.Bonus = manager.GetBonus();
            this.employee.HourlyPay = manager.GetHourlyPay();
            this.employee.EmployeeDescription = manager.GetDescription(this.employee);
            return this.employee;
        }

        public abstract IEmployeeManager Create();
    }

    public class PermanentEmployeeFactory : BaseEmployeeFactory
    {
        public PermanentEmployeeFactory(Employee employee) : base(employee)
        {
        }

        public override IEmployeeManager Create()
        {
            PermanenetEmployeeManager manager = new PermanenetEmployeeManager();
            this.employee.MedicalAllowance = manager.GetMedicalAllowance();
            return manager;
        }
    }

    public class ContractEmployeeFactory : BaseEmployeeFactory
    {
        public ContractEmployeeFactory(Employee employee) : base(employee)
        {
        }

        public override IEmployeeManager Create()
        {
            ContractEmployeeManager manager = new ContractEmployeeManager();
            this.employee.HouseRentAllowance = manager.GetHouseRentAllowance();
            return manager;
        }
    }



}
