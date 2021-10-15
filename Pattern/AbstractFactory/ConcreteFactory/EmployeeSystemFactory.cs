using DesignPattern.Pattern.AbstractFactory.AbstractProduct;
using DesignPattern.Pattern.AbstractFactory.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.AbstractFactory
{
    public class EmployeeSystemFactory
    {
        public IComputerFactory Create (Employee employee)
        {
            IComputerFactory computerFactory = null;

            if(employee.EmployeeType == EmployeeType.Permananet)
            {
                if (employee.EmployeeRole == EmployeeRole.Manager)
                    computerFactory = new MACLaptonFactory();
                else
                    computerFactory = new MACComputerFactory();
            }
            else if (employee.EmployeeType == EmployeeType.Contractor)
            {
                if (employee.EmployeeRole == EmployeeRole.Manager)
                    computerFactory = new DellLaptopFactory();
                else
                    computerFactory = new DellComputerFactory();
            }

            return computerFactory;
        }
    }
}
