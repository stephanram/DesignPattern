using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.AbstractFactory
{
    public class AbstractFactoryMethod
    {
        public static void Init()
        {
            Employee contractEmployee = new Employee();
            contractEmployee.EmployeeType = EmployeeType.Contractor;
            contractEmployee.EmployeeId = 1;
            contractEmployee.EmployeeRole = EmployeeRole.Other;
            contractEmployee.Name = "Stephan";

            EmployeeSystemFactory systemFactory = new EmployeeSystemFactory();
            IComputerFactory factory = systemFactory.Create(contractEmployee);
            Console.WriteLine($"Contract employee - {factory.Brand().GetBrand().ToString()} {factory.Processor().GetProcessor().ToString()} {factory.SystemType().GetSystemType().ToString()}");

            Employee permananentEmployee = new Employee();
            permananentEmployee.EmployeeType = EmployeeType.Permananet;
            permananentEmployee.EmployeeId = 2;
            permananentEmployee.EmployeeRole = EmployeeRole.Supervisor;
            permananentEmployee.Name = "Thinagaran";

            factory = systemFactory.Create(permananentEmployee);
            Console.WriteLine($"Permanent employee - {factory.Brand().GetBrand().ToString()} {factory.Processor().GetProcessor().ToString()} {factory.SystemType().GetSystemType().ToString()}");
        }
    }
}
